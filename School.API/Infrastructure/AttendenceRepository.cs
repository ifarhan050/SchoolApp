using DemoAttendenceFeature.Data;
using DemoAttendenceFeature.Entities;
using DemoAttendenceFeature.Infrastructure.Interface;
using Microsoft.EntityFrameworkCore;

namespace DemoAttendenceFeature.Infrastructure
{
    public class AttendenceRepository : IAttendenceRepository
    {
        private readonly AppDbContext _dbContext;

        public AttendenceRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Attendence?> CreateAttendence(Attendence attendence)
        {
            await _dbContext.attendences.AddAsync(attendence);
            var result=await _dbContext.SaveChangesAsync();
            return result > 0 ? attendence : null;
        }

        public async Task<List<Attendence>?> GetAllAttendenceByStudentId(Guid studentId)
        {
            var attendences = await _dbContext.attendences
                              .Where(x => x.StudentId == studentId)
                              .Include(x => x.Student)
                              .ToListAsync();
            if (attendences!=null)
            {
                return attendences;
            }
            return null;
        }

        public async Task<Attendence?> GetAttenceByDate(Guid studentId, DateTime dateTime)
        {
            var attendece = await _dbContext.attendences
                    .Where(x => x.StudentId == studentId && x.TimeIn.Date == dateTime.Date)
                    .Include(x => x.Student)
                    .Include (x => x.Student.Guardians)
                    .FirstOrDefaultAsync();
            if (attendece != null)
            {
              return attendece;
            }
            return null;

        }

        public async Task<Attendence?> UpdateAttendence(Attendence attendence)
        {
            _dbContext.attendences.Update(attendence);
            var result = await _dbContext.SaveChangesAsync();
            return result > 0 ? attendence : null;
        }
    }
}
