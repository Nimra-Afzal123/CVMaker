namespace CvMaker.Models
{
    public class CVModel
    {
        public List<Personalinfo> personalinfos { get; set; }
        public List<Qualification> qualifications { get; set; }
        public List<Experience> experiences { get; set; }
        public List<Skill> skills { get; set; }
        public List<Language> languages { get; set; }
    }
}
