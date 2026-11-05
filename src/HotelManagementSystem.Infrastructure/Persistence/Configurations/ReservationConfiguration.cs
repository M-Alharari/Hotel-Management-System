using HotelManagementSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HotelManagementSystem.Infrastructure.Persistence.Configurations;

public class ReservationConfiguration : IEntityTypeConfiguration<Reservation>
{
    public void Configure(EntityTypeBuilder<Reservation> builder)
    {
        builder.ToTable("Reservations", table =>
        {
            table.HasCheckConstraint(
                "CK_Reservations_CheckOutDate",
                "[CheckOutDate] > [CheckInDate]");
        });

        builder.HasKey(r => r.Id);

        builder.HasOne(r => r.PrimaryGuest)
            .WithMany()
            .HasForeignKey(r => r.PrimaryGuestId)
            .OnDelete(DeleteBehavior.NoAction);

        builder.HasOne(r => r.CreatedByUser)
            .WithMany()
            .HasForeignKey(r => r.CreatedByUserId)
            .OnDelete(DeleteBehavior.NoAction);

        builder.Property(r => r.Status)
            .IsRequired()
            .HasConversion<int>();

        builder.Property(r => r.SpecialRequests)
            .HasMaxLength(1000);

        builder.Property(r => r.CheckInDate)
            .IsRequired();

        builder.Property(r => r.CheckOutDate)
            .IsRequired();

        builder.Property(r => r.CreatedAt)
            .IsRequired();

        builder.Property(r => r.HoldExpiresAt)
            .IsRequired(false);

        builder.Property(r => r.UpdatedAt)
            .IsRequired(false);
    }
}