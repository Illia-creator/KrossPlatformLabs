using Lab6.Api.Entities.Enums;

namespace Lab6.Api.Entities.Responses;

public record MedicationResponse(
    string id, 
    string medicationName,
    string medicationDescriptionstring, 
    double medicationCost,
    string BrandMedicationName,
    string BrandMedicationCost,
    string BrandMedicationDescription
    );

