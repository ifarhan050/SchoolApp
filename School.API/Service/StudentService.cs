using AutoMapper;
using DemoAttendenceFeature.Dtos.Student;
using DemoAttendenceFeature.Entities;
using DemoAttendenceFeature.Helper.Constant_Enums;
using DemoAttendenceFeature.Infrastructure.Interface;
using DemoAttendenceFeature.Utility.Interface;

namespace DemoAttendenceFeature.Service
{
    public class StudentService
    {
        private readonly IStudentRepository _studentRepository;
        private readonly IImageTransaction _imageTransaction;
        private readonly IMapper _mapper;

        public StudentService(IStudentRepository studentRepository, IMapper mapper, IImageTransaction imageTransaction)
        {
            _studentRepository = studentRepository;
            _mapper = mapper;
            _imageTransaction = imageTransaction;
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
        public async Task<GetResponseStudentDto> CreateStudent(AddRequestStudentdto createStudentDto)
        {
            var student = _mapper.Map<Student>(createStudentDto);
            student.AdmissionStatus = new StudentAdmissionStatus() { Status = AdmissionStatusEnum.Registered.ToString() };
            var guidId= Guid.NewGuid().ToString();
            student.NicImageUrl = createStudentDto?.NicImage!=null?await _imageTransaction.UploadImage(createStudentDto.NicImage, $"{nameof(Student)}_{guidId}", guidId):null;
            student.StudentImageUrl = createStudentDto?.StudentImage!=null?await _imageTransaction.UploadImage(createStudentDto.StudentImage, $"{nameof(Student)}_{guidId}", guidId):null;
            student.BirthCertificateImageUrl = createStudentDto?.BirthCertificateImage!=null?await _imageTransaction.UploadImage(createStudentDto.BirthCertificateImage, $"{nameof(Student)}_{guidId}", guidId):null;
            var studentguradiandtoarray=createStudentDto.Guardians.ToArray();
            var studentguardiansarray = student.Guardians.ToArray();
            for (int i = 0;i< studentguradiandtoarray?.Length; i++)
            {
                studentguardiansarray[i].NicImageUrl = studentguradiandtoarray[i]?.NicImage != null ?
                    await _imageTransaction.UploadImage(createStudentDto.NicImage, $"{nameof(Student)}_{student.Name}", guidId) : null;
                studentguardiansarray[i].GuardianImageUrl = studentguradiandtoarray[i]?.NicImage != null ?
                   await _imageTransaction.UploadImage(createStudentDto.NicImage, $"{nameof(Student)}_{student.Name}", guidId) : null;
            }
            student.Guardians = studentguardiansarray.ToList();
            student=await _studentRepository.CreateStudent(student);
            var studentDto = _mapper.Map<GetResponseStudentDto>(student);
            return studentDto;
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
                var guidId = Guid.NewGuid().ToString();
                student.NicImageUrl = requestDto?.NicImage != null ? await _imageTransaction.UploadImage(requestDto.NicImage, $"{nameof(Student)}_{guidId}", guidId) : null;
                student.StudentImageUrl = requestDto?.StudentImage != null ? await _imageTransaction.UploadImage(requestDto.StudentImage, $"{nameof(Student)}_{guidId}", guidId) : null;
                student.BirthCertificateImageUrl = requestDto?.BirthCertificateImage != null ? await _imageTransaction.UploadImage(requestDto.BirthCertificateImage, $"{nameof(Student)}_{guidId}", guidId) : null;
                var studentguradiandtoarray = requestDto.Guardians.ToArray();
                var studentguardiansarray = student.Guardians.ToArray();
                for (int i = 0; i < studentguradiandtoarray?.Length; i++)
                {
                    studentguardiansarray[i].NicImageUrl = studentguradiandtoarray[i]?.NicImage != null ?
                        await _imageTransaction.UploadImage(requestDto.NicImage, $"{nameof(Student)}_{student.Name}", guidId) : null;
                    studentguardiansarray[i].GuardianImageUrl = studentguradiandtoarray[i]?.NicImage != null ?
                       await _imageTransaction.UploadImage(requestDto.NicImage, $"{nameof(Student)}_{student.Name}", guidId) : null;
                }
                student.Guardians = studentguardiansarray.ToList();
                await _studentRepository.UpdateStudent(student);
                var studentDto=_mapper.Map<GetResponseStudentDto>(student);
                return studentDto;
            }
            return null;
        }


    }
}
