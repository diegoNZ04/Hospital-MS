using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Hospital_Management.Enuns;

namespace Hospital_Management.Models
{
    public class Employee
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [StringLength(255)]
        public string Name { get; set; } = default!;
        [Required]
        public decimal Salary { get; set; }
        [Required]
        public int Age { get; set; }
        [Required]
        public Gender Gender { get; set; }
        [Required]
        public DateTime Birthday { get; set; }
        [Required]
        [StringLength(50)]
        public string Contact { get; set; } = default!;
        [Required]
        [StringLength(255)]
        public string Address { get; set; } = default!;
        public Doctor? Doctor { get; set; }
        public Nurse? Nurse { get; set; }
    }
}