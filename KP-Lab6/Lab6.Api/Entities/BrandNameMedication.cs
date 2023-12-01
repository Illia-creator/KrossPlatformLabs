using Lab6.Api.Abstractions;
using Lab6.Api.Entities.Relations;

namespace Lab6.Api.Entities;

public class BrandNameMedication : BaseEntity
{
    public BrandNameMedication(
        string id,
        string companyId,
        string brandMedicationName,
        string brandMedicationCost,
        string brandMedicationDescription) : base (id)
    {
        CompanyId = companyId;
        BrandMedicationName = brandMedicationName;
        BrandMedicationCost = brandMedicationCost;
        BrandMedicationDescription = brandMedicationDescription;
    }
    public string CompanyId { get; }
    public string BrandMedicationName { get; }
    public string BrandMedicationCost { get; }
    public string BrandMedicationDescription { get; }

    public PharmaceuticalCompany PharmaceuticalCompany { get; }
    public List<GenericToBrandNameCorrespondence> GenericToBrandNameCorrespondences { get; } = new List<GenericToBrandNameCorrespondence>();

}
