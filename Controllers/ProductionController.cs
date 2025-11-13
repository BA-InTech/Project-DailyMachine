using ClosedXML.Excel;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using backend.Models;
using backend.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Hosting;
using System.Text.Json;
using System.Threading.Tasks;

namespace backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductionController : ControllerBase
    {
        private readonly IWebHostEnvironment _hostingEnvironment;
        private readonly ApplicationDbContext _context;
        private const int PLANNED_TARGET_TIME = 458;
        private static readonly object _recapFileLock = new object();

        public ProductionController(IWebHostEnvironment hostingEnvironment, ApplicationDbContext context)
        {
            _hostingEnvironment = hostingEnvironment;
            _context = context;
        }

        // GET REPORT
        [HttpGet("report/{date}/{shift}")]
        public async Task<IActionResult> GetReport(string date, int shift)
        {
            if (string.IsNullOrEmpty(date) || shift <= 0 || shift > 3) { return BadRequest("Invalid date or shift parameter."); }
            try
            {
                var report = await _context.ProductionReports.Include(r => r.Lines!).ThenInclude(l => l.Models!).ThenInclude(m => m.Issues).AsNoTracking().FirstOrDefaultAsync(r => r.Date == date && r.Shift == shift);
                if (report == null) return NotFound();
                return Ok(report);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[ERROR] in GetReport({date}, {shift}): {ex.Message}");
                return StatusCode(500, "Internal server error while fetching report.");
            }
        }

        // SAVE REPORT
        [HttpPost("report")]
        public async Task<IActionResult> SaveReport([FromBody] ProductionReport reportDataFromFrontend)
        {
            if (reportDataFromFrontend == null || string.IsNullOrEmpty(reportDataFromFrontend.Date) || reportDataFromFrontend.Shift <= 0) { return BadRequest("Invalid report data received."); }
            
            reportDataFromFrontend.SavedTimestamp = DateTime.UtcNow.ToString("yyyy-MM-dd HH:mm:ss.fff"); 

            try
            {
                var existingReport = await _context.ProductionReports
                    .Include(r => r.Lines!).ThenInclude(l => l.Models!).ThenInclude(m => m.Issues)
                    .FirstOrDefaultAsync(r => r.Date == reportDataFromFrontend.Date && r.Shift == reportDataFromFrontend.Shift);

                if (existingReport == null)
                {
                    reportDataFromFrontend.Id = 0;
                    if (reportDataFromFrontend.Lines != null)
                    {
                        foreach (var line in reportDataFromFrontend.Lines)
                        {
                            line.Id = 0;
                            if (line.Models != null)
                            {
                                foreach (var model in line.Models)
                                {
                                    model.Id = Guid.NewGuid().ToString(); 
                                    if (model.Issues != null) { foreach (var issue in model.Issues) { issue.Id = 0; } }
                                }
                            }
                        }
                    }
                    _context.ProductionReports.Add(reportDataFromFrontend);
                }
                else
                {
                    existingReport.Performance = reportDataFromFrontend.Performance;
                    existingReport.SavedTimestamp = reportDataFromFrontend.SavedTimestamp; 
                    
                    if (existingReport.Lines != null) 
                    {
                        _context.Lines.RemoveRange(existingReport.Lines);
                    }
                    existingReport.Lines = new List<Line>();

                    if (reportDataFromFrontend.Lines != null)
                    {
                        foreach (var line in reportDataFromFrontend.Lines)
                        {
                            line.Id = 0;
                            if (line.Models != null)
                            {
                                foreach (var model in line.Models)
                                {
                                    model.Id = Guid.NewGuid().ToString();
                                    if (model.Issues != null) { foreach (var issue in model.Issues) { issue.Id = 0; } }
                                }
                            }
                            existingReport.Lines.Add(line); 
                        }
                    }
                }
                
                await _context.SaveChangesAsync();
                
                if (existingReport != null)
                {
                    return Ok(existingReport);
                }
                else
                {
                    return Ok(reportDataFromFrontend);
                }
            }
            catch (DbUpdateConcurrencyException ex)
            {
                Console.WriteLine($"[WARNING - SaveReport Concurrency Conflict]: {ex.Message}");
                foreach (var entry in ex.Entries)
                {
                    if (entry.Entity is ProductionReport)
                    {
                        var databaseValues = await entry.GetDatabaseValuesAsync();
                        if (databaseValues == null) { entry.State = EntityState.Detached; }
                        else { entry.OriginalValues.SetValues(databaseValues); entry.State = EntityState.Modified; }
                    }
                }
                try
                {
                    await _context.SaveChangesAsync();
                    var fixedReport = await _context.ProductionReports
                        .Include(r => r.Lines!).ThenInclude(l => l.Models!).ThenInclude(m => m.Issues)
                        .AsNoTracking()
                        .FirstOrDefaultAsync(r => r.Date == reportDataFromFrontend.Date && r.Shift == reportDataFromFrontend.Shift);
                    return Ok(fixedReport);
                }
                catch (DbUpdateConcurrencyException retryEx)
                {
                    Console.WriteLine($"[FATAL ERROR - SaveReport Retry Failed]: {retryEx.Message}");
                    return StatusCode(500, "Internal server error: Concurrency conflict persists after fix.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[ERROR - SaveReport]: {ex.Message}");
                if (ex.InnerException != null) Console.WriteLine($"   Inner Exception: {ex.InnerException.Message}");
                return StatusCode(500, "Internal server error while saving report.");
            }
        }

        // =======================================================================
        // ▼▼▼ FUNGSI INI SUDAH DIPERBAIKI UNTUK MENGATASI BUG 'DATA NYANGKUT' ▼▼▼
        // =======================================================================
      // =======================================================================
        // ▼▼▼ FUNGSI INI SUDAH DIPERBAIKI (MENGATASI CS8072 & CS8602) ▼▼▼
        // =======================================================================
       [HttpGet("machines/{machineName}/monthly")]
        public async Task<IActionResult> GetMonthlyData(
            string machineName,
            int month,
            int year,
            [FromQuery] string shift)
        {
            int shiftInt = 1;
            if (shift.EndsWith(" 2")) shiftInt = 2;
            else if (shift.EndsWith(" 3")) shiftInt = 3;

            const double PLANNED_TARGET_TIME = 458.0;

            try
            {
                var reports = await _context.ProductionReports
                    .Where(pr =>
                        pr.Date.StartsWith($"{year}-{month:D2}") &&
                        pr.Shift == shiftInt &&
                        pr.Lines != null // <-- ✅✅ PERBAIKAN SEHARUSNYA DI SINI
                    )
                    .Select(pr => new
                    {
                        ReportDate = pr.Date,
                        // Baris ini (line 182) sekarang aman
                        MatchingLine = pr.Lines.FirstOrDefault(l => l.Machine == machineName)
                    })
                    .Where(x => x.MatchingLine != null)
                    .ToListAsync(); 

                var chartData = new
                {
                    labels = reports.Select(r => {
                        if (string.IsNullOrEmpty(r.ReportDate)) return null;
                        var parts = r.ReportDate.Split('-');
                        return (parts.Length == 3) ? $"{parts[2]}/{parts[1]}" : null;
                    }).Where(l => l != null).ToList(),

                    data = reports.Select(r => {
                        var perf = r.MatchingLine?.MachinePerformance ?? new MachinePerformance();

                        double totalDayTime = (perf.TimeUsed + perf.LossTime);
                        double percentage = (PLANNED_TARGET_TIME > 0)
                                        ? (totalDayTime / PLANNED_TARGET_TIME) * 100
                                        : 0;

                        return new
                        {
                            usedTime = perf.TimeUsed,
                            lossTime = perf.LossTime,
                            percentage = percentage
                        };
                    }).ToList()
                };

                return Ok(chartData);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
        
        // GET RECAP
        [HttpGet("recap")]
        public async Task<IActionResult> GetRecap([FromQuery] string date, [FromQuery] int maxShift)
        {
            if (string.IsNullOrEmpty(date)) return BadRequest("Date parameter is required.");
            if (maxShift <= 0) maxShift = 3;
            var shiftsToInclude = Enumerable.Range(1, maxShift).ToList();
            var shiftStandardTimes = new Dictionary<int, int> { { 1, 458 }, { 2, 398 }, { 3, 398 } };
            try
            {
                var reports = await _context.ProductionReports.Include(r => r.Lines).Where(r => r.Date == date && shiftsToInclude.Contains(r.Shift)).OrderBy(r => r.Shift).AsNoTracking().ToListAsync();
                if (reports.Count == 0) return Ok(null);
                double totalTimeUsed = 0, totalIssueDuration = 0, totalAvailableTime = 0, totalStandardWorkingTime = 0;
                foreach (var report in reports)
                {
                    if (report.Performance != null && report.Lines != null)
                    {
                        totalTimeUsed += report.Performance.TotalTimeUsed;
                        totalIssueDuration += report.Performance.TotalIssueDuration;
                        var netWorkingTimePerMachine = report.Performance.NetWorkingTime > 0 ? report.Performance.NetWorkingTime : (shiftStandardTimes.ContainsKey(report.Shift) ? shiftStandardTimes[report.Shift] : 0);
                        totalAvailableTime += netWorkingTimePerMachine * report.Lines.Count;
                        totalStandardWorkingTime += shiftStandardTimes.ContainsKey(report.Shift) ? shiftStandardTimes[report.Shift] : 0;
                    }
                }
                if (totalAvailableTime == 0) return Ok(null);
                var lossTime = totalAvailableTime - totalTimeUsed - totalIssueDuration;
                var utilizationPercent = (totalAvailableTime > 0) ? (totalTimeUsed / totalAvailableTime) * 100 : 0;
                var recapResult = new {
                    shifts = string.Join(", ", reports.Select(r => $"Shift 0{r.Shift}")),
                    totalWorkingTime = totalStandardWorkingTime, totalNetWorkingTime = totalAvailableTime,
                    totalTimeUsed, totalIssueDuration, lossTime = Math.Max(0, lossTime),
                    utilizationPercent = Math.Min(utilizationPercent, 100)
                };
                return Ok(recapResult);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[ERROR] in GetRecap({date}, {maxShift}): {ex.Message}");
                return StatusCode(500, "Internal server error while calculating recap.");
            }
        }

        // SAVE TO EXCEL (DAILY REPORT)
        [HttpPost("SaveReportToExcel")]
        public async Task<IActionResult> SaveReportToExcel([FromBody] ReportRequestPayload payload)
        {
            try
            {
                if (payload == null || !DateTime.TryParse(payload.Date, out DateTime reportDate)) { return BadRequest(new { Message = "Invalid payload or date format." }); }
                
                var shiftsToPrint = await _context.ProductionReports
                    .Where(r => r.Date == payload.Date)
                    .Include(r => r.Lines!)
                    .ThenInclude(l => l.Models!)
                    .ThenInclude(m => m.Issues!)
                    .OrderBy(r => r.Shift)
                    .AsNoTracking()
                    .ToListAsync();
                
                if (shiftsToPrint.Count == 0) { return NotFound(new { Message = "No report data found for this date." }); }
                
                var templatePath = Path.Combine(_hostingEnvironment.ContentRootPath, "Assets", "Templates", "DailyReportLeader.xlsx");
                if (!System.IO.File.Exists(templatePath)) { return StatusCode(500, new { Message = "CRITICAL: Excel template file not found." }); }
                
                string fileName = $"DailyMachineReport_{reportDate:yyyy-MM-dd}_ALL_Shifts.xlsx";
                
                using (var stream = new MemoryStream())
                {
                    byte[] templateBytes = await System.IO.File.ReadAllBytesAsync(templatePath);
                    await stream.WriteAsync(templateBytes, 0, templateBytes.Length);
                    stream.Position = 0;
                    
                    using (var workbook = new XLWorkbook(stream))
                    {
                        var worksheet = workbook.Worksheet(1);
                        worksheet.Cell("D4").Value = reportDate.ToString("dd-MMM-yyyy");
                        var machineRowMap = new Dictionary<string, int> { { "JVK 02", 7 }, { "JVK 03", 16 }, { "AVK 03", 20 }, { "RH 01", 26 }, { "RH 03", 32 }, { "RH 04", 38 }, { "SMT 01", 42 }, { "SMT 02", 48 }, { "SMT 03", 54 } };
                        
                        foreach (var shiftData in shiftsToPrint)
                        {
                            int currentShift = shiftData.Shift;
                            int typePcbCol = 0, minCol = 0, planCol = 0, resultCol = 0, notesCol = 19; 

                            if (currentShift == 1) { typePcbCol = 4; minCol = 5; planCol = 6; resultCol = 7; }
                            else if (currentShift == 2) { typePcbCol = 9; minCol = 10; planCol = 11; resultCol = 12; }
                            else if (currentShift == 3) { typePcbCol = 14; minCol = 15; planCol = 16; resultCol = 17; }
                            else continue;

                            if (shiftData.Lines == null) continue;
                            
                            foreach (var line in shiftData.Lines)
                            {
                                if (line == null || string.IsNullOrWhiteSpace(line.Machine)) continue;
                                string machineKey = line.Machine.Trim();
                                if (!machineRowMap.TryGetValue(machineKey, out int dataStartRow)) continue;
                                if (line.Models == null) continue;
                                
                                for (int i = 0; i < line.Models.Count; i++)
                                {
                                    var model = line.Models[i]; if (model == null) continue; int targetRow = dataStartRow + i;
                                    worksheet.Cell(targetRow, typePcbCol).Value = model.ModelCode;
                                    worksheet.Cell(targetRow, minCol).Value = Math.Round(model.TimeUsed, 1);
                                    if (model.Plan > 0) worksheet.Cell(targetRow, planCol).Value = model.Plan;
                                    if (model.Result > 0) worksheet.Cell(targetRow, resultCol).Value = model.Result;

                                    var notesAndIssues = new List<string>();
                                    if (model.Issues != null && model.Issues.Any()) { notesAndIssues.AddRange(model.Issues.Where(issue => issue != null && issue.Duration > 0).Select(issue => $"S{currentShift}:{issue.Type}({issue.Duration}m)")); }
                                    if (!string.IsNullOrWhiteSpace(model.Note)) { notesAndIssues.Add($"S{currentShift}(Note): {model.Note.Trim()}"); }
                                    
                                    if (notesAndIssues.Any())
                                    {
                                        string combinedEntry = string.Join("; ", notesAndIssues);
                                        var existingNoteCell = worksheet.Cell(targetRow, notesCol);
                                        string existingNote = existingNoteCell.GetString();
                                        existingNoteCell.Value = string.IsNullOrWhiteSpace(existingNote) ? combinedEntry : $"{existingNote} | {combinedEntry}";
                                    }
                                }
                            }
                        }
                        
                        using (var outputStream = new MemoryStream())
                        {
                            workbook.SaveAs(outputStream);
                            outputStream.Position = 0;
                            return File(outputStream.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", fileName);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[FATAL ERROR] in SaveReportToExcel: {ex.Message}");
                return StatusCode(500, new { Message = "Internal server error creating Excel file.", Details = ex.Message });
            }
        }

        // SAVE MONTHLY RECAP
        // ▼▼▼ (FIXED CS1998) ▼▼▼
        [HttpPost("SaveMonthlyRecap")]
        public IActionResult SaveMonthlyRecap([FromBody] SaveRecapPayload payload)
        {
            if (payload == null || string.IsNullOrEmpty(payload.Date) || payload.Lines == null) { return BadRequest(new { message = "Payload tidak valid." }); }
            if (!DateTime.TryParse(payload.Date, out DateTime reportDate)) { return BadRequest(new { message = "Format tanggal tidak valid. Harap gunakan YYYY-MM-DD." }); }

            var templatePath = Path.Combine(_hostingEnvironment.ContentRootPath, "Assets", "Templates", "MonthlyMachineRecap_TEMPLATE.xlsx");
            if (!System.IO.File.Exists(templatePath)) { return StatusCode(500, new { message = "CRITICAL: File template 'MonthlyMachineRecap_TEMPLATE.xlsx' tidak ditemukan." }); }

            string outputFileName = $"MonthlyMachineRecap_{reportDate:yyyy-MM}.xlsx"; 
            var reportsDir = Path.Combine(_hostingEnvironment.ContentRootPath, "Assets", "MonthlyReports");
            Directory.CreateDirectory(reportsDir); 
            var outputPath = Path.Combine(reportsDir, outputFileName);

            try
            {
                lock (_recapFileLock)
                {
                    if (!System.IO.File.Exists(outputPath)) { System.IO.File.Copy(templatePath, outputPath); }
                    using (var workbook = new XLWorkbook(outputPath))
                    {
                        int dayOfMonth = reportDate.Day;
                        int targetColumnIndex = dayOfMonth + 4; 
                        foreach (var line in payload.Lines)
                        {
                            if (line == null || line.MachinePerformance == null) continue;
                            if (line.Models == null || !line.Models.Any() || line.MachinePerformance.OeeScore < 0.01) { continue; }

                            var sheetName = "MACHINE " + line.Machine;
                            if (!workbook.Worksheets.TryGetWorksheet(sheetName, out var worksheet))
                            {
                                Console.WriteLine($"[SaveMonthlyRecap] Peringatan: Sheet '{sheetName}' tidak ditemukan.");
                                continue; 
                            }

                            var models = line.Models ?? new List<RecapModelData>();
                            var allIssues = models.SelectMany(m => m.Issues ?? new List<RecapIssueData>()).ToList();
                            double availabilityLossDuration = 0, qualityLossDuration = 0;
                            double totalIdealTimeForLine = line.MachinePerformance.TimeUsed;
                            foreach (var issue in allIssues)
                            {
                                if (issue.Type.Trim().Equals("Rework", StringComparison.OrdinalIgnoreCase)) { qualityLossDuration += issue.Duration; }
                                else { availabilityLossDuration += issue.Duration; }
                            }
                            double plannedTime = PLANNED_TARGET_TIME; 
                            double machineIssueDuration = availabilityLossDuration + qualityLossDuration;
                            double operatingTime = plannedTime - availabilityLossDuration;
                            double availability = (plannedTime > 0) ? (operatingTime / plannedTime) : 0;
                            double performanceMetric = (operatingTime > 0) ? (totalIdealTimeForLine / operatingTime) : 0;
                            double totalTimeSpentOnQuality = totalIdealTimeForLine + qualityLossDuration;
                            double qualityMetric = (totalTimeSpentOnQuality > 0) ? (totalIdealTimeForLine / totalTimeSpentOnQuality) : 1;
                            double oeeScore = availability * performanceMetric * qualityMetric;
                            double machineLossTime = Math.Max(0, plannedTime - totalIdealTimeForLine - machineIssueDuration);
                            var lossTotals = new Dictionary<string, double>();
                            foreach (var issue in allIssues)
                            {
                                var issueTypeKey = issue.Type.Trim(); 
                                if (lossTotals.ContainsKey(issueTypeKey)) { lossTotals[issueTypeKey] += issue.Duration; }
                                else { lossTotals[issueTypeKey] = issue.Duration; }
                            }
                            worksheet.Cell(4, targetColumnIndex).Value = totalIdealTimeForLine;
                            worksheet.Cell(6, targetColumnIndex).Value = machineIssueDuration;
                            worksheet.Cell(8, targetColumnIndex).Value = machineLossTime;
                            worksheet.Cell(14, targetColumnIndex).Value = lossTotals.GetValueOrDefault("Stock Opname");
                            worksheet.Cell(16, targetColumnIndex).Value = lossTotals.GetValueOrDefault("Maintenance");
                            worksheet.Cell(18, targetColumnIndex).Value = lossTotals.GetValueOrDefault("Trial Run");
                            worksheet.Cell(22, targetColumnIndex).Value = lossTotals.GetValueOrDefault("Breakdown Loss");
                            worksheet.Cell(24, targetColumnIndex).Value = lossTotals.GetValueOrDefault("Set up loss");
                            worksheet.Cell(26, targetColumnIndex).Value = lossTotals.GetValueOrDefault("Model Changes Loss");
                            worksheet.Cell(28, targetColumnIndex).Value = lossTotals.GetValueOrDefault("Material Shortage (Ext)");
                            worksheet.Cell(30, targetColumnIndex).Value = lossTotals.GetValueOrDefault("Material Shortage (Int)");
                            worksheet.Cell(32, targetColumnIndex).Value = lossTotals.GetValueOrDefault("Waiting Material");
                            worksheet.Cell(36, targetColumnIndex).Value = lossTotals.GetValueOrDefault("Choko-tei");
                            worksheet.Cell(38, targetColumnIndex).Value = lossTotals.GetValueOrDefault("Speed Down Loss");
                            worksheet.Cell(42, targetColumnIndex).Value = lossTotals.GetValueOrDefault("Rework");
                            worksheet.Cell(44, targetColumnIndex).Value = oeeScore;
                            worksheet.Cell(46, targetColumnIndex).Value = availability;
                            worksheet.Cell(48, targetColumnIndex).Value = qualityMetric;
                            worksheet.Cell(50, targetColumnIndex).Value = performanceMetric;
                        }
                        workbook.Save(); 
                    }
                } 
                return Ok(new { message = $"Rekap bulanan untuk tanggal {reportDate:dd-MM-yyyy} berhasil disimpan di server." });
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[FATAL ERROR] di SaveMonthlyRecap: {ex.Message}");
                return StatusCode(500, new { message = "Gagal menyimpan file Excel di server.", details = ex.Message });
            }
        }

        // DOWNLOAD MONTHLY RECAP
        [HttpGet("DownloadMonthlyRecap")]
        public IActionResult DownloadMonthlyRecap([FromQuery] string date) 
        {
            if (!DateTime.TryParse(date, out DateTime reportDate)) { reportDate = DateTime.Now; }
            try
            {
                string outputFileName = $"MonthlyMachineRecap_{reportDate:yyyy-MM}.xlsx"; 
                var reportsDir = Path.Combine(_hostingEnvironment.ContentRootPath, "Assets", "MonthlyReports");
                var filePath = Path.Combine(reportsDir, outputFileName);

                if (!System.IO.File.Exists(filePath))
                {
                    var templatePath = Path.Combine(_hostingEnvironment.ContentRootPath, "Assets", "Templates", "MonthlyMachineRecap_TEMPLATE.xlsx");
                    if (!System.IO.File.Exists(templatePath)) { return NotFound(new { message = "File template rekap bulanan tidak ditemukan di server." }); }
                    var templateBytes = System.IO.File.ReadAllBytes(templatePath);
                    return File(templateBytes, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", outputFileName);
                }
                var fileBytes = System.IO.File.ReadAllBytes(filePath);
                return File(fileBytes, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", outputFileName);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[FATAL ERROR] di DownloadMonthlyRecap: {ex.Message}");
                return StatusCode(500, new { message = "Gagal mengunduh file Excel dari server.", details = ex.Message });
            }
        }
    }

    // DTO Classes
    public class ReportRequestPayload { public string Date { get; set; } = string.Empty; }
    public class ConsolidatedReportPayload { public string Date { get; set; } = string.Empty; public List<ShiftData> ShiftsToPrint { get; set; } = new List<ShiftData>(); }
    public class ShiftData { public int Shift { get; set; } public List<LineData> Lines { get; set; } = new List<LineData>(); public PerformanceData? Performance { get; set; } }
    public class LineData { public int Id { get; set; } public string Machine { get; set; } = string.Empty; public List<ModelData> Models { get; set; } = new List<ModelData>(); public MachinePerformanceData? MachinePerformance { get; set; } }
    public class ModelData { public string Id { get; set; } = Guid.NewGuid().ToString(); public string ModelCode { get; set; } = string.Empty; public double Plan { get; set; } public double PanelResult { get; set; } public double Result { get; set; } public double TimeUsed { get; set; } public string? Note { get; set; } public List<IssueData> Issues { get; set; } = new List<IssueData>(); } 
    public class IssueData { public int? Id { get; set; } public string Type { get; set; } = string.Empty; public double Duration { get; set; } }
    public class PerformanceData { public double TotalWorkingTime { get; set; } public double NetWorkingTime { get; set; } public double TotalTimeUsed { get; set; } public double TotalIssueDuration { get; set; } public double LossTime { get; set; } public double UtilizationPercent { get; set; } }
    public class MachinePerformanceData { public double TimeUsed { get; set; } public double Utilization { get; set; } public double IssueDuration { get; set; } public double LossTime { get; set; } }
    public class DailyMachineData { public DateTime Date { get; set; } public string DateLabel { get; set; } = string.Empty; public Dictionary<int, double> UsedTimePerShift { get; set; } = new Dictionary<int, double>(); public Dictionary<int, List<MachineIssue>> IssuesPerShift { get; set; } = new Dictionary<int, List<MachineIssue>>(); }
    public class MachineIssue { public string Type { get; set; } = string.Empty; public double Duration { get; set; } }
    public class SaveRecapPayload { public string Date { get; set; } = string.Empty; public List<RecapLineData> Lines { get; set; } = new List<RecapLineData>(); }
    public class RecapLineData { public string Machine { get; set; } = string.Empty; public List<RecapModelData> Models { get; set; } = new List<RecapModelData>(); public RecapMachinePerformance MachinePerformance { get; set; } = new RecapMachinePerformance(); }
    public class RecapModelData { public List<RecapIssueData> Issues { get; set; } = new List<RecapIssueData>(); }
    public class RecapIssueData { public string Type { get; set; } = string.Empty; public double Duration { get; set; } }
    public class RecapMachinePerformance { public double TimeUsed { get; set; } public double IssueDuration { get; set; } public double LossTime { get; set; } public double OeeScore { get; set; } public double Availability { get; set; } public double PerformanceFactor { get; set; } public double Quality { get; set; } }
}