using System.ComponentModel.DataAnnotations;

namespace E_Attend.Entities.Models
{
    public class Submission
    {
        [Required]
        public int ID { get; set; }

        [Required]
        public int AssignmentID { get; set; }

        [Required]
        public int StudentID { get; set; }

        [Required]
        public string FilePath { get; set; }


        [Required]
        public DateTime SubmittedAt { get; set; }

        [Required]
        public float Grade { get; set; }


    }
}
