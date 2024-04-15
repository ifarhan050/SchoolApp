using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DemoAttendenceFeature.Entities
{
    [Table("StudentEducationInfo")]
    public class StudentEducationInfo
    {
        [Key]
        public int Id { get; set; }
        public string? Term { get; set; }
        public string? PreviouslyAttended { get; set; }
        public string? SchoolName { get; set; }
        public string? SchoolAddress { get; set; }
        public string? ReasonForLeaving { get; set; }

        public Guid StudentId { get; set; }
        public Student Student { get; set; }
    }
}
