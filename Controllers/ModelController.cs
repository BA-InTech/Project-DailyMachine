using backend.Data;
using backend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;

namespace backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PcbModelsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public PcbModelsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // --- INI ENDPOINT YANG DIPANGGIL PAS APP PERTAMA KALI LOADING ---
        // GET: api/PcbModels
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PcbModel>>> GetPcbModels()
        {
            return await _context.PcbModels.ToListAsync();
        }
        
        // ========================================================
        // ✅ 1. PERBAIKI "KERTAS PESANAN" (DTO)
        // ========================================================
        public class UpsertProcessTimeDto
        {
            public string ModelCode { get; set; } = string.Empty;
            public string ProductGroup { get; set; } = string.Empty;
            
            // ✅ BUAT 'Machine' JADI 'nullable' (string?)
            // Ini akan memperbaiki error "The Machine field is required."
            public string? Machine { get; set; } 
            
            public double ProcessTime { get; set; } = 0;
            
            // ✅ TAMBAHKAN 'Multiplier' (CAPITY)
            public int Multiplier { get; set; } = 1;
        }

        // --- INI ENDPOINT YANG DIPANGGIL DARI FORM "ADD / UPDATE DATA" ---
        // POST: api/PcbModels/upsert
        [HttpPost("upsert")]
        public async Task<IActionResult> UpsertProcessTime([FromBody] UpsertProcessTimeDto data)
        {
            if (data == null || string.IsNullOrWhiteSpace(data.ModelCode))
            {
                return BadRequest("Data tidak valid.");
            }

            // ========================================================
            // ✅ 2. PERBAIKI LOGIKA "UPSERT"
            // ========================================================
            var modelCodeUpper = data.ModelCode.ToUpper();

            var existingModel = await _context.PcbModels
                .FirstOrDefaultAsync(p => p.ModelCode == modelCodeUpper);

            if (existingModel != null)
            {
                // --- JIKA SUDAH ADA (UPDATE) ---
                
                // 1. Update ProductGroup
                existingModel.ProductGroup = data.ProductGroup;

                // 2. ✅ UPDATE MULTIPLIER (CAPITY)
                existingModel.Multiplier = data.Multiplier;

                // 3. Update ProcessTimesJson
                // Hanya update JSON jika 'Machine' diisi
                if (!string.IsNullOrEmpty(data.Machine))
                {
                    var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                    var processTimes = JsonSerializer.Deserialize<Dictionary<string, double>>(existingModel.ProcessTimesJson, options) 
                                        ?? new Dictionary<string, double>();

                    processTimes[data.Machine] = data.ProcessTime;
                    existingModel.ProcessTimesJson = JsonSerializer.Serialize(processTimes);
                }

                _context.PcbModels.Update(existingModel);
            }
            else
            {
                // --- JIKA BELUM ADA (INSERT BARU) ---
                var processTimes = new Dictionary<string, double>();
                
                // Hanya tambahkan time jika 'Machine' diisi
                if (!string.IsNullOrEmpty(data.Machine))
                {
                    processTimes[data.Machine] = data.ProcessTime;
                }

                var newModel = new PcbModel
                {
                    ModelCode = modelCodeUpper,
                    ProductGroup = data.ProductGroup,
                    // ✅ AMBIL 'Multiplier' DARI DATA, BUKAN '1'
                    Multiplier = data.Multiplier, 
                    ProcessTimesJson = JsonSerializer.Serialize(processTimes)
                };
                await _context.PcbModels.AddAsync(newModel);
            }

            await _context.SaveChangesAsync();

            var resultModel = await _context.PcbModels.FirstAsync(p => p.ModelCode == modelCodeUpper);
            return Ok(resultModel);
        }

        // --- INI ENDPOINT BUAT HAPUS MODEL ---
        // DELETE: api/PcbModels/RF-P50DGC
        [HttpDelete("{modelCode}")]
        public async Task<IActionResult> DeletePcbModel(string modelCode)
        {
            var modelToDelete = await _context.PcbModels
                .FirstOrDefaultAsync(p => p.ModelCode == modelCode);

            if (modelToDelete == null)
            {
                return NotFound("Model tidak ditemukan.");
            }

            _context.PcbModels.Remove(modelToDelete);
            await _context.SaveChangesAsync();
            
            return Ok(new { message = $"Model {modelCode} berhasil dihapus." });
        }
    }
}