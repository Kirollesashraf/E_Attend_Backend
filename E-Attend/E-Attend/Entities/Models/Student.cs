using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace E_Attend.Entities.Models
{
    public class Student
    {
        [Key] public string ID { get; set; } = Guid.NewGuid().ToString();
        
       
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
