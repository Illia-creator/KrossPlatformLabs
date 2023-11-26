namespace Lab6.Api.Entities;

public class ItemOrdered 
{
    public ItemOrdered(
        string prescriptionId,
        string medicationId,
        DateOnly dateOrdered,
        int quantityOrdered,
        DateOnly dateReceived,
        int quantityReceived)
    {
        PrescriptionId = prescriptionId;
        MedicationId = medicationId;
        DateOrdered = dateOrdered;
        QuantityOrdered = quantityOrdered;
        DateReceived = dateReceived;
        QuantityReceived = quantityReceived;
    }

    public string PrescriptionId { get; }
    public string MedicationId { get; }
    public DateOnly DateOrdered { get; }    
    public int QuantityOrdered { get; }
    public DateOnly DateReceived { get; }
    public int QuantityReceived { get; }

    public Prescription Prescription { get; }
    public Medication Medication { get; }
}
