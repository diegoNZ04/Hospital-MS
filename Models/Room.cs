using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hospital_Management.Models;

public class Room
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    [Required]
    [StringLength(255)]
    public string Type { get; set; } = default!;
    [Required]
    public int Capacity { get; set; }
    [Required]
    [StringLength(255)]
    public string Availablity { get; set; } = default!;

}