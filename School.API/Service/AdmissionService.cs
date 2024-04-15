using AutoMapper;
using Azure.Core;
using DemoAttendenceFeature.Dtos.Admission;
using DemoAttendenceFeature.Dtos.Student;
using DemoAttendenceFeature.Entities;
using DemoAttendenceFeature.Helper.Constant_Enums;
using DemoAttendenceFeature.Infrastructure.Interface;
using DemoAttendenceFeature.Utility.Interface;

namespace DemoAttendenceFeature.Service
{
    public class AdmissionService
    {
        private readonly IStudentRepository _studentRepository;
        private readonly IAdmissionStudentStatusRepository _admissionStudentStatusRepository;
        private readonly IImageTransaction _imageTransaction;
        private readonly IMapper _mapper;

        public AdmissionService(IStudentRepository studentRepository, IAdmissionStudentStatusRepository admissionStudentStatusRepository, IMapper mapper, IImageTransaction imagedTransaction)
        {
            _studentRepository = studentRepository;
            _admissionStudentStatusRepository = admissionStudentStatusRepository;
            _mapper = mapper;
            _imageTransaction = imagedTransaction;
        }

        public async Task<GetResponseStudentDto?> CreateStudentApplication(AddRequestStudentdto requestDto)
        {
            
            var student = _mapper.Map<Student>(requestDto);
            student.AdmissionStatus = new StudentAdmissionStatus() { Status = AdmissionStatusEnum.Pending.ToString() };
            var guidId = Guid.NewGuid().ToString();
            student.NicImageUrl = requestDto?.NicImage != null ? await _imageTransaction.UploadImage(requestDto.NicImage, $"{nameof(Student)}_{guidId}", guidId) : null;
            student.StudentImageUrl = requestDto?.StudentImage != null ? await _imageTransaction.UploadImage(requestDto.StudentImage, $"{nameof(Student)}_{guidId}", guidId) : null;
            student.BirthCertificateImageUrl = requestDto?.BirthCertificateImage != null ? await _imageTransaction.UploadImage(requestDto.BirthCertificateImage, $"{nameof(Student)}_{guidId}", guidId) : null;
            var studentguradiandtoarray = requestDto.Guardians.ToArray();
            var studentguardiansarray = student.Guardians.ToArray();
            for (int i = 0; i < studentguradiandtoarray?.Length; i++)
            {
                studentguardiansarray[i].NicImageUrl = studentguradiandtoarray[i]?.NicImage != null ?
                    await _imageTransaction.UploadImage(requestDto.NicImage, $"{nameof(Student)}_{guidId}", guidId) : null;
                studentguardiansarray[i].GuardianImageUrl = studentguradiandtoarray[i]?.NicImage != null ?
                   await _imageTransaction.UploadImage(requestDto.NicImage, $"{nameof(Student)}_{guidId}", guidId) : null;
            }
            student.Guardians = studentguardiansarray.ToList();
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
