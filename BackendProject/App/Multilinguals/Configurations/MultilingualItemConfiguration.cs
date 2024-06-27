using BackendProject.App.Multilinguals.Entities;
using BackendProject.App.Multilinguals.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BackendProject.App.Multilinguals.Configurations;

public class MultilingualItemConfiguration : IEntityTypeConfiguration<MultiLingualItem>
{
    public void Configure(EntityTypeBuilder<MultiLingualItem> builder)
    {
        builder.ToTable("MultilingualItems");
        builder.HasKey(x => x.Id);
        builder.Property<byte[]>("Version")
            .IsRowVersion();
        builder.Property(x => x.Id).HasConversion(x => x.Value, value => new MultiLingualItemId(value));
        builder.HasIndex(x => x.MultiLingualId);
    }
}