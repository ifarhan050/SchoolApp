using AutoMapper;
using DemoAttendenceFeature.Dtos.Student;
using DemoAttendenceFeature.Entities;
using DemoAttendenceFeature.Helper.Constant_Enums;
using DemoAttendenceFeature.Infrastructure.Interface;

namespace DemoAttendenceFeature.Service
{
    public class StudentService
    {
        private readonly IStudentRepository _studentRepository;
        private readonly IMapper _mapper;

        public StudentService(IStudentRepository studentRepository, IMapper mapper)
        {
            _studentRepository = studentRepository;
            _mapper = mapper;
        }

        public async Task<GetResponseStudentDto?> GetStudentById(Guid id)
        {
            var student=await _studentRepository.GetStudentById(id,true);
            if(student!=null)
            {
                var studentDto=_mapper.Map<GetResponseStudentDto>(student);
                return studentDto;
            }
            return null;
        }
        public async Task<Guid?> CreateStudent(AddRequestStudentdto createStudentDto)
        {
            var student = _mapper.Map<Student>(createStudentDto);
            student.AdmissionStatus = new StudentAdmissionStatus() { Status = AdmissionStatusEnum.Registered.ToString() };
            var studentId=await _studentRepository.CreateStudent(student);
            return studentId;
        }

        public async Task<IEnumerable<GetResponseStudentDto>?> GetAllStudents()
        {
            var students=await _studentRepository.GetAllStudents(true);
            if (students!=null)
            {
                var studentsDto = _mapper.Map<List<GetResponseStudentDto>>(students);
                return studentsDto;
            }
            return null;
        }

        public async Task<bool> DeleteStudent(Guid studentid)
        {
            var student = await _studentRepository.GetStudentById(studentid);
            if (student != null)
            {
                return await _studentRepository.DeleteStudent(student);
            }
            return false;
        }

        public async Task<GetResponseStudentDto?> UpdateStudent(Guid studentid,AddRequestStudentdto requestDto)
        {
            var student = await _studentRepository.GetStudentById(studentid,true);
            if (student != null)
            { 
                _mapper.Map(requestDto, student);
                await _studentRepository.UpdateStudent(student);
                var studentDto=_mapper.Map<GetResponseStudentDto>(student);
                return studentDto;
            }
            return null;
        }


    }
}
