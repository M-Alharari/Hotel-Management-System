using HotelManagementSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HotelManagementSystem.Infrastructure.Persistence.Configurations;

public class HotelServiceConfiguration : IEntityTypeConfiguration<HotelService>
{
    public void Configure(EntityTypeBuilder<HotelService> builder)
    {
        builder.ToTable("HotelServices", table =>
        {
            table.HasCheckConstraint(
                "CK_HotelServices_Price",
                "[Price] >= 0");
        });

        builder.HasKey(s => s.Id);

        builder.Property(s => s.Name)
            .IsRequired()
            .HasMaxLength(100);

        builder.HasIndex(s => s.Name)
            .IsUnique();

        builder.Property(s => s.Description)
            .HasMaxLength(500);

        builder.Property(s => s.Price)
            .HasPrecision(18, 2)
            .IsRequired();

        builder.Property(s => s.IsActive)
            .IsRequired()
            .HasDefaultValue(true);
    }
}