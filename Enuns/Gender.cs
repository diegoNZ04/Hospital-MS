using System.ComponentModel.DataAnnotations;

namespace Hospital_Management.Enuns;

public enum Gender
{
    [Display(Name = "Male")]
    Masc,
    [Display(Name = "Female")]
    Fem
}