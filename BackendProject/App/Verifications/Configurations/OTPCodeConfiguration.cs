using BackendProject.App.Verifications.Entities;
using BackendProject.App.Verifications.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BackendProject.App.Verifications.Configurations;

public class OTPCodeConfiguration : IEntityTypeConfiguration<OTPCode>
{
    public void Configure(EntityTypeBuilder<OTPCode> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property<byte[]>("Version")
            .IsRowVersion();
        builder.Property(x => x.Id).HasConversion(ml => ml.Value, value => new OTPCodeId(value));
        builder.HasIndex(x => x.Source);
    }
}