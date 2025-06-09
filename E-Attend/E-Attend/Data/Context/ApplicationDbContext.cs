using E_Attend.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace E_Attend.Data.Context;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
    : IdentityDbContext<ApplicationUser>(options)
{
    public DbSet<ApplicationUser> Users { get; set; }
    public DbSet<Lecture> Lectures { get; set; }
    public DbSet<Student> Students { get; set; }
    public DbSet<Announcement> Announcements { get; set; }
    public DbSet<Course> Courses { get; set; }
    public DbSet<Attendance> Attendances { get; set; }
    public DbSet<Instructor> Instructors { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        modelBuilder.Entity<Announcement>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Id)
                .HasConversion<int>(
                    v => int.Parse(v),       
                    v => v.ToString()       
                )
                .ValueGeneratedOnAdd()
                .UseIdentityColumn();

            
            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.Title).IsRequired().HasMaxLength(255);
            entity.Property(e => e.Content).IsRequired();
            entity.Property(e => e.Created).IsRequired().HasDefaultValue(DateTime.UtcNow);
        });
        
        modelBuilder.Entity<Attendance>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Id)
                .HasConversion<int>(
                    v => int.Parse(v),       
                    v => v.ToString()       
                )
                .ValueGeneratedOnAdd()
                .UseIdentityColumn();

            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.Status).IsRequired().HasMaxLength(50);
            entity.Property(e => e.TimeSlot).IsRequired().HasMaxLength(100);
            entity.Property(e => e.Date).IsRequired();

            entity.HasOne(d => d.Student)
                .WithMany()
                .HasForeignKey(d => d.StudentId)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired();

            entity.HasOne(d => d.Course)
                .WithMany()
                .HasForeignKey(d => d.CourseId)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired();

            entity.HasIndex(a => new { a.StudentId, a.CourseId, a.Date }).IsUnique();
        });
        
        modelBuilder.Entity<Course>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Id)
                .HasConversion<int>(
                    v => int.Parse(v),       
                    v => v.ToString()       
                )
                .ValueGeneratedOnAdd()
                .UseIdentityColumn();

            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.Title).IsRequired().HasMaxLength(255);
            entity.Property(e => e.Description).HasMaxLength(1000);
            entity.Property(e => e.Code).IsRequired().HasMaxLength(50);
            entity.Property(e => e.Credits).IsRequired().HasMaxLength(10);
            entity.HasIndex(e => e.Code).IsUnique();

            entity.HasOne(d => d.Instructor)
                .WithMany(p => p.Courses)
                .HasForeignKey(d => d.InstructorId)
                .OnDelete(DeleteBehavior.Restrict);

            entity.HasMany(d => d.Announcements)
                .WithOne()
                .OnDelete(DeleteBehavior.Cascade);

            entity.HasMany(d => d.Students)
                .WithMany(p => p.Courses)
                .UsingEntity(j => j.ToTable("CourseStudents"));

            entity.HasMany(d => d.Lectures)
                .WithOne(p => p.Course)
                .HasForeignKey(d => d.CourseId)
                .OnDelete(DeleteBehavior.Cascade);
        });
        
        modelBuilder.Entity<Instructor>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.Name).IsRequired().HasMaxLength(255);
            entity.Property(e => e.UniversityId).IsRequired().HasMaxLength(100);
            entity.Property(e => e.Degree).HasMaxLength(100);
            entity.Property(e => e.Specialization).HasMaxLength(255);
            entity.Property(e => e.Department).HasMaxLength(255);
            entity.HasIndex(e => e.UniversityId).IsUnique();
            entity.HasIndex(e => e.UserId).IsUnique();
        });
        
        modelBuilder.Entity<Lecture>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.Title).IsRequired().HasMaxLength(255);
            entity.Property(e => e.Topic).HasMaxLength(500);
            entity.Property(e => e.Date).IsRequired();

            entity.HasOne(d => d.Course)
                .WithMany(p => p.Lectures)
                .HasForeignKey(d => d.CourseId)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired();

            entity.HasIndex(e => new { e.CourseId, e.Date, e.Title }).IsUnique();
        });

        modelBuilder.Entity<Student>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.Name).IsRequired().HasMaxLength(255);
            entity.Property(e => e.Degree).HasMaxLength(100);
            entity.Property(e => e.Department).HasMaxLength(255);
            entity.HasIndex(e => e.UserId).IsUnique();

            entity.HasMany(d => d.Courses)
                .WithMany(p => p.Students)
                .UsingEntity(j => j.ToTable("CourseStudents"));
        });
    }
}