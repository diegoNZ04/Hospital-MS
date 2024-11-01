using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Hospital_Management.Enuns;

namespace Hospital_Management.Models;

public abstract class Employee
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
    [DataType(DataType.Date)]
    public DateTime Birthday { get; set; }
    [Required]
    [StringLength(50)]
    [DataType(DataType.PhoneNumber)]
    [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Not a valid phone number")]
    public string Contact { get; set; } = default!;
    [Required]
    [StringLength(255)]
    public string Address { get; set; } = default!;
}