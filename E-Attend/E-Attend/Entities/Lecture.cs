using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace E_Attend.Entities;

public class Lecture
{
    [Key] public string Id { get; set; }
    public string Title { get; set; }
    public string Topic { get; set; }
    public DateTime Date { get; set; }
}