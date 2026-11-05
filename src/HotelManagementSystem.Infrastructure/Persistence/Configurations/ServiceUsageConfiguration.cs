using HotelManagementSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HotelManagementSystem.Infrastructure.Persistence.Configurations;

public class ServiceUsageConfiguration : IEntityTypeConfiguration<ServiceUsage>
{
    public void Configure(EntityTypeBuilder<ServiceUsage> builder)
    {
        builder.ToTable("ServiceUsages", table =>
        {
            table.HasCheckConstraint(
                "CK_ServiceUsages_Quantity",
                "[Quantity] > 0");

            table.HasCheckConstraint(
                "CK_ServiceUsages_UnitPrice",
                "[UnitPrice] >= 0");
        });

        builder.HasKey(su => su.Id);

        builder.HasOne(su => su.Reservation)
            .WithMany()
            .HasForeignKey(su => su.ReservationId)
            .OnDelete(DeleteBehavior.NoAction);

        builder.HasOne(su => su.HotelService)
            .WithMany(s => s.ServiceUsages)
            .HasForeignKey(su => su.HotelServiceId)
            .OnDelete(DeleteBehavior.NoAction);

        builder.Property(su => su.Quantity)
            .IsRequired();

        builder.Property(su => su.UnitPrice)
            .HasPrecision(18, 2)
            .IsRequired();

        builder.Property(su => su.UsedAt)
            .IsRequired();
    }
}