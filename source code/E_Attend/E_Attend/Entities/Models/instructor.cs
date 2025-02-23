using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace E_Attend.Entities.Models
{
    public class instructor
    {


        [Required]
        public int ID { get; set; }


        [Required]
        public string Name { get; set; }




        [Required]
        public string AcademicDegree { get; set; }





        [Required]
        [ForeignKey("AppUser")]
        public int UserID { get; set; }



        [Required]
        public string Specialization { get; set; }


        [Required]
        public string Department { get; set; }


        [Required]
        public DateTime CreatedAt { get; set; }



    }
}
