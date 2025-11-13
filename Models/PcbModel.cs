using System.ComponentModel.DataAnnotations;

public class PcbModel
{
    [Key]
    public int Id { get; set; }

    [Required]
    public string ModelCode { get; set; } = string.Empty; // <-- DIUBAH DI SINI

    [Required]
    public string ProductGroup { get; set; } = string.Empty; // <-- DIUBAH DI SINI

    public double Multiplier { get; set; }

    public string ProcessTimesJson { get; set; } = string.Empty; // <-- DIUBAH DI SINI
}