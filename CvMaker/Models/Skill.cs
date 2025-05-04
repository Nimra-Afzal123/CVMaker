using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CvMaker.Models
{
    public class Skill
    {
        [Key]
        public int SkillsId { get; set; }
        public string SkillTitle { get; set; }
        public string SkilLevel { get; set; }

        public string? status { get; set; } // 0 = not active, 1 = active
        public string description { get; set; }
        public int PersonalinfoId { get; set; }// Foreign key
        [ForeignKey("PersonalinfoId")]
        public Personalinfo Personalinfo { get; set; } // Navigation property




    }
}
