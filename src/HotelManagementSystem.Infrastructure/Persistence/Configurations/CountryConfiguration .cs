using HotelManagementSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HotelManagementSystem.Infrastructure.Persistence.Configurations;

public class CountryConfiguration : IEntityTypeConfiguration<Country>
{
    public void Configure(EntityTypeBuilder<Country> builder)
    {
        builder.ToTable("Countries");

        builder.HasKey(c => c.Id);

        builder.Property(c => c.Name)
            .IsRequired()
            .HasMaxLength(100);

        builder.HasIndex(c => c.Name)
            .IsUnique();

        builder.Property(c => c.CountryCode)
            .IsRequired()
            .HasMaxLength(2);

        builder.HasIndex(c => c.CountryCode)
            .IsUnique();

        builder.HasMany(c => c.Guests)
            .WithOne(g => g.Nationality)
            .HasForeignKey(g => g.NationalityId)
            .OnDelete(DeleteBehavior.NoAction);
    }
}