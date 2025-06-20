﻿namespace E_Attend.Entities.DTO;

public class CourseDto
{
    public string Id { get; set; }

    public string Title { get; set; }
    public string Description { get; set; }
    public string Code { get; set; } 
    
    public string Credits { get; set; }

    public string? InstructorId { get; set; }

    public List<StudentDto>? Students { get; set; } = [];
}