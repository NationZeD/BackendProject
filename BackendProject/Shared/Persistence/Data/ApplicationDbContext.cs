using BackendProject.App.AcademicYears.Entities;
using BackendProject.App.Accounts.Customers.Entities;
using BackendProject.App.Accounts.Employees.Admins.Entities;
using BackendProject.App.Accounts.Employees.Lecturers.Entities;
using BackendProject.App.Auth.Entities;
using BackendProject.App.Categories.Entities;
using BackendProject.App.Components.Entities;
using BackendProject.App.FAQs.Entities;
using BackendProject.App.Subjects.Entities;
using BackendProject.App.SystemFiles.Entities;
using BackendProject.App.Verifications.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BackendProject.Shared.Persistence.Data;

public sealed class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
    : IdentityDbContext<ApplicationUser>(options)
{
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
    }

    public DbSet<Customer> Customers { get; set; }
    public DbSet<OTPCode> OTPCodes { get; set; }
    public DbSet<Admin> Admins { get; set; }
    public DbSet<Lecturer> Lecturers { get; set; }
    public DbSet<FAQItem> FAQItems { get; set; }
    public DbSet<Component> Components { get; set; }
    public DbSet<LecturerComponent> LecturerComponents { get; set; }
    public DbSet<SystemFile> SystemFiles { get; set; }
    public DbSet<Subject> Subjects { get; set; }
    public DbSet<SubjectComponent> SubjectComponents { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<AcademicYear> AcademicYears { get; set; }
}