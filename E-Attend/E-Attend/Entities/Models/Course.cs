using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace E_Attend.Entities.Models
{
    public class Course
    {

        [Key] public string ID { get; set; } = Guid.NewGuid().ToString();

        [Required]
        public string Name { get; set; }

        [Required]
        public string Code { get; set; }


        [Required]
        public int CreditHours { get; set; }


        [Required]
        [ForeignKey("Instructor")]
        public string InstructorID { get; set; }



        [Required]
        public DateTime CreatedAt { get; set; }
    }
}
