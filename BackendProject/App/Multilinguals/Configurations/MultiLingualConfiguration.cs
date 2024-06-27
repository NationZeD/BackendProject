using BackendProject.App.Multilinguals.Entities;
using BackendProject.App.Multilinguals.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BackendProject.App.Multilinguals.Configurations;

public class MultiLingualConfiguration : IEntityTypeConfiguration<Multilingual>
{
    public void Configure(EntityTypeBuilder<Multilingual> builder)
    {
        builder.ToTable("Multilinguals");

        builder.HasKey(ml => ml.Id);
        builder.Property<byte[]>("Version")
            .IsRowVersion();
        builder.Property(x => x.Id).HasConversion(ml => ml.Value, value => new MultiLingualId(value));
        builder.HasMany(x => x.Items).WithOne().HasForeignKey(x => x.MultiLingualId);
    }
}