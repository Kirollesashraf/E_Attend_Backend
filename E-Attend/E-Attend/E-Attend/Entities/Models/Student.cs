using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace E_Attend.Entities.Models
{
<<<<<<<< HEAD:E-Attend/E-Attend/E-Attend/Entities/Models/instructor.cs
    public class instructor
    {


========
    public class Student
    {
>>>>>>>> MainServices:E-Attend/E-Attend/E-Attend/Entities/Models/Student.cs
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
        public string UniversityID { get; set; }


        [Required]
        public string Department { get; set; }


        [Required]
        public DateTime CreatedAt { get; set; }



    }
}
