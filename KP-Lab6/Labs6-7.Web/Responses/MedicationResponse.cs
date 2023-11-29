namespace Labs6_7.Web.Responses
{
    public record MedicationResponse(
    string id,
    string medicationName,
    string medicationDescription,
    double medicationCost,
    string brandMedicationName,
    string brandMedicationCost,
    string brandMedicationDescription
    );
}
