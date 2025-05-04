using Microsoft.EntityFrameworkCore;
namespace CvMaker.Models
{
    public class dbContext:DbContext
    {
        public dbContext(DbContextOptions<dbContext> dbContextOptions) : base(dbContextOptions)
        {

        }
        public DbSet<Personalinfo> Personalinfo { get; set; }
        public DbSet<Qualification> Qualification{ get; set; }

        public DbSet<Experience> Experience { get; set; }

        public DbSet<Skill> Skill { get; set; }

        public DbSet<Language> Language { get; set; }

        


    }
}
