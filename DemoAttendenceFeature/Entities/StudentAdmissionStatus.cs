using DemoAttendenceFeature.Helper.Constant_Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DemoAttendenceFeature.Entities
{
    [Table("StudentAdmissionStatus")]
    public class StudentAdmissionStatus
    {
        [Key]
        public int Id { get; set; }
        public Guid StudentId { get; set; }
        public string Status { get; set; }=AdmissionStatusEnum.Pending.ToString();
        public Student Student { get; set; }
    }
}
