namespace DemoAttendenceFeature.Dtos.Attendence
{
    public class GetResponseAttendenceDto
    {
        public int Id { get; set; }
        public DateTime TimeIn { get; set; }
        public DateTime? TimeOut { get; set; } = null;
    }
}
