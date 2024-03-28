using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DemoAttendenceFeature.Entities
{
    [Table("Guardian")]
    public class Guardian
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }

        public string Type { get; set; }
        public string Address { get; set; }
        public string Gender { get; set; }
        public string Occupation { get; set; }
        public string? Organization { get; set; }

        public string Nic { get; set; }


        //Image Fields
        public string? NicImageUrl { get; set; }
        public string? GuardianImageUrl { get; set; }
        public ICollection<Student> Students { get; set; }
    }
}
