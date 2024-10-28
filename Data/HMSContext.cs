using Hospital_Management.Enuns;
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
            .WithMany(e => e.Doctor);

        modelBuilder.Entity<Employee>()
            .HasOne(e => e.Doctor)
            .WithOne(e => e.EmployeeDoctor)
            .HasForeignKey<Doctor>();

        modelBuilder.Entity<Employee>()
            .HasOne(e => e.Nurse)
            .WithOne(e => e.EmployeeNurse)
            .HasForeignKey<Nurse>();

        modelBuilder.Entity<Employee>()
            .HasOne(e => e.Receptionist)
            .WithOne(e => e.EmployeeReceptionist)
            .HasForeignKey<Receptionist>();
    }
}