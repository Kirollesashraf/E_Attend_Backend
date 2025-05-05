using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace E_Attend.Entities.Models
{
    public class Assignment {
        [Key] public string ID { get; set; } = Guid.NewGuid().ToString();

        [Required]
        [ForeignKey("Course")]
        public string CourseID { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public DateTime DueDate { get; set; }

        [Required]
        public DateTime CreatedAt { get; set; }
    }
}
