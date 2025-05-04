using CvMaker.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CvMaker.Controllers
{
    public class CvDesign : Controller
    {
        private readonly ILogger<CvDesign> _logger;
        private readonly dbContext _dbcontext;
        

        public CvDesign(ILogger<CvDesign> logger,dbContext dbContext)
        {
            _logger = logger;
            _dbcontext = dbContext;

        }

        public IActionResult Index()
        {
            var customerId = HttpContext.Session.GetString("customerSession");
            if (string.IsNullOrEmpty(customerId))
            {
                return RedirectToAction("customerLogin", "Home");
            }

            int id = int.Parse(customerId);

            var model = new CVModel
            {
                qualifications = _dbcontext.Qualification.Where(q => q.PersonalinfoId == id).ToList(),
                experiences = _dbcontext.Experience.Where(e => e.PersonalinfoId == id).ToList(),
                skills = _dbcontext.Skill.Where(s => s.PersonalinfoId == id).ToList(),
                languages = _dbcontext.Language.Where(l => l.PersonalinfoId == id).ToList(),
                personalinfos = _dbcontext.Personalinfo.Where(p => p.Id == id).ToList()
            };

            return View(model);
        }

        public IActionResult Index1()
        {
            var customerId = HttpContext.Session.GetString("customerSession");
            if (string.IsNullOrEmpty(customerId))
            {
                return RedirectToAction("customerLogin", "Home");
            }

            int id = int.Parse(customerId);

            var model = new CVModel
            {
                qualifications = _dbcontext.Qualification.Where(q => q.PersonalinfoId == id).ToList(),
                experiences = _dbcontext.Experience.Where(e => e.PersonalinfoId == id).ToList(),
                skills = _dbcontext.Skill.Where(s => s.PersonalinfoId == id).ToList(),
                languages = _dbcontext.Language.Where(l => l.PersonalinfoId == id).ToList(),
                personalinfos = _dbcontext.Personalinfo.Where(p => p.Id == id).ToList()
            };

            return View(model);
        }
        //public IActionResult Index()
        //{
        //    var model = new CVModel
        //    {
        //        qualifications = _dbcontext.Qualification.ToList(),
        //        experiences = _dbcontext.Experience.ToList(),
        //        skills = _dbcontext.Skill.ToList(),
        //        languages = _dbcontext.Language.ToList(),
        //        personalinfos = _dbcontext.Personalinfo.ToList()
        //    };

        //    return View(model);
        //}
        //public IActionResult    Index1()
        //{
        //    var model = new CVModel
        //    {
        //        qualifications = _dbcontext.Qualification.ToList(),
        //        experiences = _dbcontext.Experience.ToList(),
        //        skills = _dbcontext.Skill.ToList(),
        //        languages = _dbcontext.Language.ToList(),
        //        personalinfos = _dbcontext.Personalinfo.ToList()
        //    };

        //    return View(model);
        //}
        public IActionResult IndexView()
        {
            return View();
        }
    }
}
