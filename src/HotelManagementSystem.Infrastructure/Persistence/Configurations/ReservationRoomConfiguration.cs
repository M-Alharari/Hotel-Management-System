using HotelManagementSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HotelManagementSystem.Infrastructure.Persistence.Configurations;

public class ReservationRoomConfiguration : IEntityTypeConfiguration<ReservationRoom>
{
    public void Configure(EntityTypeBuilder<ReservationRoom> builder)
    {
        builder.ToTable("ReservationRooms", table =>
        {
            table.HasCheckConstraint(
                "CK_ReservationRooms_PricePerNight",
                "[PricePerNight] > 0");

            table.HasCheckConstraint(
                "CK_ReservationRooms_Adults",
                "[Adults] >= 0");

            table.HasCheckConstraint(
                "CK_ReservationRooms_Children",
                "[Children] >= 0");
        });

        builder.HasKey(rr => rr.Id);

        builder.HasOne(rr => rr.Reservation)
            .WithMany(r => r.ReservationRooms)
            .HasForeignKey(rr => rr.ReservationId)
            .OnDelete(DeleteBehavior.NoAction);

        builder.HasOne(rr => rr.Room)
            .WithMany(r => r.ReservationRooms)
            .HasForeignKey(rr => rr.RoomId)
            .OnDelete(DeleteBehavior.NoAction);

        builder.Property(rr => rr.PricePerNight)
            .HasPrecision(18, 2)
            .IsRequired();

        builder.HasIndex(rr => new { rr.ReservationId, rr.RoomId })
            .IsUnique();
    }
}