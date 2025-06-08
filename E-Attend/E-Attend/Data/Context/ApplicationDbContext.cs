using E_Attend.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace E_Attend.Data.Context;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
    : IdentityDbContext<ApplicationUser>(options) {
    public DbSet<ApplicationUser> Users { get; set; }
    public DbSet<Lecture> Lectures { get; set; }
    public DbSet<Student> Students { get; set; }
    public DbSet<Announcement> Announcements { get; set; }
    public DbSet<Course> Courses { get; set; }
    public DbSet<Attendance> Attendances { get; set; }
    public DbSet<Instructor> Instructors { get; set; }
    
    
}