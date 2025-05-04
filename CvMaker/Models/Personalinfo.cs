using System.ComponentModel.DataAnnotations;

namespace CvMaker.Models
{
    public class Personalinfo
    {
        [Key]
        public int Id{ get; set; }


        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string? FatherName { get; set; }

        public string? AboutTitle { get; set; }

        public string? AboutUs { get; set; }

        public string? Email { get; set; }

        public string? Cnic { get; set; }
        public string? Contact { get; set; }

        public string? Address { get; set; }

        public string? dateofBirth { get; set; }
        public string? CreatedDate { get; set; }
        public string Password { get; set; }

        public string? Status { get; set; }

        public string? ImageUrl { get; set; }


    }
}
