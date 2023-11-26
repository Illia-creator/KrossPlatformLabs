using Lab6.Api.Abstractions;
using Lab6.Api.Entities.Relations;

namespace Lab6.Api.Entities;

public class GenericMedication : BaseEntity
{
    public GenericMedication(string id, string genericMedicationsDetails) : base(id)
    {
        GenericMedicationsDetails = genericMedicationsDetails;
    }
    public string GenericMedicationsDetails {  get; }

    public List<GenericToBrandNameCorrespondence> GenericToBrandNameCorrespondences { get; } = new List<GenericToBrandNameCorrespondence>();
}
