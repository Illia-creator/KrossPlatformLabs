using Lab6.Api.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Lab6.Api.Configurations
{
    public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.HasKey(c => c.Id);
           
            builder.Property(c => c.AddressId).IsRequired();
            builder.Property(c => c.CustomerFirstName).IsRequired();
            builder.Property(c => c.CustomerLastName).IsRequired();
            builder.Property(c => c.CustomerPhone).IsRequired();
            builder.Property(c => c.DateOriginalyJoined).IsRequired();
            builder.Property(c => c.CreditCardNumber).IsRequired();
            builder.Property(c => c.DateCardExpiry).IsRequired();
            builder.Property(c => c.OtherCustomerDetails);

            builder.HasOne(c => c.Address)
                   .WithMany(a => a.Customers)
                   .HasForeignKey(c => c.AddressId);

            builder.HasMany(c => c.Prescriptions)
                   .WithOne(p => p.Customer)
                   .HasForeignKey(p => p.CustomerId);
        }    
    }
}
