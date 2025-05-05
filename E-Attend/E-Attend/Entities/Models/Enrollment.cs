using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace E_Attend.Entities.Models
{
    public class Enrollment
    {

        [Key] public string ID { get; set; } = Guid.NewGuid().ToString();

        [Required]
        [ForeignKey("Student")]
        public string StudentID { get; set; }
  
        [Required]
        [ForeignKey("Course")]
        public string CourseID { get; set; }

        [Required]
        public DateTime EnrolledAt { get; set; }
    }
}
