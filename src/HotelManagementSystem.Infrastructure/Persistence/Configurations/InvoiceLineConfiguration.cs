using HotelManagementSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HotelManagementSystem.Infrastructure.Persistence.Configurations;

public class InvoiceLineConfiguration : IEntityTypeConfiguration<InvoiceLine>
{
    public void Configure(EntityTypeBuilder<InvoiceLine> builder)
    {
        builder.ToTable("InvoiceLines", table =>
        {
            table.HasCheckConstraint(
                "CK_InvoiceLines_Quantity",
                "[Quantity] > 0");

            table.HasCheckConstraint(
                "CK_InvoiceLines_UnitPrice",
                "[UnitPrice] >= 0");

            table.HasCheckConstraint(
                "CK_InvoiceLines_Source",
                "([ReservationRoomId] IS NOT NULL AND [ServiceUsageId] IS NULL) OR " +
                "([ReservationRoomId] IS NULL AND [ServiceUsageId] IS NOT NULL)");
        });

        builder.HasKey(il => il.Id);

        builder.Property(il => il.Description)
            .IsRequired()
            .HasMaxLength(500);

        builder.Property(il => il.Quantity)
            .HasPrecision(18, 2)
            .IsRequired();

        builder.Property(il => il.UnitPrice)
            .HasPrecision(18, 2)
            .IsRequired();

        builder.HasOne(il => il.Invoice)
            .WithMany(i => i.InvoiceLines)
            .HasForeignKey(il => il.InvoiceId)
            .OnDelete(DeleteBehavior.NoAction);

        builder.HasOne(il => il.ReservationRoom)
            .WithMany()
            .HasForeignKey(il => il.ReservationRoomId)
            .OnDelete(DeleteBehavior.NoAction);

        builder.HasOne(il => il.ServiceUsage)
            .WithMany()
            .HasForeignKey(il => il.ServiceUsageId)
            .OnDelete(DeleteBehavior.NoAction);

        builder.HasIndex(il => il.ReservationRoomId)
            .IsUnique()
            .HasFilter("[ReservationRoomId] IS NOT NULL");

        builder.HasIndex(il => il.ServiceUsageId)
            .IsUnique()
            .HasFilter("[ServiceUsageId] IS NOT NULL");
    }
}