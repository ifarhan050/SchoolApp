namespace DemoAttendenceFeature.Dtos.Attendence
{
    public class GetRequestSingleAttendeceDto
    {
        public Guid studentId { get; set; }
        public DateTime DateTime { get; set; } = DateTime.Now;
    }
}
