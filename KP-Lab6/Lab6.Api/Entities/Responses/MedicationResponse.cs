using Lab6.Api.Entities.Enums;

namespace Lab6.Api.Entities.Responses;

public record MedicationResponse(
    string id, 
    RefMedicationType medicationTypeCode,
    string medicationName,
    string medicationDescriptionstring, 
    double medicationCost,
    string medicationOtherDetails
    );
