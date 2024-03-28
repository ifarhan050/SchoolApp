namespace DemoAttendenceFeature.Dtos.Attendence
{
    public class GetMultipleAttendenceResponsedto
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Class { get; set; }
        public int Age { get; set; }
        public int RollNo { get; set; }
        public string? Email { get; set; }
        public string Gender { get; set; }
        public DateTime DateOfBirth { get; set; }

        public IEnumerable<GetResponseAttendenceDto> Attendences { get; set; }
    }
}
