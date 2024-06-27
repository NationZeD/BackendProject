using BackendProject.App.Accounts.Employees.Lecturers.Entities;
using BackendProject.App.Accounts.Employees.Lecturers.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BackendProject.App.Accounts.Employees.Lecturers.Configurations;

public class LecturerConfiguration : IEntityTypeConfiguration<Lecturer>
{
    public void Configure(EntityTypeBuilder<Lecturer> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id)
            .HasConversion(x => x.Value, value => new LecturerId(value));
        
        builder.HasMany(x=>x.LecturerComponents)
            .WithOne().HasForeignKey(x => x.LecturerId).OnDelete(DeleteBehavior.Cascade)
            .Metadata.PrincipalToDependent.SetPropertyAccessMode(PropertyAccessMode.Field);
        
        builder.HasIndex(x => x.UserName).IsUnique();
        builder.HasIndex(x => x.PersonalId).IsUnique();
    }
}