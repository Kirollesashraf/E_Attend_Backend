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
        public string Day { get; set; }
        
    }
}