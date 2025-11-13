using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace backend.Models
{
    public class PerformanceLog
    {
        [Key]
        public int LogId { get; set; }

        [Required]
        public int MachineId { get; set; } // Foreign Key

        [Required]
        public DateTime LogDate { get; set; }

        [Required]
        public int UsedTimeMinutes { get; set; }

        [Required]
        public int LossTimeMinutes { get; set; }
        
        public string? Notes { get; set; }

        // Navigation property to the Machine
        [ForeignKey("MachineId")]
        // PERBAIKAN: Tambahkan '= null!' untuk memberitahu C# bahwa EF akan mengisinya
        // Ini memperbaiki error CS8618 ketiga
        public virtual Machine Machine { get; set; } = null!; 
    }
}
