using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace E_Attend.Entities.Models
{
    public class Lecture
    {
        [Key]
        public string ID { get; set; } = Guid.NewGuid().ToString();

        [Required]
        [ForeignKey("Course")]
        public string CourseID { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public DateTime StartTime { get; set; }

        [Required]
        public DateTime EndTime { get; set; }

        public string Location { get; set; }

        [Required]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        // Navigation properties
        public virtual Course Course { get; set; }
        public virtual ICollection<StudentLecture> StudentLectures { get; set; }
    }
}