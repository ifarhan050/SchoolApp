﻿namespace DemoAttendenceFeature.Dtos.Guardian
{
    public class GetResponseGuardianDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }

        public string Type { get; set; }
        public string Address { get; set; }
        public string Gender { get; set; }
        public string Occupation { get; set; }
    }
}
