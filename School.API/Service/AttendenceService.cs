using AutoMapper;
using DemoAttendenceFeature.Dtos.Attendence;
using DemoAttendenceFeature.Entities;
using DemoAttendenceFeature.Infrastructure.Interface;

namespace DemoAttendenceFeature.Service
{
    public class AttendenceService
    {
        private readonly IAttendenceRepository _attendenceRepository;
        private readonly IStudentRepository _studentRepository;
        private readonly IMapper _mapper;

        public AttendenceService(IStudentRepository studentRepository, IMapper mapper, IAttendenceRepository attendenceRepository)
        {
            _studentRepository = studentRepository;
            _mapper = mapper;
            _attendenceRepository = attendenceRepository;
        }

        public async Task<GetSingleAttendenceResponseDto?> AddAttendence(Guid studentId)
        {
            var student=await _studentRepository.GetStudentById(studentId, true);
            if (student != null)
            {
                var attendence = await _attendenceRepository.GetAttenceByDate(studentId, DateTime.Now);
                if (attendence!=null)
                {
                     attendence.TimeOut = DateTime.Now;
                    await _attendenceRepository.UpdateAttendence(attendence);
                }
                else
                {
                    attendence = new Attendence()
                    {
                        StudentId = studentId,
                        TimeIn = DateTime.Now,
                    };
                    await _attendenceRepository.CreateAttendence(attendence);
                }
                var studentAttendenceDto = _mapper.Map<GetSingleAttendenceResponseDto>(attendence);
                return studentAttendenceDto;
            }
            return null;
        }


        public async Task<GetMultipleAttendenceResponsedto?> GetAllAttendence(Guid studentId)
        {
            var student=await _studentRepository.GetStudentById(studentId,true);
            if (student != null)
            {
                var studentsDto = _mapper.Map<GetMultipleAttendenceResponsedto>(student);
                return studentsDto;
            }
            return null;
        }

        public async Task<GetSingleAttendenceResponseDto?> GetSingleAttendence(Guid studentId,DateTime dateTime)
        {
            var attendence=await _attendenceRepository.GetAttenceByDate(studentId, dateTime);
            if (attendence!=null)
            {
                var attedenceDto =  _mapper.Map<GetSingleAttendenceResponseDto>(attendence);
                return attedenceDto;

            }
            return null;
        }

       





    }
}
