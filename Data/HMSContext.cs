using Hospital_Management.Controllers;
using Hospital_Management.Models;
using Microsoft.EntityFrameworkCore;

namespace Hospital_Management.Data;

public class HMSContext : DbContext
{
    public HMSContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<Patient> Patients { get; set; } = default!;
    public DbSet<Employee> Employees { get; set; } = default!;
    public DbSet<Doctor> Doctors { get; set; } = default!;
    public DbSet<Nurse> Nurses { get; set; } = default!;
}