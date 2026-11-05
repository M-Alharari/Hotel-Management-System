using HotelManagementSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HotelManagementSystem.Infrastructure.Persistence.Configurations;

public class RoomTypeConfiguration : IEntityTypeConfiguration<RoomType>
{
    public void Configure(EntityTypeBuilder<RoomType> builder)
    {
        builder.ToTable("RoomTypes");

        builder.HasKey(rt => rt.Id);

        builder.Property(rt => rt.Name)
            .IsRequired()
            .HasMaxLength(100);

        builder.HasIndex(rt => rt.Name)
            .IsUnique();

        builder.Property(rt => rt.Description)
            .HasMaxLength(300);

        builder.Property(rt => rt.BasePricePerNight)
            .HasPrecision(18, 2)
            .IsRequired();

        builder.Property(rt => rt.MaxOccupancy)
            .IsRequired();

        builder.Property(rt => rt.IsActive)
            .IsRequired()
            .HasDefaultValue(true);

        builder.ToTable(t =>
        {
            t.HasCheckConstraint(
                "CK_RoomTypes_BasePricePerNight",
                "[BasePricePerNight] >= 0");

            t.HasCheckConstraint(
                "CK_RoomTypes_MaxOccupancy",
                "[MaxOccupancy] > 0");
        });
    }
}