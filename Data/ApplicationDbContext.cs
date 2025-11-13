using backend.Models;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;

namespace backend.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        // --- Daftar Tabel di Database ---
        public DbSet<Machine> Machines { get; set; }
        public DbSet<ProductionReport> ProductionReports { get; set; }
        public DbSet<Line> Lines { get; set; }
        public DbSet<Model> Models { get; set; }
        public DbSet<Issue> Issues { get; set; }
        public DbSet<PcbModel> PcbModels { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // --- Aturan Main untuk Setiap Tabel ---

            // 1. Aturan untuk ProductionReport (dan relasinya)
            modelBuilder.Entity<ProductionReport>(entity =>
            {
                entity.Property(e => e.Performance)
                    .HasConversion(
                        v => JsonSerializer.Serialize(v, JsonSerializerOptions.Default),
                        v => JsonSerializer.Deserialize<Performance>(v, JsonSerializerOptions.Default));
                entity.HasMany(e => e.Lines).WithOne().OnDelete(DeleteBehavior.Cascade);
            });

            // 2. Aturan untuk Line (dan relasinya)
            modelBuilder.Entity<Line>(entity =>
            {
                entity.Property(e => e.MachinePerformance)
                    .HasConversion(
                        v => JsonSerializer.Serialize(v, JsonSerializerOptions.Default),
                        v => JsonSerializer.Deserialize<MachinePerformance>(v, JsonSerializerOptions.Default));
                entity.HasMany(e => e.Models).WithOne().OnDelete(DeleteBehavior.Cascade);
            });

            // 3. Aturan untuk Model (dan relasinya)
            modelBuilder.Entity<Model>(entity =>
            {
                entity.HasMany(e => e.Issues).WithOne().OnDelete(DeleteBehavior.Cascade);
            });

            // 4. Konfigurasi standar
            modelBuilder.Entity<Issue>().HasKey(e => e.Id);
            modelBuilder.Entity<Machine>().HasKey(e => e.MachineId);
            
// ======================================================================
// 5. MENGISI DATA AWAL (SEEDING) UNTUK TABEL PcbModels (FINAL DATA)
// ======================================================================
modelBuilder.Entity<PcbModel>().HasData(
    new PcbModel { Id = 1, ModelCode = "RF-P50DGC /GU /GT /PR /LJ-S", ProductGroup = "Audio", Multiplier = 6, ProcessTimesJson = "{ \"JVK 02\": 0.14, \"JVK 03\": 0.14, \"RH\": 0.13, \"SMT 01\": 0.35211, \"SMT 02\": 0.155, \"SMT 03\": 0.155 }" },
    new PcbModel { Id = 2, ModelCode = "RF-P50DEG", ProductGroup = "Audio", Multiplier = 4, ProcessTimesJson = "{ \"JVK 02\": 0.14, \"JVK 03\": 0.14, \"RH\": 0.13, \"SMT 01\": 0.39673, \"SMT 02\": 0.165, \"SMT 03\": 0.165 }" },
    new PcbModel { Id = 3, ModelCode = "RF-P50DPP-S", ProductGroup = "Audio", Multiplier = 4, ProcessTimesJson = "{ \"JVK 02\": 0.14, \"JVK 03\": 0.14, \"RH\": 0.13, \"SMT 01\": 0.37345, \"SMT 02\": 0.155, \"SMT 03\": 0.155 }" },
    new PcbModel { Id = 4, ModelCode = "RF-P55-S", ProductGroup = "Audio", Multiplier = 4, ProcessTimesJson = "{ \"JVK 02\": 0.14, \"JVK 03\": 0.14, \"RH\": 0.109, \"SMT 01\": 0.315, \"SMT 02\": 0.155, \"SMT 03\": 0.155 }" },
    new PcbModel { Id = 5, ModelCode = "RF-P155-S", ProductGroup = "Audio", Multiplier = 4, ProcessTimesJson = "{ \"JVK 02\": 0.14, \"JVK 03\": 0.14, \"RH\": 0.109, \"SMT 01\": 0.3783, \"SMT 02\": 0.165, \"SMT 03\": 0.165 }" },
    new PcbModel { Id = 6, ModelCode = "RF-P150DBAGA /GC", ProductGroup = "Audio", Multiplier = 4, ProcessTimesJson = "{ \"JVK 02\": 0.14, \"JVK 03\": 0.14, \"RH\": 0.1089, \"SMT 01\": 0.36375, \"SMT 02\": 0.165, \"SMT 03\": 0.165 }" },
    new PcbModel { Id = 7, ModelCode = "RF-P150DEG", ProductGroup = "Audio", Multiplier = 4, ProcessTimesJson = "{ \"JVK 02\": 0.14, \"JVK 03\": 0.14, \"RH\": 0.1089, \"SMT 01\": 0.37345, \"SMT 02\": 0.155, \"SMT 03\": 0.155 }" },
    new PcbModel { Id = 8, ModelCode = "RF-P150DGS", ProductGroup = "Audio", Multiplier = 4, ProcessTimesJson = "{ \"JVK 02\": 0.14, \"JVK 03\": 0.14, \"RH\": 0.1089, \"SMT 01\": 0.37345, \"SMT 02\": 0.155, \"SMT 03\": 0.155 }" },
    new PcbModel { Id = 9, ModelCode = "RF-P150DPP-S", ProductGroup = "Audio", Multiplier = 4, ProcessTimesJson = "{ \"JVK 02\": 0.14, \"JVK 03\": 0.14, \"RH\": 0.1089, \"SMT 01\": 0.37345, \"SMT 02\": 0.155, \"SMT 03\": 0.155 }" },
    new PcbModel { Id = 10, ModelCode = "RF-2400DEG /EB /EE", ProductGroup = "Audio", Multiplier = 6, ProcessTimesJson = "{ \"JVK 02\": 0.14, \"JVK 03\": 0.14, \"RH\": 0.108, \"SMT 01\": 0.34, \"SMT 02\": 0.163, \"SMT 03\": 0.163 }" },
    new PcbModel { Id = 11, ModelCode = "RF-2400DGN /LJ6", ProductGroup = "Audio", Multiplier = 6, ProcessTimesJson = "{ \"JVK 02\": 0.14, \"JVK 03\": 0.14, \"RH\": 0.1584, \"SMT 01\": 0.244, \"SMT 02\": 0.163, \"SMT 03\": 0.163 }" },
    new PcbModel { Id = 12, ModelCode = "RF-2400DPC /DP", ProductGroup = "Audio", Multiplier = 6, ProcessTimesJson = "{ \"JVK 02\": 0.14, \"JVK 03\": 0.14, \"RH\": 0.1584, \"SMT 01\": 0.276, \"SMT 02\": 0.143, \"SMT 03\": 0.143 }" },
    new PcbModel { Id = 13, ModelCode = "RF-2400DGT", ProductGroup = "Audio", Multiplier = 6, ProcessTimesJson = "{ \"JVK 02\": 0.14, \"JVK 03\": 0.14, \"RH\": 0.108, \"SMT 01\": 0.34435, \"SMT 02\": 0.163, \"SMT 03\": 0.163 }" },
    new PcbModel { Id = 14, ModelCode = "RF-2450-S", ProductGroup = "Audio", Multiplier = 6, ProcessTimesJson = "{ \"JVK 02\": 0.14, \"JVK 03\": 0.14, \"RH\": 0.109, \"SMT 01\": 0.264, \"SMT 02\": 0.143, \"SMT 03\": 0.143 }" },
    new PcbModel { Id = 15, ModelCode = "R-2255-S", ProductGroup = "Audio", Multiplier = 6, ProcessTimesJson = "{ \"JVK 02\": 0.14, \"JVK 03\": 0.14, \"RH\": 0.109, \"SMT 01\": 0.2231, \"SMT 02\": 0.143, \"SMT 03\": 0.143 }" },
    new PcbModel { Id = 16, ModelCode = "REF_PASTA [1st_CM+RH 100V]1", ProductGroup = "Refrigerator", Multiplier = 2, ProcessTimesJson = "{ \"JVK 02\": 0.124, \"JVK 03\": 0.124, \"AVK\": 0.1, \"RH\": 0.0891, \"SMT 01\": 0.5201916, \"SMT 02\": 0.26, \"SMT 03\": 0.26 }" },
    new PcbModel { Id = 17, ModelCode = "REF_PASTA [2nd_CM+RH 100V]2", ProductGroup = "Refrigerator", Multiplier = 2, ProcessTimesJson = "{ \"JVK 02\": 0.124, \"JVK 03\": 0.124, \"AVK\": 0.1, \"RH\": 0.0891, \"SMT 01\": 0.5201916, \"SMT 02\": 0.26, \"SMT 03\": 0.26 }" },
    new PcbModel { Id = 18, ModelCode = "ARBPC2C00670", ProductGroup = "Refrigerator", Multiplier = 6, ProcessTimesJson = "{ \"JVK 02\": 0.097166667, \"JVK 03\": 0.097166667, \"AVK\": 0.047666667, \"RH\": 0.091666667, \"SMT 01\": 0.47724, \"SMT 02\": 0.146666667, \"SMT 03\": 0.146666667 }" },
    new PcbModel { Id = 19, ModelCode = "BB220", ProductGroup = "Refrigerator", Multiplier = 4, ProcessTimesJson = "{ \"JVK 02\": 0.24, \"JVK 03\": 0.24, \"RH\": 0.8, \"SMT 02\": 0.469, \"SMT 03\": 0.469 }" },
    new PcbModel { Id = 20, ModelCode = "BB240", ProductGroup = "Refrigerator", Multiplier = 4, ProcessTimesJson = "{ \"JVK 02\": 0.24, \"JVK 03\": 0.24, \"RH\": 0.8, \"SMT 02\": 0.579, \"SMT 03\": 0.579 }" },
    new PcbModel { Id = 21, ModelCode = "FREEZER [BG-188654]", ProductGroup = "Refrigerator", Multiplier = 6, ProcessTimesJson = "{ \"JVK 02\": 0.097166667, \"JVK 03\": 0.097166667, \"AVK\": 0.047666667, \"RH\": 0.091666667, \"SMT 01\": 0.47724, \"SMT 02\": 0.146666667, \"SMT 03\": 0.146666667 }" },
    new PcbModel { Id = 22, ModelCode = "LED FREEZER [BG-188642]", ProductGroup = "Refrigerator", Multiplier = 18, ProcessTimesJson = "{ \"RH\": 0.1914, \"SMT 01\": 0.06499 }" },
    new PcbModel { Id = 23, ModelCode = "LED ARBPLLA00750 <RH>", ProductGroup = "Refrigerator", Multiplier = 14, ProcessTimesJson = "{ \"AVK\": 0.047666667, \"RH\": 0.1914 }" },
    new PcbModel { Id = 24, ModelCode = "REF-LED-2 (BG-181293)", ProductGroup = "Refrigerator", Multiplier = 14, ProcessTimesJson = "{ \"AVK\": 0.0484, \"RH\": 0.0198 }" },
    new PcbModel { Id = 25, ModelCode = "REF-LED-3 (BG-319100)", ProductGroup = "Refrigerator", Multiplier = 14, ProcessTimesJson = "{ \"AVK\": 0.0484, \"RH\": 0.0198 }" },
    new PcbModel { Id = 26, ModelCode = "LED-BB [ARBPLLA00302]", ProductGroup = "Refrigerator", Multiplier = 1, ProcessTimesJson = "{ \"SMT 02\": 0.069055556, \"SMT 03\": 0.069055556 }" },
    new PcbModel { Id = 27, ModelCode = "VR-BB [ARBP01A00260]", ProductGroup = "Refrigerator", Multiplier = 42, ProcessTimesJson = "{ \"AVK\": 0.018 }" },
    new PcbModel { Id = 28, ModelCode = "REF_PASTA [1st_CM+RH 200V]", ProductGroup = "Refrigerator", Multiplier = 2, ProcessTimesJson = "{ \"SMT 02\": 0.2, \"SMT 03\": 0.2 }" },
    new PcbModel { Id = 29, ModelCode = "REF_PASTA [2nd_CM+RH 200V]", ProductGroup = "Refrigerator", Multiplier = 2, ProcessTimesJson = "{ \"RH\": 0.3762, \"SMT 02\": 0.2, \"SMT 03\": 0.2 }" },
    new PcbModel { Id = 30, ModelCode = "ACXA73-37130", ProductGroup = "AC", Multiplier = 2, ProcessTimesJson = "{ \"JVK 02\": 0.264, \"JVK 03\": 0.404, \"AVK\": 0.083, \"RH\": 0.175, \"SMT 01\": 0.6305, \"SMT 02\": 0.354, \"SMT 03\": 0.354 }" },
    new PcbModel { Id = 31, ModelCode = "LED-22280 [ACXE39C01000ID]", ProductGroup = "AC", Multiplier = 10, ProcessTimesJson = "{ \"RH\": 0.1, \"SMT 01\": 0.048, \"SMT 02\": 0.067, \"SMT 03\": 0.067 }" },
    new PcbModel { Id = 32, ModelCode = "LED-44600 (ACXE39C01500)", ProductGroup = "AC", Multiplier = 10, ProcessTimesJson = "{ \"RH\": 0.1, \"SMT 01\": 0.06499, \"SMT 02\": 0.067, \"SMT 03\": 0.067 }" },
    new PcbModel { Id = 33, ModelCode = "RF-NA35R-S <A>", ProductGroup = "Audio", Multiplier = 3, ProcessTimesJson = "{ \"SMT 02\": 0.32, \"SMT 03\": 0.32 }" },
    new PcbModel { Id = 34, ModelCode = "RF-NA35R-S <B>", ProductGroup = "Audio", Multiplier = 3, ProcessTimesJson = "{ \"SMT 02\": 0.14, \"SMT 03\": 0.14 }" },
    new PcbModel { Id = 35, ModelCode = "RF-D10 [KEY/SUB-MAIN]", ProductGroup = "Audio", Multiplier = 1, ProcessTimesJson = "{ \"JVK 02\": 0.264, \"JVK 03\": 0.264, \"RH\": 0.314, \"SMT 01\": 0.42, \"SMT 02\": 0.363, \"SMT 03\": 0.363 }" },
    new PcbModel { Id = 36, ModelCode = "RF-D10 <A> [MAIN]", ProductGroup = "Audio", Multiplier = 8, ProcessTimesJson = "{ \"SMT 02\": 0.171, \"SMT 03\": 0.171 }" },
    new PcbModel { Id = 37, ModelCode = "RF-D10 <B> [MAIN]", ProductGroup = "Audio", Multiplier = 8, ProcessTimesJson = "{ \"SMT 02\": 0.352, \"SMT 03\": 0.352 }" },
    new PcbModel { Id = 38, ModelCode = "RF-U156-S", ProductGroup = "Audio", Multiplier = 2, ProcessTimesJson = "{ \"JVK 02\": 0.1, \"JVK 03\": 0.1, \"RH\": 0.1386, \"SMT 01\": 0.432, \"SMT 02\": 0.302, \"SMT 03\": 0.302 }" },
    new PcbModel { Id = 39, ModelCode = "RF-5270LJK", ProductGroup = "Audio", Multiplier = 2, ProcessTimesJson = "{ \"JVK 02\": 0.033, \"JVK 03\": 0.033, \"RH\": 0.1485, \"SMT 01\": 0.314765, \"SMT 02\": 0.267, \"SMT 03\": 0.267 }" },
    new PcbModel { Id = 40, ModelCode = "RF-562DD2GCK1", ProductGroup = "Audio", Multiplier = 2, ProcessTimesJson = "{ \"JVK 02\": 0.2563, \"JVK 03\": 0.2563, \"RH\": 0.1914, \"SMT 01\": 0.48, \"SMT 02\": 0.45, \"SMT 03\": 0.45 }" },
    new PcbModel { Id = 41, ModelCode = "ACXA73-50470", ProductGroup = "AC", Multiplier = 2, ProcessTimesJson = "{ \"JVK 02\": 0.264, \"JVK 03\": 0.404, \"AVK\": 0.083, \"RH\": 0.175, \"SMT 01\": 0.6305, \"SMT 02\": 0.35, \"SMT 03\": 0.35 }" },
    new PcbModel { Id = 42, ModelCode = "ACXA73-50480", ProductGroup = "AC", Multiplier = 2, ProcessTimesJson = "{ \"JVK 02\": 0.264, \"JVK 03\": 0.404, \"AVK\": 0.083, \"RH\": 0.175, \"SMT 01\": 0.6305, \"SMT 02\": 0.35, \"SMT 03\": 0.35 }" },
    new PcbModel { Id = 43, ModelCode = "LED-49380", ProductGroup = "AC", Multiplier = 10, ProcessTimesJson = "{ \"RH\": 0.1, \"SMT 01\": 0.06499, \"SMT 02\": 0.067, \"SMT 03\": 0.067 }" },
    new PcbModel { Id = 44, ModelCode = "ACXA73-52800", ProductGroup = "AC", Multiplier = 2, ProcessTimesJson = "{ \"JVK 02\": 0.264, \"JVK 03\": 0.404, \"AVK\": 0.083, \"RH\": 0.175, \"SMT 01\": 0.6305, \"SMT 02\": 0.35, \"SMT 03\": 0.35 }" },
    new PcbModel { Id = 45, ModelCode = "ACXA73-52810", ProductGroup = "AC", Multiplier = 2, ProcessTimesJson = "{ \"JVK 02\": 0.264, \"JVK 03\": 0.404, \"AVK\": 0.083, \"RH\": 0.175, \"SMT 01\": 0.6305, \"SMT 02\": 0.35, \"SMT 03\": 0.35 }" },
    new PcbModel { Id = 46, ModelCode = "LED-49390", ProductGroup = "AC", Multiplier = 10, ProcessTimesJson = "{ \"RH\": 0.1, \"SMT 01\": 0.06499, \"SMT 02\": 0.067, \"SMT 03\": 0.067 }" },
    new PcbModel { Id = 47, ModelCode = "1st_ACXA73-50110", ProductGroup = "AC", Multiplier = 2, ProcessTimesJson = "{ \"JVK 02\": 0.264, \"JVK 03\": 0.404, \"AVK\": 0.083, \"RH\": 0.175, \"SMT 01\": 0.6305, \"SMT 02\": 0.35, \"SMT 03\": 0.35 }" },
    new PcbModel { Id = 48, ModelCode = "2nd_ACXA73-50110", ProductGroup = "AC", Multiplier = 2, ProcessTimesJson = "{ \"JVK 02\": 0.264, \"JVK 03\": 0.404, \"AVK\": 0.083, \"RH\": 0.175, \"SMT 01\": 0.679, \"SMT 02\": 0.4, \"SMT 03\": 0.4 }" },
    new PcbModel { Id = 49, ModelCode = "1st_ACXA73-50120", ProductGroup = "AC", Multiplier = 2, ProcessTimesJson = "{ \"JVK 02\": 0.264, \"JVK 03\": 0.404, \"AVK\": 0.083, \"RH\": 0.175, \"SMT 01\": 0.6305, \"SMT 02\": 0.35, \"SMT 03\": 0.35 }" },
    new PcbModel { Id = 50, ModelCode = "2nd_ACXA73-50120", ProductGroup = "AC", Multiplier = 2, ProcessTimesJson = "{ \"JVK 02\": 0.264, \"JVK 03\": 0.404, \"AVK\": 0.083, \"RH\": 0.175, \"SMT 01\": 0.679, \"SMT 02\": 0.4, \"SMT 03\": 0.4 }" },
    new PcbModel { Id = 51, ModelCode = "LED-44600 (ACXE39C01500)", ProductGroup = "AC", Multiplier = 10, ProcessTimesJson = "{ \"RH\": 0.1, \"SMT 01\": 0.06499, \"SMT 02\": 0.067, \"SMT 03\": 0.067 }" },
    new PcbModel { Id = 52, ModelCode = "ACXA73-48700", ProductGroup = "AC", Multiplier = 2, ProcessTimesJson = "{ \"JVK 02\": 0.264, \"JVK 03\": 0.404, \"AVK\": 0.083, \"RH\": 0.175, \"SMT 01\": 0.679, \"SMT 02\": 0.4, \"SMT 03\": 0.4 }" },
    new PcbModel { Id = 53, ModelCode = "ACXA73-53420", ProductGroup = "AC", Multiplier = 2, ProcessTimesJson = "{ \"JVK 02\": 0.264, \"JVK 03\": 0.404, \"AVK\": 0.083, \"RH\": 0.175, \"SMT 01\": 0.6305, \"SMT 02\": 0.35, \"SMT 03\": 0.35 }" },
    new PcbModel { Id = 54, ModelCode = "ACXA73-52820", ProductGroup = "AC", Multiplier = 2, ProcessTimesJson = "{ \"JVK 02\": 0.264, \"JVK 03\": 0.404, \"AVK\": 0.083, \"RH\": 0.175, \"SMT 01\": 0.6305, \"SMT 02\": 0.35, \"SMT 03\": 0.35 }" },
    new PcbModel { Id = 55, ModelCode = "ACXA73-52830", ProductGroup = "AC", Multiplier = 2, ProcessTimesJson = "{ \"RH\": 0.1, \"SMT 01\": 0.06499, \"SMT 02\": 0.4, \"SMT 03\": 0.4 }" },
    new PcbModel { Id = 56, ModelCode = "ACXA73-51410", ProductGroup = "AC", Multiplier = 2, ProcessTimesJson = "{ \"JVK 02\": 0.264, \"JVK 03\": 0.404, \"AVK\": 0.083, \"RH\": 0.175, \"SMT 01\": 0.6305, \"SMT 02\": 0.35, \"SMT 03\": 0.35 }" },
    new PcbModel { Id = 57, ModelCode = "LED-51390", ProductGroup = "AC", Multiplier = 10, ProcessTimesJson = "{ \"RH\": 0.1, \"SMT 01\": 0.06499, \"SMT 02\": 0.067, \"SMT 03\": 0.067 }" },
    new PcbModel { Id = 58, ModelCode = "LED-51400", ProductGroup = "AC", Multiplier = 10, ProcessTimesJson = "{ \"RH\": 0.1, \"SMT 01\": 0.06499, \"SMT 02\": 0.067, \"SMT 03\": 0.067 }" },
    new PcbModel { Id = 59, ModelCode = "ARBGBA301650", ProductGroup = "Refrigerator", Multiplier = 6, ProcessTimesJson = "{ \"JVK 02\": 0.097166667, \"JVK 03\": 0.097166667, \"AVK\": 0.047666667, \"RH\": 0.091666667, \"SMT 01\": 0.47724, \"SMT 02\": 0.146666667, \"SMT 03\": 0.146666667 }" },
    new PcbModel { Id = 60, ModelCode = "BG-213400", ProductGroup = "Refrigerator", Multiplier = 14, ProcessTimesJson = "{ \"AVK\": 0.0484, \"RH\": 0.0198 }" },
    new PcbModel { Id = 61, ModelCode = "LED-BB [ARBPLLA00302]", ProductGroup = "Refrigerator", Multiplier = 54, ProcessTimesJson = "{ \"SMT 02\": 0.069, \"SMT 03\": 0.069 }" }
);
        }
    }
}