using System.ComponentModel.DataAnnotations;
using System.Collections.Generic; // <-- PASTIKAN using ini ada

namespace backend.Models
{
    public class Machine
    {
        [Key]
        public int MachineId { get; set; }

        [Required]
        [StringLength(50)]
        // PERBAIKAN: Tambahkan '= null!' untuk memberitahu C# bahwa EF akan mengisinya
        public string MachineName { get; set; } = null!; 

        // PERBAIKAN: Inisialisasi koleksi agar tidak pernah null
        // Ini memperbaiki error CS8618 kedua
        public virtual ICollection<PerformanceLog> PerformanceLogs { get; set; } = new HashSet<PerformanceLog>();
    }
}
