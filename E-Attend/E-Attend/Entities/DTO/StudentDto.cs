namespace E_Attend.Entities.DTO;

public class StudentDto
{
    public string Id { get; set; }
    
    public string UserId { get; set; }
    
    public string Name { get; set; }
    public string Degree { get; set; }
    public string Department { get; set; }
    
    public List<CourseDto>? Courses { get; set; } = [];
 

}