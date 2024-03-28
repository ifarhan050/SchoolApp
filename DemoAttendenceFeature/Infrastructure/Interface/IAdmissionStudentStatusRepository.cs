using DemoAttendenceFeature.Entities;

namespace DemoAttendenceFeature.Infrastructure.Interface
{
    public interface IAdmissionStudentStatusRepository
    {
         Task<bool> UpdateStatus(StudentAdmissionStatus studentAdmissionStatus);
         Task<StudentAdmissionStatus?> GetStatus(Guid studentId, bool includeAll = false);

         Task<List<StudentAdmissionStatus>?> GetAllStatus(string? status=null);



    }
}
