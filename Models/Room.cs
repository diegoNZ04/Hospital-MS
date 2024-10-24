using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Hospital_Management.Enuns;

namespace Hospital_Management.Models;

public class Room
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    [Required]
    public RoomType Type { get; set; }
    [Required]
    public int Capacity { get; set; }
    [Required]
    public RoomAvailablity Availablity { get; set; }

}