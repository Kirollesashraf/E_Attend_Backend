using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace E_Attend.Entities.Models
{
    public class Students
    {
        [Required]
        public int ID { get; set; }


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
