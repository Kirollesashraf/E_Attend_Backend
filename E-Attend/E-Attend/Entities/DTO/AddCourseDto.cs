namespace E_Attend.Entities.DTO;

public class AddCourseDto
{
    public string Title { get; set; }
    public string Description { get; set; }
    public string Code { get; set; }
    public string Credits { get; set; }
    
    public string? InstructorId { get; set; }
    
}