using Lab6.Api.Abstractions;

namespace Lab6.Api.Entities;

public class PharmaceuticalCompany : BaseEntity
{
    public PharmaceuticalCompany(string id, string companyName, string companyOtherDetails) : base(id)
    {
        CompanyName = companyName;
        CompanyOtherDetails = companyOtherDetails;
    }

    public string CompanyName { get; set; }
    public string CompanyOtherDetails { get; set;}

    public List<BrandNameMedication> BrandNameMedications { get; }
}
