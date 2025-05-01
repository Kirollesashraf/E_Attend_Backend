using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace E_Attend.Entities.Models
{
    public class Student
    {
        [Required]
        public int ID { get; set; }
        
       
        [Required]
        [MaxLength(50)] 
        public string Name { get; set; }


        [Required]
        [ForeignKey("AppUser")]
        public string UserID { get; set; }


        [Required]
        public string UniversityID { get; set; }


        [Required]
        public string Department { get; set; }


        [Required]
        public DateTime CreatedAt { get; set; }

    }
}
