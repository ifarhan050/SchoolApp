using AutoMapper;
using Azure.Core;
using DemoAttendenceFeature.Dtos.Admission;
using DemoAttendenceFeature.Dtos.Student;
using DemoAttendenceFeature.Entities;
using DemoAttendenceFeature.Helper.Constant_Enums;
using DemoAttendenceFeature.Infrastructure.Interface;

namespace DemoAttendenceFeature.Service
{
    public class AdmissionService
    {
        private readonly IStudentRepository _studentRepository;
        private readonly IAdmissionStudentStatusRepository _admissionStudentStatusRepository;
        private readonly IMapper _mapper;

        public AdmissionService(IStudentRepository studentRepository, IAdmissionStudentStatusRepository admissionStudentStatusRepository, IMapper mapper)
        {
            _studentRepository = studentRepository;
            _admissionStudentStatusRepository = admissionStudentStatusRepository;
            _mapper = mapper;
        }

        public async Task<GetResponseStudentDto?> CreateStudentApplication(AddRequestStudentdto requestDto)
        {
            var student = _mapper.Map<Student>(requestDto);
            student.AdmissionStatus = new StudentAdmissionStatus() { Status = AdmissionStatusEnum.Pending.ToString() };
            var studentId = await _studentRepository.CreateStudent(student);
            if (studentId!=null)
            {
                var studentDto = _mapper.Map<GetResponseStudentDto>(student);
                return studentDto;
            }
            return null;
        }
        public async Task<GetResponseStudentAdmissionDto?> RegisterApplication(Guid studentId)
        {
            var admissionStatus=await _admissionStudentStatusRepository.GetStatus(studentId,true);
            if (admissionStatus != null)
            {
                admissionStatus.Status = AdmissionStatusEnum.Registered.ToString();
                var isRegistered=await _admissionStudentStatusRepository.UpdateStatus(admissionStatus);
                var admissionStatusDto=isRegistered?_mapper.Map<GetResponseStudentAdmissionDto>(admissionStatus):null;
                return admissionStatusDto;               
            }
            return null;
        }

        //public async Task<List<GetResponseStudentAdmissionDto>?> GetAll
    }
}
