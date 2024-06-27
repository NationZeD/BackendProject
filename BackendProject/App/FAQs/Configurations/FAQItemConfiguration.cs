using BackendProject.App.FAQs.Entities;
using BackendProject.App.FAQs.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BackendProject.App.FAQs.Configurations;

public class FAQItemConfiguration : IEntityTypeConfiguration<FAQItem>
{
    public void Configure(EntityTypeBuilder<FAQItem> builder)
    {
        builder.ToTable("FAQItems"); 
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id)
            .HasConversion(x => x.Value, value => new FAQItemId(value));
    }
}