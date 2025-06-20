﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace E_Attend.Entities;

public class Instructor
{
    [Key] public string Id { get; set; }

    [ForeignKey(nameof(ApplicationUser))]
    public string UserId { get; set; }

    public ApplicationUser ApplicationUser { get; set; }
    public string Name { get; set; }
    public string UniversityId { get; set; }
    public string Degree { get; set; }
    public string Specialization { get; set; }
    public string Department { get; set; }

    public virtual ICollection<Course> Courses { get; set; } = new List<Course>();
}