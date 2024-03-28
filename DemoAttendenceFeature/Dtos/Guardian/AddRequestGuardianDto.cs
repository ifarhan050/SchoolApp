namespace DemoAttendenceFeature.Dtos.Guardian
{
    public class AddRequestGuardianDto
    {
        public string Name { get; set; }
        public string Phone { get; set; }
        public string? Email { get; set; }
        public string Address { get; set; }
        public string Gender { get; set; }
        public string Type { get; set; }
        public string Occupation { get; set; }
        public string? Organization { get; set; }

        public string Nic { get; set; }


        //Image Fields
        public IFormFile? NicImage { get; set; }
        public IFormFile? GuardianImage { get; set; }
    }
}
