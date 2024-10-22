using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Hospital_Management.Enuns;

namespace Hospital_Management.Models;

public class Patient
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    [Required]
    public string Name { get; set; } = default!;
    [Required]
    public int Age { get; set; }
    [Required]
    public Gender Gender { get; set; }
    [DataType(DataType.Date)]
    [Required]
    public DateTime Birthday { get; set; }
    [Required]
    public string Contact { get; set; } = default!;
    [Required]
    public string Address { get; set; } = default!;
}
