using System.ComponentModel.DataAnnotations;

namespace E_Attend.Entities.Models
{
    public class Enrollment
    {

        [Required]
        public int ID { get; set; }

        [Required]
        public int StudentID { get; set; }



        [Required]
        public int Course_ID { get; set; }




        [Required]
        public DateTime EnrolledAt { get; set; }
    }
}
