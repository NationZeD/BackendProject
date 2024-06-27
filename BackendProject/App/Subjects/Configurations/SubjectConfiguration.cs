using BackendProject.App.Subjects.Entities;
using BackendProject.App.Subjects.ValueObjects;
using BackendProject.App.SystemFiles.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BackendProject.App.Subjects.Configurations;

public class SubjectConfiguration : IEntityTypeConfiguration<Subject>
{
    public void Configure(EntityTypeBuilder<Subject> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .HasConversion(x => x.Value, value => new SubjectId(value));

        builder.HasMany(x=>x.SubjectComponents)
            .WithOne().HasForeignKey(x => x.SubjectId).OnDelete(DeleteBehavior.Cascade)
            .Metadata.PrincipalToDependent.SetPropertyAccessMode(PropertyAccessMode.Field);
        
        builder.Property(x => x.ImageId)
            .HasConversion(x => x.Value, value => new SystemFileId(value));

        builder.HasOne(x => x.Name);
    }
}