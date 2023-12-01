using Lab6.Api.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Lab6.Api.Configurations;

public class AddressConfiguration : IEntityTypeConfiguration<Address>
{
    public void Configure(EntityTypeBuilder<Address> builder)
    {
        builder.HasKey(a => a.Id);

        builder.Property(a => a.Line1NumberBuilding).HasMaxLength(100).IsRequired();
        builder.Property(a => a.City).HasMaxLength(100).IsRequired();
        builder.Property(a => a.ZipPostCode).HasMaxLength(100).IsRequired();
        builder.Property(a => a.StateProvinceCountry).HasMaxLength(100).IsRequired();
        builder.Property(a => a.Country).HasMaxLength(100).IsRequired();

        builder.HasMany(a => a.Customers)
               .WithOne(c => c.Address)
               .HasForeignKey(c => c.AddressId);

        builder.HasMany(a => a.Doctors)
               .WithOne(d => d.Address)
               .HasForeignKey(d => d.AddressId);
    }
}
