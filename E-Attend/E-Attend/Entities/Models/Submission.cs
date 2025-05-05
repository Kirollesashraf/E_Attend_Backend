using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace E_Attend.Entities.Models
{
    public class Submission
    {
        [Key] public string ID { get; set; } = Guid.NewGuid().ToString();

        [Required]
        [ForeignKey("Assignment")]
        public string AssignmentID { get; set; }

        [Required]
        [ForeignKey("Student")]
        public string StudentID { get; set; }

        [Required]
        public string FilePath { get; set; }


        [Required]
        public DateTime SubmittedAt { get; set; }

        [Required]
        public float Grade { get; set; }


    }
}
