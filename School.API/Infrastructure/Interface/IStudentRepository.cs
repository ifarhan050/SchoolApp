using DemoAttendenceFeature.Entities;

namespace DemoAttendenceFeature.Infrastructure.Interface
{
    public interface IStudentRepository
    {
        Task<Student> CreateStudent(Student student);
        Task<Student?> GetStudentById(Guid id, bool includeAll = false);
        Task<IEnumerable<Student>?> GetAllStudents(bool includeAll=false);
        Task<Student?> UpdateStudent(Student student);
        Task<bool> DeleteStudent(Student student);

        Task Save();
    }
}
