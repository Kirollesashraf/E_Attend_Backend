using System.ComponentModel.DataAnnotations;

namespace E_Attend.Entities.Models
{
    public class Assistant
    {
        [Required]
        public int ID { get; set; }


        [Required]
        public int UserID { get; set; }


        [Required]
        public string Department { get; set; }



        [Required]
        public DateTime CreatedAt { get; set; }
    }
}
