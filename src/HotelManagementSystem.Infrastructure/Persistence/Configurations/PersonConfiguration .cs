using HotelManagementSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HotelManagementSystem.Infrastructure.Data.Configurations;

public class PersonConfiguration : IEntityTypeConfiguration<Person>
{
    public void Configure(EntityTypeBuilder<Person> builder)
    {
        builder.ToTable("People");

        builder.HasKey(p => p.Id);

        builder.Property(p => p.FirstName)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(p => p.LastName)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(p => p.Email)
            .HasMaxLength(256);

        builder.HasIndex(p => p.Email)
            .IsUnique()
            .HasFilter("[Email] IS NOT NULL");

        builder.Property(p => p.PhoneNumber)
            .IsRequired()
            .HasMaxLength(20);

        builder.Property(p => p.Address)
            .HasMaxLength(300);

        

        builder.HasOne(p => p.Country)
            .WithMany(c => c.Residents)
            .HasForeignKey(p => p.CountryId)
            .OnDelete(DeleteBehavior.NoAction);
    }
}