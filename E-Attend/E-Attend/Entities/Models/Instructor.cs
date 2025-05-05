using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace E_Attend.Entities.Models
{
    public class Instructor
    {


        [Key] public string ID { get; set; } = Guid.NewGuid().ToString();


        [Required]
        public string Name { get; set; }




        [Required]
        public string AcademicDegree { get; set; }





        [Required]
        [ForeignKey("AppUser")]
        public string UserID { get; set; }



        [Required]
        public string Specialization { get; set; }


        [Required]
        public string Department { get; set; }


        [Required]
        public DateTime CreatedAt { get; set; }



    }
}