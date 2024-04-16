using DemoAttendenceFeature.Data;
using DemoAttendenceFeature.Entities;
using DemoAttendenceFeature.Helper.Constant_Enums;
using DemoAttendenceFeature.Infrastructure.Interface;
using Microsoft.EntityFrameworkCore;

namespace DemoAttendenceFeature.Infrastructure
{
    public class StudentRepository : IStudentRepository
    {
        private readonly AppDbContext _dbContext;

        public StudentRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Student> CreateStudent(Student student)
        {
            var studentdata=await _dbContext.students.AddAsync(student);
            var result=await _dbContext.SaveChangesAsync();
            return studentdata.Entity;
        }

        public async Task<IEnumerable<Student>?> GetAllStudents(bool inlcudeAll=false)
        {
            if (inlcudeAll)
            {
                return await _dbContext.students
                        .Include(x => x.Guardians)
                        .Include(x => x.Attendences)
                        .Include(x=>x.AdmissionStatus)
                        .Include(x=>x.StudentEmergencyContactInfo)
                        .Include(x=>x.StudentMedicalInfo)
                        .Include(x=>x.StudentEducationInfo)
                        .ToListAsync();
            }
            return await _dbContext.students
                        .Include(x => x.Guardians)
                        .ToListAsync();
        }


        public async Task<Student?> GetStudentById(Guid id, bool inlcudeAll = false)
        {
            if (inlcudeAll)
            {
               return await _dbContext.students
                    .Where(x=>x.Id==id)
                    .Include(x=>x.Guardians)
                    .Include(x=>x.Attendences)
                    .Include(x => x.AdmissionStatus)
                    .Include(x => x.StudentEmergencyContactInfo)
                    .Include(x => x.StudentMedicalInfo)
                    .Include(x => x.StudentEducationInfo)
                    .FirstOrDefaultAsync();
            }
            return await _dbContext.students
                    .Where(x => x.Id == id)
                    .FirstOrDefaultAsync();
        }

        public async Task Save()
        {
            await _dbContext.SaveChangesAsync();
        }

        public async Task<Student?> UpdateStudent(Student student)
        {
            var exsistingstudent = await _dbContext.students.FirstOrDefaultAsync(x=>x.Id==student.Id);
            if (exsistingstudent != null)
            {
                _dbContext.Entry(exsistingstudent).CurrentValues.SetValues(student);
                _dbContext.Entry(exsistingstudent).Property(x => x.RollNo).IsModified = false;
                _dbContext.Entry(exsistingstudent).Property(x => x.Id).IsModified = false;
                await _dbContext.SaveChangesAsync();
                return exsistingstudent;
            }
            return null;
        }

        public async Task<bool> DeleteStudent(Student student)
        {
            _dbContext.students.Remove(student);
            return await _dbContext.SaveChangesAsync()>0;    
        }



    }
}
