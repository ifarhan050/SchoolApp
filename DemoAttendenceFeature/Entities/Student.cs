using DemoAttendenceFeature.Helper.Constant_Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;

namespace DemoAttendenceFeature.Entities
{
    [Table("Student")]
    public class Student
    {
        [Key]
        public Guid Id { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RollNo { get; set; }
        public string Name { get; set; }
        
        public string? Class { get; set; }
        public int Age { get; set; }

        public string? Email { get; set; }
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

        public ICollection<Guardian> Guardians { get; set; }
        public ICollection<Attendence> Attendences { get; set; }

        //Extra Navigation
        public StudentAdmissionStatus? AdmissionStatus { get; set; }
        public StudentEmergencyContactInfo? StudentEmergencyContactInfo { get; set; }
        public StudentEducationInfo? StudentEducationInfo { get; set; }
        public StudentMedicalInfo? StudentMedicalInfo { get; set; }
    }
}
