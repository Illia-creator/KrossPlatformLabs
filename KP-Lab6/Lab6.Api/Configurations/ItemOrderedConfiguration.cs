using Lab6.Api.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Lab6.Api.Configurations
{
    public class ItemOrderedConfiguration : IEntityTypeConfiguration<ItemOrdered>
    {
        public void Configure(EntityTypeBuilder<ItemOrdered> builder)
        {
            builder.HasKey(io => new { io.PrescriptionId, io.MedicationId });

            builder.Property(io => io.DateOrdered).IsRequired();
            builder.Property(io => io.QuantityOrdered).IsRequired();
            builder.Property(io => io.DateReceived);
            builder.Property(io => io.QuantityReceived);

            builder.HasOne(io => io.Prescription)
                   .WithMany(p => p.ItemsOrdered)
                   .HasForeignKey(io => io.PrescriptionId);

            builder.HasOne(io => io.Medication)
                   .WithMany(m => m.ItemsOrdered)
                   .HasForeignKey(io => io.MedicationId);
        }
    }
}