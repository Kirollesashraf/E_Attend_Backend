using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace E_Attend.Entities.Models
{
    public class Course
    {

        [Required]
        public int ID { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Code { get; set; }


        [Required]
        public int CreditHours { get; set; }


        [Required]
        [ForeignKey("professor")]
        public int ProfessorID { get; set; }



        [Required]
        public DateTime CreatedAt { get; set; }
    }
}
