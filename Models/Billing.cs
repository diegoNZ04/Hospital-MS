using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hospital_Management.Models;

public class Billing
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    public int PatientId { get; set; }
    public Patient Patient { get; set; } = default!;
    [Required]
    public decimal Amount { get; set; }
}