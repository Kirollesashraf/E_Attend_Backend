using System.ComponentModel.DataAnnotations;

namespace E_Attend.Entities.Models
{
    public class Assignment
    {
        [Required]
        public int ID { get; set; }

        [Required]
        public int CourseID { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public TextWriter Description { get; set; }

        [Required]
        public DateTime DueDate { get; set; }

        [Required]
        public DateTime CreatedAt { get; set; }
    }
}
