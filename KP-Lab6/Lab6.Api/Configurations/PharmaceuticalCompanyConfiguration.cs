using Lab6.Api.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Lab6.Api.Configurations
{
    public class PharmaceuticalCompanyConfiguration : IEntityTypeConfiguration<PharmaceuticalCompany>
    {
        public void Configure(EntityTypeBuilder<PharmaceuticalCompany> builder)
        {
            builder.HasKey(pc => pc.Id);

            builder.Property(pc => pc.CompanyName).IsRequired();
            builder.Property(pc => pc.CompanyOtherDetails);

            builder.HasMany(pc => pc.BrandNameMedications)
                   .WithOne(b => b.PharmaceuticalCompany)
                   .HasForeignKey(b => b.CompanyId);
        }
    }
}
