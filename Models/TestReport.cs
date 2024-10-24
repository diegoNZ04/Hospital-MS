using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hospital_Management.Models;

public class TestReport
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    [Required]
    [ForeignKey("Room")]
    public int RoomId { get; set; }
    [Required]
    public string TestType { get; set; } = default!;
    [Required]
    public string Result { get; set; } = default!;
}