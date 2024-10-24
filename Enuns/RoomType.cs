using System.ComponentModel.DataAnnotations;

namespace Hospital_Management.Enuns;

public enum RoomType
{
    [Display(Name = "Procedure Room")]
    Procedure,
    [Display(Name = "Vaccination Room")]
    Vaccination,
    [Display(Name = "Collective Inhalation Room")]
    Inhalation,
    [Display(Name = "Collection/Examination Room")]
    CollectionExam,
    [Display(Name = "Dressing Room")]
    Dressing,
    [Display(Name = "Purge Room")]
    Purge,
    [Display(Name = "Sterilization Room")]
    Sterilization,
    [Display(Name = "Observation Room")]
    Observation
}