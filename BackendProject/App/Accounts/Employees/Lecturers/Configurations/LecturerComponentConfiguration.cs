using BackendProject.App.Accounts.Employees.Lecturers.Entities;
using BackendProject.App.Accounts.Employees.Lecturers.ValueObjects;
using BackendProject.App.Components.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BackendProject.App.Accounts.Employees.Lecturers.Configurations;

public class LecturerComponentConfiguration : IEntityTypeConfiguration<LecturerComponent>
{
    public void Configure(EntityTypeBuilder<LecturerComponent> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id)
            .HasConversion(x => x.Value, value => new LecturerComponentId(value));

        builder.Property(x => x.LecturerId)
            .HasConversion(x => x.Value, value => new LecturerId(value));

        builder.Property(x => x.ComponentId)
            .HasConversion(x => x.Value, value => new ComponentId(value));
    }
}