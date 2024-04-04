using DemoAttendenceFeature.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DemoAttendenceFeature.Data
{
    public class AppDbContext: IdentityDbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options) 
        {
            
        }
        public DbSet<Student> students { get; set; }
        public DbSet<Guardian> guardians { get; set;}
        public DbSet<Attendence> attendences { get; set;}
        public DbSet<StudentAdmissionStatus> studentAdmissionStatus { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //many to many relation between Student and Guardians
            modelBuilder.Entity<Student>()
             .HasMany(s => s.Guardians)
             .WithMany(c => c.Students)
             .UsingEntity<Dictionary<string, object>>(
                 "StudentCourse",
                 j => j
                     .HasOne<Guardian>()
                     .WithMany()
                     .HasForeignKey("GuardianId"),
                 j => j
                     .HasOne<Student>()
                     .WithMany()
                     .HasForeignKey("StudentId").OnDelete(DeleteBehavior.Cascade),
                 j =>
                 {
                     j.HasKey("StudentId", "GuardianId");
                     j.ToTable("StudentGurdians");
                 }) ;

            //one to many relation between Student and Attendece
            modelBuilder.Entity<Attendence>()
                .HasOne(x => x.Student)
                .WithMany(x => x.Attendences)
                .HasForeignKey(x => x.StudentId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<StudentAdmissionStatus>()
                .HasOne(x => x.Student)
                .WithOne(x => x.AdmissionStatus)
                .HasForeignKey<StudentAdmissionStatus>(x => x.StudentId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<StudentEmergencyContactInfo>()
                .HasOne(x => x.Student)
                .WithOne(x => x.StudentEmergencyContactInfo)
                .HasForeignKey<StudentEmergencyContactInfo>(x => x.StudentId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<StudentEducationInfo>()
                .HasOne(x => x.Student)
                .WithOne(x => x.StudentEducationInfo)
                .HasForeignKey<StudentEducationInfo>(x => x.StudentId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<StudentMedicalInfo>()
               .HasOne(x => x.Student)
               .WithOne(x => x.StudentMedicalInfo)
               .HasForeignKey<StudentMedicalInfo>(x => x.StudentId)
               .OnDelete(DeleteBehavior.Cascade);



            base.OnModelCreating(modelBuilder);

            var adminRoleid = "bf0acce0 - d5be - 42cc - a5eb - 71dec7688180";
            var roles = new List<IdentityRole>()
            {
                new IdentityRole()
                {
                    Id = adminRoleid,
                    Name = "Admin",
                    ConcurrencyStamp = adminRoleid,
                    NormalizedName = "Admin".ToUpper()
                }

            };

            modelBuilder.Entity<IdentityRole>().HasData(roles);


        }
    }
}
