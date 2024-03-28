using AutoMapper;
using DemoAttendenceFeature.Dtos.Student;
using DemoAttendenceFeature.Infrastructure.Interface;

namespace DemoAttendenceFeature.Service
{
    public class GuardianStudentService
    {
        private readonly IStudentRepository _studentRepository;
        private readonly IGuardianRepository _guardianRepository;
        private readonly IMapper _mapper;
        public GuardianStudentService(IStudentRepository studentRepository, IGuardianRepository guardianRepository, IMapper mapper)
        {
            _studentRepository = studentRepository;
            _guardianRepository = guardianRepository;
            _mapper = mapper;
        }

        public async Task<GetResponseStudentDto?> AddGuardian(Guid studentId,int guardianId)
        {
            var student = await _studentRepository.GetStudentById(studentId,true);
            var guardian=await _guardianRepository.GetGuardianById(guardianId);
            if (student!=null && guardian!=null)
            {
                student.Guardians.Add(guardian);
                await _studentRepository.Save();
                var studentDto = _mapper.Map<GetResponseStudentDto>(student);
                return studentDto;
            }
            return null;
        }
    }
}
