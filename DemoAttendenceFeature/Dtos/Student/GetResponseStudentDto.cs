using DemoAttendenceFeature.Dtos.Guardian;

namespace DemoAttendenceFeature.Dtos.Student
{
    public class GetResponseStudentDto
    {
        public Guid Id { get; set; }
        public int RollNo { get; set; }
        public string Name { get; set; }

        public string? Class { get; set; }
        public int Age { get; set; }

        public string Email { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Gender { get; set; }

        //Extra Fields
        public string? Nic { get; set; }
        public string? Nationality { get; set; }
        public string? PermenantAddress { get; set; }
        public string? ResidentialAddress { get; set; }
        public string? City { get; set; }
        public string? Area { get; set; }
        public string? Phone { get; set; }

        public string? CurrentStatus { get; set; }



        //Image Fields
        public string? StudentImageUrl { get; set; }
        public string? BirthCertificateImageUrl { get; set; }
        public string? NicImageUrl { get; set; }

        public GetResponseAdmissionDto? AdmissionStatus { get; set; }
        public GetResponseEmergencyContactInfoDto? StudentEmergencyContactInfo { get; set; }
        public GetResponseEducationInfoDto? StudentEducationInfo { get; set; }
        public GetResponseStudentMedicalInfoDto? StudentMedicalInfo { get; set; }
        public IEnumerable<GetResponseGuardianDto> Guardians { get; set; }
    }

    public class GetResponseAdmissionDto
    {
        public int Id { get; set; }
        public string Status { get; set; }
    }
    public class GetResponseEmergencyContactInfoDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Email { get; set; }
        public string RelationShipType { get; set; }
        public string Phone { get; set; }
        public string? HomeAddress { get; set; }
    }

    public class GetResponseEducationInfoDto
    {
        public int Id { get; set; }
        public string? Term { get; set; }
        public string? PreviouslyAttended { get; set; }
        public string? SchoolName { get; set; }
        public string? SchoolAddress { get; set; }
        public string? ReasonForLeaving { get; set; }
    }

    public class GetResponseStudentMedicalInfoDto
    {
        public int Id { get; set; }
        public bool hasDiabetes { get; set; }
        public bool hasPhysicalDisability { get; set; }
        public bool hasHearingImpairment { get; set; }
        public bool hasVisualImpairment { get; set; }
        public bool hasAllergy { get; set; }
    }
}
