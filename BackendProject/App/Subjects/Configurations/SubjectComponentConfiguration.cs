using BackendProject.App.Components.ValueObjects;
using BackendProject.App.Subjects.Entities;
using BackendProject.App.Subjects.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BackendProject.App.Subjects.Configurations;

public class SubjectComponentConfiguration : IEntityTypeConfiguration<SubjectComponent>
{
    public void Configure(EntityTypeBuilder<SubjectComponent> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id)
            .HasConversion(x => x.Value, value => new SubjectComponentId(value));

        builder.Property(x => x.SubjectId)
            .HasConversion(x => x.Value, value => new SubjectId(value));

        builder.Property(x => x.ComponentId)
            .HasConversion(x => x.Value, value => new ComponentId(value));
    }
}