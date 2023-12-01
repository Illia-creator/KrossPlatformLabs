using Lab6.Api.Entities.Relations;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Lab6.Api.Configurations
{
    public class GenericToBrandNameCorrespondenceConfiguration : IEntityTypeConfiguration<GenericToBrandNameCorrespondence>
    {
        public void Configure(EntityTypeBuilder<GenericToBrandNameCorrespondence> builder)
        {
            builder.HasKey(gc => new { gc.BrandNameMedicationId, gc.GenericMedicationId });

            builder.HasOne(gc => gc.BrandNameMedication)
                   .WithMany(b => b.GenericToBrandNameCorrespondences)
                   .HasForeignKey(gc => gc.BrandNameMedicationId);

            builder.HasOne(gc => gc.GenericMedication)
                   .WithMany(g => g.GenericToBrandNameCorrespondences)
                   .HasForeignKey(gc => gc.GenericMedicationId);
        }
    }
}
