using Lab6.Api.Entities;
using Lab6.Api.Entities.Enums;
using Lab6.Api.Entities.Relations;
using Microsoft.EntityFrameworkCore;

namespace Lab6.Api.Dal;


public class LabDbInitializer 
{
    private readonly LabDbContext _context;

    public LabDbInitializer(LabDbContext context)
    {
        _context = context;
        Initialize();
    }

    public async void Initialize()
    {
        if (_context.Addresses.ToList().Any())
            return;

        Address address1 = new Address(
        id: "1",
        line1NumberBuilding: "TestLine1s",
        line2NumberBuilding: "Line2",
        line3NumberBuilding: "Line3",
        city: "City1",
        zipPostCode: "0001",
        stateProvinceCountry: "State1",
        country: "USA",
        otherAddressDetails: "Details1");

        Address address2 = new Address(
            id: "2",
            line1NumberBuilding: "TestLine2s",
            line2NumberBuilding: "Line2",
            line3NumberBuilding: "Line3",
            city: "City2",
            zipPostCode: "0002",
            stateProvinceCountry: "State2",
            country: "USA",
            otherAddressDetails: "Details2");

        Address address3 = new Address(
            id: "3",
            line1NumberBuilding: "TestLine3s",
            line2NumberBuilding: "Line2",
            line3NumberBuilding: "Line3",
            city: "City3",
            zipPostCode: "0003",
            stateProvinceCountry: "State3",
            country: "USA",
            otherAddressDetails: "Details3");

        _context.Addresses.AddRange(address1, address2, address3);

        Medication medication1 = new Medication(
       id: "1",
       medicationTypeCode: RefMedicationType.Vitalix,
       medicationName: "Medication1",
       medicationDescription: "Description1",
       medicationCost: 10.99,
       medicationOtherDetails: "Details1");

        Medication medication2 = new Medication(
            id: "2",
            medicationTypeCode: RefMedicationType.HealZen,
            medicationName: "Medication2",
            medicationDescription: "Description2",
            medicationCost: 20.49,
            medicationOtherDetails: "Details2");

        Medication medication3 = new Medication(
            id: "3",
            medicationTypeCode: RefMedicationType.Vitalix,
            medicationName: "Medication3",
            medicationDescription: "Description3",
            medicationCost: 15.75,
            medicationOtherDetails: "Details3");

        _context.Medications.AddRange(medication1, medication2, medication3);

        GenericMedication genericMedication1 = new GenericMedication(
        id: "1",
        genericMedicationsDetails: "Details1",
        medicationId: "1");

        GenericMedication genericMedication2 = new GenericMedication(
            id: "2",
            genericMedicationsDetails: "Details2",
            medicationId: "2");

        GenericMedication genericMedication3 = new GenericMedication(
            id: "3",
            genericMedicationsDetails: "Details3",
            medicationId: "3");

        _context.GenericMedications.AddRange(genericMedication1, genericMedication2, genericMedication3);

        PharmaceuticalCompany company1 = new PharmaceuticalCompany(
        id: "1",
        companyName: "CompanyTest1",
        companyOtherDetails: "Details1");

        PharmaceuticalCompany company2 = new PharmaceuticalCompany(
            id: "2",
            companyName: "CompanyTest2",
            companyOtherDetails: "Details2");

        PharmaceuticalCompany company3 = new PharmaceuticalCompany(
            id: "3",
            companyName: "CompanyTest3",
            companyOtherDetails: "Details3");

        _context.PharmaceuticalCompanies.AddRange(company1, company2, company3);

        BrandNameMedication brandMedication1 = new BrandNameMedication(
      id: "1",
      companyId: "1",
      brandMedicationName: "MedicationTest1",
      brandMedicationCost: "10.99",
      brandMedicationDescription: "Description1");

        BrandNameMedication brandMedication2 = new BrandNameMedication(
            id: "2",
            companyId: "2",
            brandMedicationName: "MedicationTest2",
            brandMedicationCost: "20.49",
            brandMedicationDescription: "Description2");

        BrandNameMedication brandMedication3 = new BrandNameMedication(
            id: "3",
            companyId: "3",
            brandMedicationName: "MedicationTest3",
            brandMedicationCost: "15.75",
            brandMedicationDescription: "Description3");

        _context.BrandNameMedications.AddRange(brandMedication1, brandMedication2, brandMedication3);

        GenericToBrandNameCorrespondence correspondence1 = new GenericToBrandNameCorrespondence(
       brandNameMedicationId: "1",
       genericMedicationsId: "1");

        GenericToBrandNameCorrespondence correspondence2 = new GenericToBrandNameCorrespondence(
            brandNameMedicationId: "2",
            genericMedicationsId: "2");

        GenericToBrandNameCorrespondence correspondence3 = new GenericToBrandNameCorrespondence(
            brandNameMedicationId: "3",
            genericMedicationsId: "3");

        _context.GenericToBrandNameCorrespondences.AddRange(correspondence1, correspondence2, correspondence3);


        _context.SaveChanges();

    }
}

