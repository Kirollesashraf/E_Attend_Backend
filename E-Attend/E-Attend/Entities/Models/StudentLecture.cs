using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace E_Attend.Entities.Models
{
    public class StudentLecture
    {
        [Key]
        public string ID { get; set; } = Guid.NewGuid().ToString();

        [Required]
        [ForeignKey("Student")]
        public string StudentID { get; set; }

        [Required]
        [ForeignKey("Lecture")]
        public string LectureID { get; set; }

        [Required]
        public DateTime AttendanceTime { get; set; }

        [Required]
        public string Status { get; set; } // Present, Absent, Late, etc.

        // Navigation properties
        public virtual Student Student { get; set; }
        public virtual Lecture Lecture { get; set; }
    }
}