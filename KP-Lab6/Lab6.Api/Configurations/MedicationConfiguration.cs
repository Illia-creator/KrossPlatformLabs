using Lab6.Api.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Lab6.Api.Configurations
{
    public class MedicationConfiguration : IEntityTypeConfiguration<Medication>
    {
        public void Configure(EntityTypeBuilder<Medication> builder)
        {
            builder.HasKey(m => m.Id);

            builder.Property(m => m.MedicationTypeCode).IsRequired();
            builder.Property(m => m.MedicationName).IsRequired();
            builder.Property(m => m.MedicationDescription);
            builder.Property(m => m.MedicationCost).IsRequired();
            builder.Property(m => m.MedicationOtherDetails);

            builder.HasMany(m => m.PrescriptionItems)
                   .WithOne(pi => pi.Medication)
                   .HasForeignKey(pi => pi.MedicationId);

            builder.HasMany(m => m.ItemsOrdered)
                   .WithOne(io => io.Medication)
                   .HasForeignKey(io => io.MedicationId);
        }
    }
}
