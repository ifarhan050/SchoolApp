using DemoAttendenceFeature.Dtos.Student;

namespace DemoAttendenceFeature.Dtos.Admission
{
    public class GetResponseStudentAdmissionDto
    {
        public int Id { get; set; }
        public GetResponseStudentDto Student { get; set; }
        public string Status { get; set; }
    }
}
