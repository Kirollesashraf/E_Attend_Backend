using System.ComponentModel.DataAnnotations;

namespace E_Attend.Entities;

public class Announcement
{
    [Key] public string Id { get; set; }
    public string Title { get; set; }
    
    [DataType(DataType.Text)]
    public string Content { get; set; }
    
    public DateTime Created { get; set; }
}