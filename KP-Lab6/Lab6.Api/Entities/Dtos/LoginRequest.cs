using Microsoft.AspNetCore.Mvc.Rendering;

namespace Lab6.Api.Entities.Dtos;

public record LoginRequest(string UserFirstName, string UserLastName, string Password);
public record AuthResponse(string CustomerId, string UserLastName, string AccessToken, long Expires);

public record RegisterCustomerRequest(
    string Line1NumberBuilding,
    string CustomerFirstName,
    string CustomerLastName,
    string CustomerPhone,
    string CustomerPassword,
    DateOnly DateOriginalyJoined,
    string CreditCardNumber,
    DateOnly DateCardExpiry,
    string OtherCustomerDetails
   );