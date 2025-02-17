using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace E_Attend.Entities.Models
{
    public class Enrollment
    {

        [Required]
        public int ID { get; set; }

        [Required]
        [ForeignKey("Students")]
        public int StudentID { get; set; }
       



        [Required]
        [ForeignKey("Course")]
        public int CourseID { get; set; }




        [Required]
        public DateTime EnrolledAt { get; set; }
    }
}
