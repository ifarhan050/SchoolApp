using DemoAttendenceFeature.Dtos.Guardian;
using DemoAttendenceFeature.Entities;

namespace DemoAttendenceFeature.Dtos.Student
{
    public class AddRequestStudentdto
    {
        public string Name { get; set; }
        public string Class { get; set; }
        public int Age { get; set; }
        public string Email { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Gender { get; set; }

        public string? Nic { get; set; }
        public string? Nationality { get; set; }
        public string? PermenantAddress { get; set; }
        public string? ResidentialAddress { get; set; }
        public string? City { get; set; }
        public string? Area { get; set; }
        public string? Phone { get; set; }

        public string? CurrentStatus { get; set; }

        //Image Fields
        public IFormFile? StudentImage { get; set; }
        public IFormFile? BirthCertificateImage { get; set; }
        public IFormFile? NicImage { get; set; }
        public AddRequestEmergencyContactInfoDto? StudentEmergencyContactInfo { get; set; }
        public AddRequestEducationInfoDto? StudentEducationInfo { get; set; }
        public AddRequestStudentMedicalInfoDto? StudentMedicalInfo { get; set; }


        public List<AddRequestGuardianDto> Guardians { get; set; }
    }

    public class AddRequestEmergencyContactInfoDto
    {
        public string Name { get; set; }
        public string? Email { get; set; }
        public string RelationShipType { get; set; }
        public string Phone { get; set; }
        public string? HomeAddress { get; set; }
    }

    public class AddRequestEducationInfoDto
    {
        public string? Term { get; set; }
        public string? PreviouslyAttended { get; set; }
        public string? SchoolName { get; set; }
        public string? SchoolAddress { get; set; }
        public string? ReasonForLeaving { get; set; }
    }

    public class AddRequestStudentMedicalInfoDto
    {
        public bool hasDiabetes { get; set; }
        public bool hasPhysicalDisability { get; set; }
        public bool hasHearingImpairment { get; set; }
        public bool hasVisualImpairment { get; set; }
        public bool hasAllergy { get; set; }
    }
}
