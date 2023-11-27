using Lab6.Api.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Lab6.Api.Configurations
{
    public class GenericMedicationConfiguration : IEntityTypeConfiguration<GenericMedication>
    {
        public void Configure(EntityTypeBuilder<GenericMedication> builder)
        {
            builder.HasKey(g => g.Id);

            builder.Property(g => g.GenericMedicationsDetails).IsRequired();


            builder.HasOne(g => g.Medication)
                .WithOne(m => m.GenericMedication)
                .HasForeignKey<GenericMedication>(g => g.MedicationId);

            builder.HasMany(g => g.GenericToBrandNameCorrespondences)
                   .WithOne(gc => gc.GenericMedication)
                   .HasForeignKey(gc => gc.GenericMedicationId);
        }
    }
}
