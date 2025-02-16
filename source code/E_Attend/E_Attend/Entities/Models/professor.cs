using System.ComponentModel.DataAnnotations;

namespace E_Attend.Entities.Models
{
    public class professor
    {

        [Required]
        public int ID { get; set; }


        [Required]
        public int UserID { get; set; }



        [Required]
        public string Specialization { get; set; }


        [Required]
        public string Department { get; set; }


        [Required]
        public DateTime CreatedAt { get; set; }

    }
}
