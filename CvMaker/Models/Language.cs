using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CvMaker.Models
{
    public class Language
    {
        [Key]
        public int LangId { get; set; }

        public string LanguageName { get; set; }
        public string? LanguageStatus { get; set; }

        public int PersonalinfoId { get; set; }// Foreign key
        [ForeignKey("PersonalinfoId")]
        public Personalinfo Personalinfo { get; set; } // Navigation property
    }
}
