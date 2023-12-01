using Lab6.Api.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Lab6.Api.Configurations
{
    public class DoctorConfiguration : IEntityTypeConfiguration<Doctor>
    {
        public void Configure(EntityTypeBuilder<Doctor> builder)
        {
            builder.HasKey(d => d.Id);

            builder.Property(d => d.AddressId).IsRequired();
            builder.Property(d => d.DoctorFirstName).IsRequired();
            builder.Property(d => d.DoctorLastName).IsRequired();
            builder.Property(d => d.Gender).IsRequired();
            builder.Property(d => d.DoctorPhone).IsRequired();
            builder.Property(d => d.DoctorEmail).IsRequired();
            builder.Property(d => d.OtherDoctorDetails);

            builder.HasOne(d => d.Address)
                   .WithMany(a => a.Doctors)
                   .HasForeignKey(d => d.AddressId);

            builder.HasMany(d => d.Prescriptions)
                   .WithOne(p => p.Doctor)
                   .HasForeignKey(p => p.DoctorId);
        }
    }
}
