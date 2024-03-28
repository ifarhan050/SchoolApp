using AutoMapper;
using DemoAttendenceFeature.Dtos.Admission;
using DemoAttendenceFeature.Dtos.Attendence;
using DemoAttendenceFeature.Dtos.Guardian;
using DemoAttendenceFeature.Dtos.Student;
using DemoAttendenceFeature.Entities;

namespace DemoAttendenceFeature.Mapping
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<Student, GetResponseStudentDto>().ReverseMap();
            CreateMap<Student, AddRequestStudentdto>().ReverseMap();

            CreateMap<Guardian,AddRequestGuardianDto>().ReverseMap();
            CreateMap<Guardian,GetResponseGuardianDto>().ReverseMap();
            //
           
            CreateMap<StudentMedicalInfo, AddRequestStudentMedicalInfoDto>()
               .ReverseMap();

            CreateMap<StudentEducationInfo, AddRequestEducationInfoDto>()
              .ReverseMap();

            CreateMap<StudentEmergencyContactInfo, AddRequestEmergencyContactInfoDto>()
              .ReverseMap();
            //


            CreateMap<Attendence,GetSingleAttendenceResponseDto>()
                .ReverseMap();

            CreateMap<Attendence, GetResponseAttendenceDto>()
                .ReverseMap();

            CreateMap<Student, GetMultipleAttendenceResponsedto>()
                .ReverseMap();

            CreateMap<StudentAdmissionStatus, GetResponseStudentAdmissionDto>()
                //.ForMember(dest=>dest.Student,opt=>opt.MapFrom(x=>x.Student))
                .ReverseMap();

            CreateMap<StudentAdmissionStatus, GetResponseAdmissionDto>()
                .ReverseMap();

            CreateMap<StudentMedicalInfo, GetResponseStudentMedicalInfoDto>()
               .ReverseMap();

            CreateMap<StudentEducationInfo, GetResponseEducationInfoDto>()
              .ReverseMap();

            CreateMap<StudentEmergencyContactInfo, GetResponseEmergencyContactInfoDto>()
              .ReverseMap();

        }
    }
}
