using DemoAttendenceFeature.Dtos.Student;

namespace DemoAttendenceFeature.Dtos.Attendence
{
    public class GetSingleAttendenceResponseDto
    {
        public int Id { get; set; }
        public DateTime TimeIn { get; set; } = DateTime.Now;
        public DateTime? TimeOut { get; set; } = null;
        public GetResponseStudentDto Student { get; set; }
    }
}
