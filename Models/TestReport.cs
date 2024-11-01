using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hospital_Management.Models;

public class TestReport
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    public int PatientId { get; set; }
    public Patient Patient { get; set; } = default!;
    [Required]
    [StringLength(255)]
    public string TestType { get; set; } = default!;
    [Required]
    [StringLength(255)]
    public string Result { get; set; } = default!;
}