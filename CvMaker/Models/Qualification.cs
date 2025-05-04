using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CvMaker.Models
{
    public class Qualification
    {
        [Key]
        public int QualificationId { get; set; }
        [Required(ErrorMessage ="Please Enter Institute Name")]
        public string Institute { get; set; }
        [Required(ErrorMessage = "Please Enter Degree Name")]
        public string Degree { get; set; }

        [RegularExpression(@"^\d{4}$", ErrorMessage = "Please enter a valid year (e.g., 2023)")]
        public string PassingYear { get; set; }

        [Required(ErrorMessage = "Please Enter Obtained Marks")]
        public int ObtainedMarks { get; set; }

        [Required(ErrorMessage = "Please Enter Total Marks")]
        public int TotalMarks { get; set; }

        [RegularExpression(@"^\d+(\.\d{1,2})?$", ErrorMessage = "Please enter a valid percentage (e.g., 85.50)")]
        public string Percentage { get; set; }

        [RegularExpression(@"^[A-F]{1}$", ErrorMessage = "Please enter a valid grade (A, B, C, D, F)")]
        public string Grade { get; set; }


        public int? status { get; set; }

        public int PersonalinfoId { get; set; }// Foreign key
        [ForeignKey("PersonalinfoId")]
        public Personalinfo Personalinfo { get; set; } // Navigation property
    }
}
