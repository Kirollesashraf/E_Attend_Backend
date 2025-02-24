namespace E_Attend.Entities.DTOs;

public class AssignmentDTO {
    public int CourseID { get; set; }


    public string Title { get; set; }

    public string Description { get; set; }


    public DateTime DueDate { get; set; }


    public DateTime CreatedAt { get; set; }
}