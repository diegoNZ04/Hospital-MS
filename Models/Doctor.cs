using System.ComponentModel.DataAnnotations;



namespace Hospital_Management.Models;

public class Doctor : Employee
{
    [Required]
    [StringLength(255)]
    public string Departament { get; set; } = default!;
    [Required]
    [StringLength(255)]
    public string Qualification { get; set; } = default!;
    public List<Patient> Patients { get; } = [];
}