namespace Lab6.Api.Configurations
{
    using Lab6.Api.Entities;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class BrandNameMedicationConfiguration : IEntityTypeConfiguration<BrandNameMedication>
    {
        public void Configure(EntityTypeBuilder<BrandNameMedication> builder)
        {
            builder.HasKey(b => b.Id);

            builder.Property(b => b.CompanyId).IsRequired();
            builder.Property(b => b.BrandMedicationName).IsRequired();
            builder.Property(b => b.BrandMedicationCost).IsRequired();
            builder.Property(b => b.BrandMedicationDescription).IsRequired();

            builder.HasOne(b => b.PharmaceuticalCompany)
                   .WithMany(pc => pc.BrandNameMedications)
                   .HasForeignKey(b => b.CompanyId);

            builder.HasMany(b => b.GenericToBrandNameCorrespondences)
                   .WithOne(gc => gc.BrandNameMedication)
                   .HasForeignKey(gc => gc.BrandNameMedicationId); 
        }
    }

}
