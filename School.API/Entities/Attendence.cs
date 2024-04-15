using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DemoAttendenceFeature.Entities
{
    [Table("Attendence")]
    public class Attendence
    {
        [Key]
        public int Id { get; set; }
        public DateTime TimeIn  { get; set; }=DateTime.Now;
        public DateTime? TimeOut { get; set; }=null;
        public Guid StudentId { get; set; }
        public Student Student { get; set; }
    }
}
