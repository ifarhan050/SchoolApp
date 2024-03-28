using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DemoAttendenceFeature.Entities
{
    [Table("StudentEmergencyContactInfo")]
    public class StudentEmergencyContactInfo
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Email { get; set; }
        public string RelationShipType { get; set; }
        public string Phone { get; set; }
        public string? HomeAddress { get; set; }

        public Guid StudentId { get; set; }
        public Student Student { get; set; }

    }
}
