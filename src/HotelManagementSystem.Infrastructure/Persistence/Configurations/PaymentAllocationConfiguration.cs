using global::HotelManagementSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HotelManagementSystem.Infrastructure.Persistence.Configurations;

public class PaymentAllocationConfiguration : IEntityTypeConfiguration<PaymentAllocation>
{
     public void Configure(EntityTypeBuilder<PaymentAllocation> builder)
     {
            builder.ToTable("PaymentAllocations", table =>
            {
                table.HasCheckConstraint(
                    "CK_PaymentAllocations_Amount",
                    "[Amount] > 0");
            });

            builder.HasKey(pa => pa.Id);

            builder.HasOne(pa => pa.Payment)
                .WithMany(p => p.PaymentAllocation)
                .HasForeignKey(pa => pa.PaymentId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(pa => pa.Invoice)
                .WithMany(i => i.PaymentAllocations)
                .HasForeignKey(pa => pa.InvoiceId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.Property(pa => pa.Amount)
                .HasPrecision(18, 2)
                .IsRequired();

            builder.Property(pa => pa.AllocatedAt)
                .IsRequired();

            builder.HasIndex(pa => new { pa.PaymentId, pa.InvoiceId })
                .IsUnique();
      }
}

