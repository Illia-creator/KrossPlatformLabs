using Lab6.Api.Entities.Enums;

namespace Lab6.Api.Entities.Responses;

public record MedicationResponse(
    string id, 
    string medicationName,
    string medicationDescription, 
    double medicationCost,
    string brandMedicationName,
    string brandMedicationCost,
    string brandMedicationDescription
    );

