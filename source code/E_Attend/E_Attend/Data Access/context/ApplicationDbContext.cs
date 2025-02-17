using E_Attend.Entities.Models;
using Microsoft.EntityFrameworkCore;
namespace E_Attend.Data_Access.context
{
    public class ApplicationDbContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("data source=.;Initial Catalog=EAttendDB;integrated Security=true;TrustServerCertificate=True");
        public DbSet<AppUser> AppUsers { get; set; }
        public DbSet<Assignment> Assignments { get; set; }
        public DbSet<Assistant> Assistants { get; set; }
        public DbSet<Attendance> Attendances { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }
        public DbSet<professor> Professors { get; set; }
        public DbSet<Sheets> Sheets { get; set; }
        public DbSet<Students> Students { get; set; }
        public DbSet<Submission> Submissions { get; set; }

    }
}
