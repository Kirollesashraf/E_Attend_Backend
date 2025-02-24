using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace E_Attend.Entities.Models
{
    public class Submission
    {
        [Required]
        public int ID { get; set; }

        [Required]
        [ForeignKey("Assignment")]
        public int AssignmentID { get; set; }

        [Required]
        [ForeignKey("Student")]
        public int StudentID { get; set; }

        [Required]
        public string FilePath { get; set; }


        [Required]
        public DateTime SubmittedAt { get; set; }

        [Required]
        public float Grade { get; set; }


    }
}
