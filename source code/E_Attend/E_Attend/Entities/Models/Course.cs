using System.ComponentModel.DataAnnotations;

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
        public int ProfessorID { get; set; }



        [Required]
        public DateTime CreatedAt { get; set; }
    }
}
