using Lab6.Api.Entities;
using Lab6.Api.Entities.Relations;
using Microsoft.EntityFrameworkCore;

namespace Lab6.Api.Dal;

public class LabDbContext : DbContext
{
    public DbSet<Address> Addresses => Set<Address>();
    public DbSet<BrandNameMedication> BrandNameMedications => Set<BrandNameMedication>();
    public DbSet<Customer> Customers => Set<Customer>();
    public DbSet<Doctor> Doctors => Set<Doctor>();
    public DbSet<GenericMedication> GenericMedications => Set<GenericMedication>();
    public DbSet<ItemOrdered> ItemsOrdered => Set<ItemOrdered>();
    public DbSet<Medication> Medications => Set<Medication>();
    public DbSet<PharmaceuticalCompany> PharmaceuticalCompanies => Set<PharmaceuticalCompany>();
    public DbSet<Prescription> Prescriptions => Set<Prescription>();
    public DbSet<PrescriptionItem> PrescriptionItems => Set<PrescriptionItem>();
    public DbSet<GenericToBrandNameCorrespondence> GenericToBrandNameCorrespondences => Set<GenericToBrandNameCorrespondence>();

    public LabDbContext(DbContextOptions<LabDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(LabDbContext).Assembly);

        base.OnModelCreating(modelBuilder);
    }
}
