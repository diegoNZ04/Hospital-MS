using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Hospital_Management.Models;

public class Doctor
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    [Required]
    [StringLength(255)]
    public string Departament { get; set; } = default!;
    [Required]
    [StringLength(255)]
    public string Qualification { get; set; } = default!;
    [Required]
    [ForeignKey("EmployeeDoctor")]
    public int EmployeeId { get; set; }
    public Employee EmployeeDoctor { get; set; } = null!;
    public virtual List<Patient> Patients { get; } = [];
}