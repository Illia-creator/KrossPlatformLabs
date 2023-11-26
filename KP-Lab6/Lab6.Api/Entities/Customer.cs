using Lab6.Api.Abstractions;

namespace Lab6.Api.Entities;

public class Customer : BaseEntity
{
    public Customer(string id,
        string addressId,
        string customerFirstName,
        string customerLastName,
        string customerPhone,
        DateOnly dateOriginalyJoined,
        string creditCardNumber,
        DateOnly dateCardExpiry,
        string otherCustomerDetails) : base(id)
    {
        AddressId = addressId;
        CustomerFirstName = customerFirstName;
        CustomerLastName = customerLastName;
        CustomerPhone = customerPhone;
        DateOriginalyJoined = dateOriginalyJoined;
        CreditCardNumber = creditCardNumber;
        DateCardExpiry = dateCardExpiry;
        OtherCustomerDetails = otherCustomerDetails;
    }

    public string AddressId { get; }
    public string CustomerFirstName { get; }
    public string CustomerLastName { get; }
    public string CustomerPhone { get; }
    public DateOnly DateOriginalyJoined { get; }
    public string CreditCardNumber { get; }
    public DateOnly DateCardExpiry { get; }
    public string OtherCustomerDetails { get; }

    public Address Address { get; set; }
    public List<Prescription> Prescriptions { get; } = new List<Prescription>();
}
