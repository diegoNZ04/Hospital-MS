using Hospital_Management.Models;
using Microsoft.EntityFrameworkCore;

namespace Hospital_Management.Data;

public class HMSContext : DbContext
{
    public HMSContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<Billing> Billings { get; set; } = default!;
    public DbSet<Doctor> Doctors { get; set; } = default!;
    public DbSet<Employee> Employees { get; set; } = default!;
    public DbSet<Nurse> Nurses { get; set; } = default!;
    public DbSet<Patient> Patients { get; set; } = default!;
    public DbSet<Receptionist> Receptionists { get; set; } = default!;
    public DbSet<TestReport> TestReports { get; set; } = default!;
    public DbSet<Room> Rooms { get; set; } = default!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Doctor>()
            .HasMany(e => e.Patients)
            .WithMany(e => e.Doctors)
            .UsingEntity(
                "DoctorPatient",
                l => l.HasOne(typeof(Patient)).WithMany().HasForeignKey("PatientsId").HasPrincipalKey(nameof(Patient.Id)),
                r => r.HasOne(typeof(Doctor)).WithMany().HasForeignKey("DoctorsId").HasPrincipalKey(nameof(Doctor.Id)),
                j => j.HasKey("PatientsId", "DoctorsId"));

        modelBuilder.Entity<Nurse>()
            .HasMany(e => e.Rooms)
            .WithMany(e => e.Nurses)
            .UsingEntity(
                "NurseRoom",
                l => l.HasOne(typeof(Room)).WithMany().HasForeignKey("RoomsId").HasPrincipalKey(nameof(Room.Id)),
                r => r.HasOne(typeof(Nurse)).WithMany().HasForeignKey("NursesId").HasPrincipalKey(nameof(Nurse.Id)),
                j => j.HasKey("RoomsId", "NursesId"));

        modelBuilder.Entity<Patient>()
            .HasMany(e => e.Billings)
            .WithOne(e => e.Patient)
            .HasForeignKey(e => e.PatientId)
            .IsRequired();

        modelBuilder.Entity<Patient>()
            .HasMany(e => e.TestReports)
            .WithOne(e => e.Patient)
            .HasForeignKey(e => e.PatientId)
            .IsRequired();

        modelBuilder.Entity<Room>()
            .HasMany(e => e.Patients)
            .WithOne(e => e.Room)
            .HasForeignKey(e => e.RoomId)
            .IsRequired();
    }
}