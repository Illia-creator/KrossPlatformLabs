using Lab6.Api.Abstractions;
using Lab6.Api.Entities.Relations;

namespace Lab6.Api.Entities;

public class GenericMedication : BaseEntity
{
    public GenericMedication(string id, string genericMedicationsDetails, string medicationId) : base(id)
    {
        GenericMedicationsDetails = genericMedicationsDetails;
        MedicationId = medicationId;
    }
    public string GenericMedicationsDetails {  get; }

    public string MedicationId { get; }

    public Medication Medication { get; }
    public List<GenericToBrandNameCorrespondence> GenericToBrandNameCorrespondences { get; } = new List<GenericToBrandNameCorrespondence>();
}
