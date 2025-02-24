using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace E_Attend.Entities.Models
{
    public class Sheet
    {

        [Required]
        public int ID { get; set; }


        [Required]
        [ForeignKey("Course")]
        public int CourseID { get; set; }

        [Required]
        public string Titel{ get; set; }



        [Required]
        public string FilePath { get; set; }


        [Required]
        public DateTime UploadedAt { get; set; }

    }
}
