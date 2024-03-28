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
        public ICollection<Student> Students { get; set; }
    }
}
