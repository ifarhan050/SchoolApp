using DemoAttendenceFeature.Entities;

namespace DemoAttendenceFeature.Infrastructure.Interface
{
    public interface IGuardianRepository
    {
        public Task<Guardian?> GetGuardianById(int id);
        public Task<List<Guardian>?> GetAllGuardians();
        public Task<int> CreateGuardian(Guardian guardian);
        Task<int> UpdateGuradian(Guardian guardian);
    }
}
