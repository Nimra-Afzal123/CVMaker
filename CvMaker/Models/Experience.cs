using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CvMaker.Models
{
    public class Experience
    {
        [Key]
        public int ExpId { get; set; }
      
        public string InstitueType { get; set; }
        public string InstitueName { get; set; }
        public string JobTitle { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public string? Status { get; set; }

        public string Description { get; set; }
        public int PersonalinfoId { get; set; }// Foreign key
        [ForeignKey("PersonalinfoId")]
        public Personalinfo Personalinfo { get; set; } // Navigation property
    }
}
