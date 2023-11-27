using Lab6.Api.Abstractions;
using Lab6.Api.Entities.Enums;

namespace Lab6.Api.Entities;

public class Medication : BaseEntity
{
    public Medication(
       string id,
       RefMedicationType medicationTypeCode,
       string medicationName,
       string medicationDescription,
       double medicationCost,
       string medicationOtherDetails) : base(id)
    {
        MedicationTypeCode = medicationTypeCode;
        MedicationName = medicationName;
        MedicationDescription = medicationDescription;
        MedicationCost = medicationCost;
        MedicationOtherDetails = medicationOtherDetails;
    }
    public RefMedicationType MedicationTypeCode { get; }
    public string MedicationName { get; }
    public string MedicationDescription { get; }
    public double MedicationCost { get; }
    public string MedicationOtherDetails { get; }

    public GenericMedication GenericMedication { get; }
    public List<PrescriptionItem> PrescriptionItems { get; } = new List<PrescriptionItem>();
    public List<ItemOrdered> ItemsOrdered { get; } = new List<ItemOrdered>();

}
