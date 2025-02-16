using System.ComponentModel.DataAnnotations;

namespace E_Attend.Entities.Models
{
    public class Sheets
    {

        [Required]
        public int ID { get; set; }


        [Required]
        public int CourseID { get; set; }

        [Required]
        public string Title { get; set; }



        [Required]
        public string FilePath { get; set; }


        [Required]
        public DateTime UploadedAt { get; set; }

    }
}
