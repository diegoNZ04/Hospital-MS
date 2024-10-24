using System.ComponentModel.DataAnnotations;

namespace Hospital_Management.Enuns;

public enum RoomAvailablity
{
    [Display(Name = "Available")]
    True,
    [Display(Name = "Unavaible")]
    False
}