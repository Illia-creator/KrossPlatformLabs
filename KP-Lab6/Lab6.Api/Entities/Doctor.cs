using Lab6.Api.Abstractions;

namespace Lab6.Api.Entities;

public class Doctor : BaseEntity
{
    public Doctor(string id,
        string addressId,
        string doctorFirstName,
        string doctorLastName,
        string doctorPhone,
        string gender,
        string doctorEmail,
        string otherDoctorDetails) : base(id)
    {
        AddressId = addressId;
        DoctorFirstName = doctorFirstName;
        DoctorLastName = doctorLastName;
        DoctorPhone = doctorPhone;
        Gender = gender;
        DoctorEmail = doctorEmail;
        OtherDoctorDetails = otherDoctorDetails;
    }

    public string AddressId { get; }
    public string DoctorFirstName { get; }
    public string DoctorLastName { get; }
    public string Gender { get; }
    public string DoctorPhone { get; }
    public string DoctorEmail { get; }
    public string OtherDoctorDetails { get; }

    public Address Address { get; }
    public List<Prescription> Prescriptions { get; } = new List<Prescription>();
}

