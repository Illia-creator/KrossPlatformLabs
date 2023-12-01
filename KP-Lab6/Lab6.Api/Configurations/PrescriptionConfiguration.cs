using Lab6.Api.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Lab6.Api.Configurations
{
    public class PrescriptionConfiguration : IEntityTypeConfiguration<Prescription>
    {
        public void Configure(EntityTypeBuilder<Prescription> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.CustomerId).IsRequired();
            builder.Property(p => p.DoctorId).IsRequired();
            builder.Property(p => p.PrescriptionStatusCode).IsRequired();
            builder.Property(p => p.PaymentMethodCode).IsRequired();
            builder.Property(p => p.DatePrescriptionReceived).IsRequired();
            builder.Property(p => p.DatePrescriptionRenewal).IsRequired();
            builder.Property(p => p.DatePrescriptionSendToDoctor).IsRequired();
            builder.Property(p => p.DatePrescriptionProcessed).IsRequired();
            builder.Property(p => p.DatePrescriptionRecievedFromDoctor).IsRequired();
            builder.Property(p => p.DatePrescriptionSendToCompany).IsRequired();
            builder.Property(p => p.DatePrescriptionFilled).IsRequired();
            builder.Property(p => p.OtherPrescriptionDetails);

            builder.HasOne(p => p.Customer)
                   .WithMany(c => c.Prescriptions)
                   .HasForeignKey(p => p.CustomerId);

            builder.HasOne(p => p.Doctor)
                   .WithMany(d => d.Prescriptions)
                   .HasForeignKey(p => p.DoctorId);

            builder.HasMany(p => p.PrescriptionItems)
                   .WithOne(pi => pi.Prescription)
                   .HasForeignKey(pi => pi.PrescriptionId);

            builder.HasMany(p => p.ItemsOrdered)
                   .WithOne(io => io.Prescription)
                   .HasForeignKey(io => io.PrescriptionId);
        }
    }

}
