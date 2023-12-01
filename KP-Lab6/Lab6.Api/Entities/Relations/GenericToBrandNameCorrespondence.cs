namespace Lab6.Api.Entities.Relations
{
    public class GenericToBrandNameCorrespondence
    {
        public GenericToBrandNameCorrespondence()
        {

        }
        public GenericToBrandNameCorrespondence(string brandNameMedicationId, string genericMedicationsId)
        {
            BrandNameMedicationId = brandNameMedicationId;
            GenericMedicationId = genericMedicationsId;
        }
        public string BrandNameMedicationId { get; }
        public string GenericMedicationId { get; }

        public BrandNameMedication BrandNameMedication { get; }
        public GenericMedication GenericMedication { get; }

    }
}
