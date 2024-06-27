using BackendProject.App.SystemFiles.Entities;
using BackendProject.App.SystemFiles.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BackendProject.App.SystemFiles.Configurations;

public class SystemFileConfiguration : IEntityTypeConfiguration<SystemFile>
{
    public void Configure(EntityTypeBuilder<SystemFile> builder)
    { 
        builder.ToTable("SystemFiles");
        
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id)
            .HasConversion(x => x.Value, value => new SystemFileId(value));

    }
}