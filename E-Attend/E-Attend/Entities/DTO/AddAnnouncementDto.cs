namespace E_Attend.Entities.DTO;

public class AddAnnouncementDto
{
    public string Title { get; set; }
    
    public string Content { get; set; }
    
    public string CourseId { get; set; }
    public DateTime Created { get; set; }
}