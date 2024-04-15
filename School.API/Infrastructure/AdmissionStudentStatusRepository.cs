using DemoAttendenceFeature.Data;
using DemoAttendenceFeature.Entities;
using DemoAttendenceFeature.Infrastructure.Interface;
using Microsoft.EntityFrameworkCore;

namespace DemoAttendenceFeature.Infrastructure
{
    public class AdmissionStudentStatusRepository : IAdmissionStudentStatusRepository
    {
        private AppDbContext _dbContext;
        public AdmissionStudentStatusRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<StudentAdmissionStatus>?> GetAllStatus(string? status=null)
        {
            if (status == null)
            {
               return await _dbContext.studentAdmissionStatus
                    .Include(x => x.Student)
                    .ToListAsync();
            }
            return await _dbContext.studentAdmissionStatus
                   .Where(x=>x.Status==status)
                   .Include(x => x.Student)
                   .ToListAsync();
        }

        public async Task<StudentAdmissionStatus?> GetStatus(Guid studentId,bool includeAll=false)
        {
            if (includeAll)
            {
                return await _dbContext.studentAdmissionStatus
                    .Include(x=>x.Student)
                    .FirstOrDefaultAsync(x=>x.StudentId==studentId);  
            }
            return await _dbContext.studentAdmissionStatus
                    .FirstOrDefaultAsync(x => x.StudentId == studentId);
        }

        public async Task<bool> UpdateStatus(StudentAdmissionStatus studentAdmissionStatus)
        {
            _dbContext.studentAdmissionStatus.Update(studentAdmissionStatus);
            return await _dbContext.SaveChangesAsync()>0;
        }
    }
}
