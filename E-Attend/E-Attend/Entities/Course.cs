using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace E_Attend.Entities;

public class Course
{
    [Key] public string Id { get; set; }

    public string Title { get; set; }
    public string Description { get; set; }
    public string Code { get; set; }

    [ForeignKey(nameof(Instructor))]
    public string InstructorId { get; set; }
    public virtual Instructor Instructor { get; set; }
    
    [ForeignKey(nameof(Announcement))]
    public string AnnouncementId { get; set; }
    public virtual Announcement Announcement { get; set; }
    
    public virtual ICollection<Student> Students { get; set; } = new List<Student>();
    public virtual ICollection<Lecture> Lectures { get; set; } = new List<Lecture>();
}