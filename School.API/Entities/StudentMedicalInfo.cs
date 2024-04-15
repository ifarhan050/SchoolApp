using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DemoAttendenceFeature.Entities
{
    [Table("StudentMedicalInfo")]
    public class StudentMedicalInfo
    {
        [Key]
        public int Id { get; set; }
        public bool hasDiabetes { get; set; }
        public bool hasPhysicalDisability { get; set; }
        public bool hasHearingImpairment { get; set; }
        public bool hasVisualImpairment { get; set; }
        public bool hasAllergy { get; set; }
        public Guid StudentId { get; set; }
        public Student Student { get; set; }
    }
}
