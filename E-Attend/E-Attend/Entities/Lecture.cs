using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace E_Attend.Entities;

public class Lecture
{
    [Key] public string Id { get; set; }
    public string Title { get; set; }
    public string Topic { get; set; }
    
    [ForeignKey(nameof(Course))]
    public string CourseId { get; set; }
    public virtual Course Course { get; set; }

    public DateTime Date { get; set; }
}