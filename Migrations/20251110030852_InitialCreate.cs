using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace backend.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Machines",
                columns: table => new
                {
                    MachineId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    MachineName = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Machines", x => x.MachineId);
                });

            migrationBuilder.CreateTable(
                name: "PcbModels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ModelCode = table.Column<string>(type: "TEXT", nullable: false),
                    ProductGroup = table.Column<string>(type: "TEXT", nullable: false),
                    Multiplier = table.Column<double>(type: "REAL", nullable: false),
                    ProcessTimesJson = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PcbModels", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProductionReports",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Date = table.Column<string>(type: "TEXT", nullable: true),
                    Shift = table.Column<int>(type: "INTEGER", nullable: false),
                    Performance = table.Column<string>(type: "TEXT", nullable: true),
                    SavedTimestamp = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductionReports", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PerformanceLog",
                columns: table => new
                {
                    LogId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    MachineId = table.Column<int>(type: "INTEGER", nullable: false),
                    LogDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UsedTimeMinutes = table.Column<int>(type: "INTEGER", nullable: false),
                    LossTimeMinutes = table.Column<int>(type: "INTEGER", nullable: false),
                    Notes = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PerformanceLog", x => x.LogId);
                    table.ForeignKey(
                        name: "FK_PerformanceLog_Machines_MachineId",
                        column: x => x.MachineId,
                        principalTable: "Machines",
                        principalColumn: "MachineId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Lines",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Machine = table.Column<string>(type: "TEXT", nullable: true),
                    Color = table.Column<string>(type: "TEXT", nullable: true),
                    MachinePerformance = table.Column<string>(type: "TEXT", nullable: true),
                    ProductionReportId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lines", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Lines_ProductionReports_ProductionReportId",
                        column: x => x.ProductionReportId,
                        principalTable: "ProductionReports",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Models",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    ModelCode = table.Column<string>(type: "TEXT", nullable: true),
                    Components = table.Column<int>(type: "INTEGER", nullable: false),
                    MachineTime = table.Column<double>(type: "REAL", nullable: false),
                    Plan = table.Column<double>(type: "REAL", nullable: false),
                    Result = table.Column<double>(type: "REAL", nullable: false),
                    TimeUsed = table.Column<double>(type: "REAL", nullable: false),
                    PercentUsed = table.Column<double>(type: "REAL", nullable: false),
                    Note = table.Column<string>(type: "TEXT", nullable: true),
                    LineId = table.Column<int>(type: "INTEGER", nullable: false),
                    PanelResult = table.Column<double>(type: "REAL", nullable: false),
                    Multiplier = table.Column<double>(type: "REAL", nullable: false),
                    SelectedPcbGroup = table.Column<string>(type: "TEXT", nullable: true),
                    IsSaved = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Models", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Models_Lines_LineId",
                        column: x => x.LineId,
                        principalTable: "Lines",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Issues",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Type = table.Column<string>(type: "TEXT", nullable: true),
                    Duration = table.Column<double>(type: "REAL", nullable: false),
                    ModelId = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Issues", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Issues_Models_ModelId",
                        column: x => x.ModelId,
                        principalTable: "Models",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "PcbModels",
                columns: new[] { "Id", "ModelCode", "Multiplier", "ProcessTimesJson", "ProductGroup" },
                values: new object[,]
                {
                    { 1, "RF-P50DGC /GU /GT /PR /LJ-S", 6.0, "{ \"JVK 02\": 0.140, \"JVK 03\": 0.140, \"RH\": 0.130, \"SMT 01\": 0.352, \"SMT 02\": 0.155, \"SMT 03\": 0.155 }", "Audio" },
                    { 2, "RF-P50DEG", 4.0, "{ \"JVK 02\": 0.140, \"JVK 03\": 0.140, \"RH\": 0.130, \"SMT 01\": 0.397, \"SMT 02\": 0.165, \"SMT 03\": 0.165 }", "Audio" },
                    { 3, "RF-P50DPP-S", 4.0, "{ \"JVK 02\": 0.140, \"JVK 03\": 0.140, \"RH\": 0.130, \"SMT 01\": 0.373, \"SMT 02\": 0.155, \"SMT 03\": 0.155 }", "Audio" },
                    { 4, "RF-P55-S", 4.0, "{ \"JVK 02\": 0.140, \"JVK 03\": 0.140, \"RH\": 0.109, \"SMT 01\": 0.315, \"SMT 02\": 0.155, \"SMT 03\": 0.155 }", "Audio" },
                    { 5, "RF-P155-S", 4.0, "{ \"JVK 02\": 0.140, \"JVK 03\": 0.140, \"RH\": 0.109, \"SMT 01\": 0.378, \"SMT 02\": 0.165, \"SMT 03\": 0.165 }", "Audio" },
                    { 6, "RF-P150DBAGA /GC", 4.0, "{ \"JVK 02\": 0.140, \"JVK 03\": 0.140, \"RH\": 0.109, \"SMT 01\": 0.364, \"SMT 02\": 0.165, \"SMT 03\": 0.165 }", "Audio" },
                    { 7, "RF-P150DEG", 4.0, "{ \"JVK 02\": 0.140, \"JVK 03\": 0.140, \"RH\": 0.109, \"SMT 01\": 0.373, \"SMT 02\": 0.155, \"SMT 03\": 0.155 }", "Audio" },
                    { 8, "RF-P150DGS", 4.0, "{ \"JVK 02\": 0.140, \"JVK 03\": 0.140, \"RH\": 0.109, \"SMT 01\": 0.373, \"SMT 02\": 0.155, \"SMT 03\": 0.155 }", "Audio" },
                    { 9, "RF-P150DPP-S", 4.0, "{ \"JVK 02\": 0.140, \"JVK 03\": 0.140, \"RH\": 0.109, \"SMT 01\": 0.373, \"SMT 02\": 0.155, \"SMT 03\": 0.155 }", "Audio" },
                    { 10, "RF-NA35R-S <A>", 3.0, "{ \"SMT 02\": 0.320, \"SMT 03\": 0.320 }", "Audio" },
                    { 11, "RF-NA35R-S <B>", 3.0, "{ \"SMT 02\": 0.140, \"SMT 03\": 0.140 }", "Audio" },
                    { 12, "RF-D10 <A> [MAIN]", 8.0, "{ \"SMT 02\": 0.171, \"SMT 03\": 0.171 }", "Audio" },
                    { 13, "RF-D10 <B> [MAIN]", 8.0, "{ \"SMT 02\": 0.352, \"SMT 03\": 0.352 }", "Audio" },
                    { 14, "RF-562DD2GCK1", 2.0, "{ \"JVK 02\": 0.256, \"JVK 03\": 0.256, \"RH\": 0.191, \"SMT 01\": 0.480, \"SMT 02\": 0.450, \"SMT 03\": 0.450 }", "Audio" },
                    { 15, "RF-D10 [KEY/SUB-MAIN]", 1.0, "{ \"JVK 02\": 0.264, \"JVK 03\": 0.264, \"RH\": 0.314, \"SMT 01\": 0.420, \"SMT 02\": 0.363, \"SMT 03\": 0.363 }", "Audio" },
                    { 16, "RF-U156-S", 2.0, "{ \"JVK 02\": 0.100, \"JVK 03\": 0.100, \"RH\": 0.139, \"SMT 01\": 0.432, \"SMT 02\": 0.302, \"SMT 03\": 0.302 }", "Audio" },
                    { 17, "RF-5270LJK", 2.0, "{ \"JVK 02\": 0.033, \"JVK 03\": 0.033, \"RH\": 0.149, \"SMT 01\": 0.315, \"SMT 02\": 0.267, \"SMT 03\": 0.267 }", "Audio" },
                    { 18, "RF-2400DEG /EB /EE", 6.0, "{ \"JVK 02\": 0.140, \"JVK 03\": 0.140, \"RH\": 0.108, \"SMT 01\": 0.340, \"SMT 02\": 0.163, \"SMT 03\": 0.163 }", "Audio" },
                    { 19, "RF-2400DGN /LJ", 6.0, "{ \"JVK 02\": 0.140, \"JVK 03\": 0.140, \"RH\": 0.158, \"SMT 01\": 0.244, \"SMT 02\": 0.163, \"SMT 03\": 0.163 }", "Audio" },
                    { 20, "RF-2400DPC /DP", 6.0, "{ \"JVK 02\": 0.140, \"JVK 03\": 0.140, \"RH\": 0.158, \"SMT 01\": 0.276, \"SMT 02\": 0.143, \"SMT 03\": 0.143 }", "Audio" },
                    { 21, "RF-2400DGT", 6.0, "{ \"JVK 02\": 0.140, \"JVK 03\": 0.140, \"RH\": 0.108, \"SMT 01\": 0.344, \"SMT 02\": 0.163, \"SMT 03\": 0.163 }", "Audio" },
                    { 22, "RF-2450-S", 6.0, "{ \"JVK 02\": 0.140, \"JVK 03\": 0.140, \"RH\": 0.109, \"SMT 01\": 0.264, \"SMT 02\": 0.143, \"SMT 03\": 0.143 }", "Audio" },
                    { 23, "R-2255-S", 6.0, "{ \"JVK 02\": 0.140, \"JVK 03\": 0.140, \"RH\": 0.109, \"SMT 01\": 0.223, \"SMT 02\": 0.143, \"SMT 03\": 0.143 }", "Audio" },
                    { 24, "REF_PASTA [1st_CM+RH 100V]", 2.0, "{ \"SMT 02\": 0.260, \"SMT 03\": 0.260 }", "Refrigerator" },
                    { 25, "REF_PASTA [2nd_CM+RH 100V]", 2.0, "{ \"SMT 02\": 0.260, \"SMT 03\": 0.260 }", "Refrigerator" },
                    { 26, "REF_PASTA [1st_CM+RH 200V]", 2.0, "{ \"SMT 02\": 0.260, \"SMT 03\": 0.260 }", "Refrigerator" },
                    { 27, "REF_PASTA [2nd_CM+RH 200V]", 2.0, "{ \"RH\": 0.376 }", "Refrigerator" },
                    { 28, "ARBPC2C00670", 6.0, "{ \"JVK 02\": 0.097, \"JVK 03\": 0.097, \"AVK\": 0.048, \"RH\": 0.092, \"SMT 01\": 0.477, \"SMT 02\": 0.147, \"SMT 03\": 0.147 }", "Refrigerator" },
                    { 29, "BB220", 4.0, "{ \"JVK 02\": 0.240, \"JVK 03\": 0.240, \"RH\": 0.800, \"SMT 02\": 0.469, \"SMT 03\": 0.469 }", "Refrigerator" },
                    { 30, "BB240", 4.0, "{ \"JVK 02\": 0.240, \"JVK 03\": 0.240, \"RH\": 0.800, \"SMT 02\": 0.579, \"SMT 03\": 0.579 }", "Refrigerator" },
                    { 31, "FREEZER [BG-188654]", 6.0, "{ \"JVK 02\": 0.097, \"JVK 03\": 0.097, \"AVK\": 0.048, \"RH\": 0.092, \"SMT 01\": 0.477, \"SMT 02\": 0.147, \"SMT 03\": 0.147 }", "Refrigerator" },
                    { 32, "LED FREEZER [BG-188642]", 18.0, "{ \"RH\": 0.191, \"SMT 01\": 0.065 }", "Refrigerator" },
                    { 33, "LED ARBPLLA00750 <RH>", 1.0, "{ \"AVK\": 0.048, \"RH\": 0.191 }", "Refrigerator" },
                    { 34, "REF-LED-2 (BG-181293)", 1.0, "{ \"AVK\": 0.048, \"RH\": 0.020 }", "Refrigerator" },
                    { 35, "REF-LED-3 (BG-319100)", 1.0, "{ \"AVK\": 0.048, \"RH\": 0.020 }", "Refrigerator" },
                    { 36, "LED-BB [ARBPLLA00302]", 1.0, "{ \"SMT 02\": 0.069, \"SMT 03\": 0.069 }", "Refrigerator" },
                    { 37, "VR-BB [ARBP01A00260]", 1.0, "{ \"AVK\": 0.018 }", "Refrigerator" },
                    { 38, "ARBGBA301650", 6.0, "{ \"JVK 02\": 0.097, \"JVK 03\": 0.097, \"AVK\": 0.048, \"RH\": 0.092, \"SMT 01\": 0.477, \"SMT 02\": 0.147, \"SMT 03\": 0.147 }", "Refrigerator" },
                    { 39, "BG-213400", 14.0, "{ \"AVK\": 0.048, \"RH\": 0.020 }", "Refrigerator" },
                    { 40, "ACXA73-37130", 2.0, "{ \"JVK 02\": 0.264, \"JVK 03\": 0.404, \"AVK\": 0.083, \"RH\": 0.175, \"SMT 01\": 0.631, \"SMT 02\": 0.350, \"SMT 03\": 0.350 }", "AC" },
                    { 41, "ACXA73-50470", 2.0, "{ \"JVK 02\": 0.264, \"JVK 03\": 0.404, \"AVK\": 0.083, \"RH\": 0.175, \"SMT 01\": 0.631, \"SMT 02\": 0.350, \"SMT 03\": 0.350 }", "AC" },
                    { 42, "ACXA73-50480", 2.0, "{ \"JVK 02\": 0.264, \"JVK 03\": 0.404, \"AVK\": 0.083, \"RH\": 0.175, \"SMT 01\": 0.631, \"SMT 02\": 0.350, \"SMT 03\": 0.350 }", "AC" },
                    { 43, "ACXA73-52800", 2.0, "{ \"JVK 02\": 0.264, \"JVK 03\": 0.404, \"AVK\": 0.083, \"RH\": 0.175, \"SMT 01\": 0.631, \"SMT 02\": 0.350, \"SMT 03\": 0.350 }", "AC" },
                    { 44, "ACXA73-52810", 2.0, "{ \"JVK 02\": 0.264, \"JVK 03\": 0.404, \"AVK\": 0.083, \"RH\": 0.175, \"SMT 01\": 0.631, \"SMT 02\": 0.350, \"SMT 03\": 0.350 }", "AC" },
                    { 45, "ACXA73-48700", 2.0, "{ \"JVK 02\": 0.264, \"JVK 03\": 0.404, \"AVK\": 0.083, \"RH\": 0.175, \"SMT 01\": 0.631, \"SMT 02\": 0.350, \"SMT 03\": 0.350 }", "AC" },
                    { 46, "ACXA73-53420", 2.0, "{ \"JVK 02\": 0.264, \"JVK 03\": 0.404, \"AVK\": 0.083, \"RH\": 0.175, \"SMT 01\": 0.631, \"SMT 02\": 0.350, \"SMT 03\": 0.350 }", "AC" },
                    { 47, "ACXA73-52820", 2.0, "{ \"JVK 02\": 0.264, \"JVK 03\": 0.404, \"AVK\": 0.083, \"RH\": 0.175, \"SMT 01\": 0.631, \"SMT 02\": 0.350, \"SMT 03\": 0.350 }", "AC" },
                    { 48, "ACXA73-52830", 2.0, "{ \"JVK 02\": 0.264, \"JVK 03\": 0.404, \"AVK\": 0.083, \"RH\": 0.175, \"SMT 01\": 0.631, \"SMT 02\": 0.350, \"SMT 03\": 0.350 }", "AC" },
                    { 49, "ACXA73-51410", 2.0, "{ \"JVK 02\": 0.264, \"JVK 03\": 0.404, \"AVK\": 0.083, \"RH\": 0.175, \"SMT 01\": 0.631, \"SMT 02\": 0.350, \"SMT 03\": 0.350 }", "AC" },
                    { 50, "1st_ACXA73-50110", 2.0, "{ \"JVK 02\": 0.264, \"JVK 03\": 0.404, \"AVK\": 0.083, \"RH\": 0.175, \"SMT 01\": 0.631, \"SMT 02\": 0.350, \"SMT 03\": 0.350 }", "AC" },
                    { 51, "2nd_ACXA73-50110", 2.0, "{ \"SMT 02\": 0.400, \"SMT 03\": 0.400 }", "AC" },
                    { 52, "1st_ACXA73-50120", 2.0, "{ \"JVK 02\": 0.264, \"JVK 03\": 0.404, \"AVK\": 0.083, \"RH\": 0.175, \"SMT 01\": 0.631, \"SMT 02\": 0.350, \"SMT 03\": 0.350 }", "AC" },
                    { 53, "2nd_ACXA73-50120", 2.0, "{ \"SMT 02\": 0.400, \"SMT 03\": 0.400 }", "AC" },
                    { 54, "LED-22280 [ACXE39C01000ID]", 10.0, "{ \"RH\": 0.100, \"SMT 01\": 0.048, \"SMT 02\": 0.067, \"SMT 03\": 0.067 }", "AC" },
                    { 55, "LED-44600 (ACXE39C01500)", 10.0, "{ \"RH\": 0.100, \"SMT 01\": 0.065, \"SMT 02\": 0.067, \"SMT 03\": 0.067 }", "AC" },
                    { 56, "LED-49380", 10.0, "{ \"RH\": 0.100, \"SMT 01\": 0.065, \"SMT 02\": 0.067, \"SMT 03\": 0.067 }", "AC" },
                    { 57, "LED-49390", 10.0, "{ \"RH\": 0.100, \"SMT 01\": 0.065, \"SMT 02\": 0.067, \"SMT 03\": 0.067 }", "AC" },
                    { 58, "LED-51390", 10.0, "{ \"RH\": 0.100, \"SMT 01\": 0.065, \"SMT 02\": 0.067, \"SMT 03\": 0.067 }", "AC" },
                    { 59, "LED-51400", 10.0, "{ \"RH\": 0.100, \"SMT 01\": 0.065, \"SMT 02\": 0.067, \"SMT 03\": 0.067 }", "AC" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Issues_ModelId",
                table: "Issues",
                column: "ModelId");

            migrationBuilder.CreateIndex(
                name: "IX_Lines_ProductionReportId",
                table: "Lines",
                column: "ProductionReportId");

            migrationBuilder.CreateIndex(
                name: "IX_Models_LineId",
                table: "Models",
                column: "LineId");

            migrationBuilder.CreateIndex(
                name: "IX_PerformanceLog_MachineId",
                table: "PerformanceLog",
                column: "MachineId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Issues");

            migrationBuilder.DropTable(
                name: "PcbModels");

            migrationBuilder.DropTable(
                name: "PerformanceLog");

            migrationBuilder.DropTable(
                name: "Models");

            migrationBuilder.DropTable(
                name: "Machines");

            migrationBuilder.DropTable(
                name: "Lines");

            migrationBuilder.DropTable(
                name: "ProductionReports");
        }
    }
}
