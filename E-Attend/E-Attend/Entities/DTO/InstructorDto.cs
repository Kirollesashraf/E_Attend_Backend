namespace E_Attend.Entities.DTO;

public class InstructorDto
{
    public string Id { get; set; }

    public string UserId { get; set; }

    public string Name { get; set; }
    public string UniversityId { get; set; }
    public string Degree { get; set; }
    public string Specialization { get; set; }
    public string Department { get; set; }

    public virtual ICollection<CourseDto> Courses { get; set; } = new List<CourseDto>();
}