using System.ComponentModel.DataAnnotations;

namespace E_Attend.Entities.Models
{
    public class Attendance
    {
        [Required]
        public int ID { get; set; }

        [Required]
        public int StudentID { get; set; }

        [Required]
        public int CourseID { get; set; }

        [Required]
        public string Status { get; set; }


        [Required]
        public DateTime Timestamp { get; set; }

    }
}
