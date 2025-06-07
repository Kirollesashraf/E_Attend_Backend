namespace E_Attend.Entities;

public class Lecture
{
    public string Id { get; set; }
    public string Topic { get; set; }
    public DateTime Date { get; set; }

    public virtual ICollection<Student> AttendedStudents { get; set; } = new List<Student>();
    
    
}