using Lab6.Api.Abstractions;

namespace Lab6.Api.Entities;

public class Address : BaseEntity
{
    public Address()
    {
        
    }
    public Address(
        string id,
        string line1NumberBuilding,
        string line2NumberBuilding,
        string line3NumberBuilding,
        string city,
        string zipPostCode,
        string stateProvinceCountry,
        string country,
        string otherAddressDetails) : base(id)
    {
        Line1NumberBuilding = line1NumberBuilding;
        Line2NumberBuilding = line2NumberBuilding;
        Line3NumberBuilding = line3NumberBuilding;
        City = city;
        ZipPostCode = zipPostCode;
        StateProvinceCountry = stateProvinceCountry;
        Country = country;
        OtherAddressDetails = otherAddressDetails;
    }

    public string Line1NumberBuilding { get; }
    public string Line2NumberBuilding { get; }
    public string Line3NumberBuilding { get; }
    public string City { get; }
    public string ZipPostCode { get; }
    public string StateProvinceCountry { get; }
    public string Country { get; }
    public string OtherAddressDetails { get; }

    public List<Customer> Customers { get; set; } = new List<Customer>();
    public List<Doctor> Doctors { get; set; } = new List<Doctor>();
}
