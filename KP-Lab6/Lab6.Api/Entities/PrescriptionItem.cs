namespace Lab6.Api.Entities;

public class PrescriptionItem
{
    public PrescriptionItem(
        string prescriptionId,
        string medicationId,
        int prestcriptionQuantity,
        string instructionsToCustomer
        )
    {
        PrescriptionId = prescriptionId;
        MedicationId = medicationId;
        PrestcriptionQuantity = prestcriptionQuantity;
        InstructionsToCustomer = instructionsToCustomer;
    }
    public string PrescriptionId { get; }
    public string MedicationId { get; }
    public int PrestcriptionQuantity { get; }
    public string InstructionsToCustomer { get; }

    public Prescription Prescription { get; }
    public Medication Medication { get; }
}
