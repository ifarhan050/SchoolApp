using DemoAttendenceFeature.Data;
using DemoAttendenceFeature.Entities;
using DemoAttendenceFeature.Infrastructure.Interface;
using Microsoft.EntityFrameworkCore;

namespace DemoAttendenceFeature.Infrastructure
{
    public class GuardianRepository : IGuardianRepository
    {
        private readonly AppDbContext _dbContext;

        public GuardianRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> CreateGuardian(Guardian guardian)
        {
            var guardiandata=await _dbContext.guardians.AddAsync(guardian);
            var result = await _dbContext.SaveChangesAsync();
            return result > 0 ? guardiandata.Entity.Id : -1;
        }

        public async Task<List<Guardian>?> GetAllGuardians()
        {
           return await _dbContext.guardians
                .Include(x=>x.Students)
                .ToListAsync();
        }

        public async Task<Guardian?> GetGuardianById(int id)
        {
            return await _dbContext.guardians.
                Where(x => x.Id == id)
                .Include(x => x.Students)
                .FirstOrDefaultAsync();
        }

        public async Task<int> UpdateGuradian(Guardian guardian)
        {
            _dbContext.guardians.Update(guardian);
            return await _dbContext.SaveChangesAsync(); 

        }
    }
}
