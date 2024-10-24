using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Hospital_Management.Enuns;

namespace Hospital_Management.Models
{
    public class Doctor
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public Departament Departament { get; set; } = default!;
        [Required]
        [StringLength(255)]
        public string Qualification { get; set; } = default!;
        [Required]
        [ForeignKey("Employee")]
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; } = default!;
    }
}