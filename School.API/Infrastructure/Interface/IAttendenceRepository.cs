using DemoAttendenceFeature.Entities;

namespace DemoAttendenceFeature.Infrastructure.Interface
{
    public interface IAttendenceRepository
    {
        Task<Attendence?> CreateAttendence(Attendence attendence);
        Task<Attendence?> UpdateAttendence(Attendence attendence);
        Task<Attendence?> GetAttenceByDate(Guid studentId,DateTime dateTime);
        Task<List<Attendence>?> GetAllAttendenceByStudentId(Guid studentId);


    }
}
