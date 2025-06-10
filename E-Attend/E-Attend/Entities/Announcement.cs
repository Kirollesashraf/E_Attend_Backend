using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace E_Attend.Entities;

public class Announcement
{
    [Key] public string Id { get; set; }
    public string Title { get; set; }
    
    [DataType(DataType.Text)]
    public string Content { get; set; }
    
    public DateTime Created { get; set; }
    
    [ForeignKey(nameof(Course))]
    public string CourseId { get; set; }
    public virtual Course Course { get; set; }
}