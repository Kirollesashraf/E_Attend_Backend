using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace E_Attend.Entities;

public class Attendance
{
    [Key]
    public string Id { get; set; }

    [ForeignKey(nameof(Student))] 
    public string StudentId { get; set; }
    public Student Student { get; set; }

    [ForeignKey(nameof(Course))] 
    public string CourseId { get; set; }
    public Course Course { get; set; }
    
    public string Status { get; set; }
    public string Day { get; set; }
    public DateTime Date { get; set; } = DateTime.UtcNow;
    
}