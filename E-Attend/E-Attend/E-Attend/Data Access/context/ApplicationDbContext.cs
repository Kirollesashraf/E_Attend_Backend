using E_Attend.Entities.Models;
using Microsoft.EntityFrameworkCore;
namespace E_Attend.Data_Access.context
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) 
        {
        }
        public DbSet<AppUser> AppUsers { get; set; }
        public DbSet<Assignment> Assignments { get; set; }
        public DbSet<Attendance> Attendances { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }
        public DbSet<Instructor> Instructors { get; set; }
        public DbSet<Sheet> Sheets { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Submission> Submissions { get; set; }

    }
}
