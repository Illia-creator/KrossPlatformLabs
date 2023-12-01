using Lab6.Api.Abstractions;
using Lab6.Api.Entities.Enums;

namespace Lab6.Api.Entities;

public class Prescription : BaseEntity
{
    public Prescription(
      string id,
      string customerId,
      string doctorId,
      RefPrescriptionStatus prescriptionStatusCode,
      RefPaymantMethodCode paymentMethodCode,
      DateOnly datePrescriptionReceived,
      DateOnly datePrescriptionRenewal,
      DateOnly datePrescriptionSendToDoctor,
      DateOnly datePrescriptionProcessed,
      DateOnly datePrescriptionRecievedFromDoctor,
      DateOnly datePrescriptionSendToCompany,
      DateOnly datePrescriptionFilled,
      string otherPrescriptionDetails) : base(id)
    {
        CustomerId = customerId;
        DoctorId = doctorId;
        PrescriptionStatusCode = prescriptionStatusCode;
        PaymentMethodCode = paymentMethodCode;
        DatePrescriptionReceived = datePrescriptionReceived;
        DatePrescriptionRenewal = datePrescriptionRenewal;
        DatePrescriptionSendToDoctor = datePrescriptionSendToDoctor;
        DatePrescriptionProcessed = datePrescriptionProcessed;
        DatePrescriptionRecievedFromDoctor = datePrescriptionRecievedFromDoctor;
        DatePrescriptionSendToCompany = datePrescriptionSendToCompany;
        DatePrescriptionFilled = datePrescriptionFilled;
        OtherPrescriptionDetails = otherPrescriptionDetails;
    }
    public string CustomerId { get; }
    public string DoctorId { get; }
    public RefPrescriptionStatus PrescriptionStatusCode { get; }
    public RefPaymantMethodCode PaymentMethodCode { get; }
    public DateOnly DatePrescriptionReceived { get; }
    public DateOnly DatePrescriptionRenewal { get; }
    public DateOnly DatePrescriptionSendToDoctor { get; }
    public DateOnly DatePrescriptionProcessed { get; }
    public DateOnly DatePrescriptionRecievedFromDoctor { get; }
    public DateOnly DatePrescriptionSendToCompany { get; }
    public DateOnly DatePrescriptionFilled { get; }
    public string OtherPrescriptionDetails { get; }

    public Customer Customer { get; }
    public Doctor Doctor { get; }
    public List<PrescriptionItem> PrescriptionItems { get; } = new List<PrescriptionItem>();
    public List<ItemOrdered> ItemsOrdered { get; } = new List<ItemOrdered>();
}
