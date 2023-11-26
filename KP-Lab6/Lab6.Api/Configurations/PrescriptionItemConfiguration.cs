using Lab6.Api.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Lab6.Api.Configurations
{
    public class PrescriptionItemConfiguration : IEntityTypeConfiguration<PrescriptionItem>
    {
        public void Configure(EntityTypeBuilder<PrescriptionItem> builder)
        {
            builder.HasKey(pi => new { pi.PrescriptionId, pi.MedicationId });

            builder.Property(pi => pi.PrestcriptionQuantity).IsRequired();
            builder.Property(pi => pi.InstructionsToCustomer);

            builder.HasOne(pi => pi.Prescription)
                   .WithMany(p => p.PrescriptionItems)
                   .HasForeignKey(pi => pi.PrescriptionId);

            builder.HasOne(pi => pi.Medication)
                   .WithMany(m => m.PrescriptionItems)
                   .HasForeignKey(pi => pi.MedicationId);
        }
    }
}
