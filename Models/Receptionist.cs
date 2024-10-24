using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hospital_Management.Models
{
    public class Receptionist
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [ForeignKey("Employee")]
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; } = default!;
    }
}