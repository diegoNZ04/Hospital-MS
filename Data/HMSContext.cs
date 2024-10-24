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
}