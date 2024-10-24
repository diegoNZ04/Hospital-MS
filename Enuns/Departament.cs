using System.ComponentModel.DataAnnotations;

namespace Hospital_Management.Enuns;

public enum Departament
{
    [Display(Name = "Pathological Anatomy and Forensic Medicine")]
    PathologicalAnatomy,
    [Display(Name = "Anatomy and Image")]
    ImageAnagomy,
    [Display(Name = "Locomotor Apparatus")]
    LocomotorApparatus,
    [Display(Name = "Medical Clinic")]
    MedicalClinic,
    [Display(Name = "Surgery")]
    Surgery,
    [Display(Name = "Speech Therapy")]
    SpeechTherapy,
    [Display(Name = "Gynecology and Obstetrics")]
    GynecologyObstetrics,
    [Display(Name = "Preventive and Social Medicine")]
    PreventineSocialMedice,
    [Display(Name = "Ophthalmology and Otorhinolaryngology")]
    OphthalOtorhinolary,
    [Display(Name = "Pediatrics")]
    Pediatrics,
    [Display(Name = "Complementary Propaedeutics")]
    ComplementarPropaedeutics,
    [Display(Name = "Mental Health")]
    MentalHealth
}