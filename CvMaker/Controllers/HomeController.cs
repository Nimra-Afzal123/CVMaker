using System.Diagnostics;
using CvMaker.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CvMaker.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly dbContext _dbContext;
        private IWebHostEnvironment _env;
        public HomeController(ILogger<HomeController> logger,dbContext dbContext, IWebHostEnvironment env)
        {
            _logger = logger;
            _dbContext = dbContext;
            _env = env;
        }
        public IActionResult Landing()
        {
            return View();
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult getskills()
        {
            string userId = HttpContext.Session.GetString("customerSession");
            if (userId == null)
            {
                return Unauthorized();
            }

            int id = int.Parse(userId);
            var qdata = _dbContext.Skill.Where(s => s.PersonalinfoId == id).ToList();
            return Json(new { data = qdata });
            //var qdata = _dbContext.Skill.ToList();
            //return Json(new { data = qdata });
        }
        [HttpGet]
        public IActionResult getCategory()
        {
            string userId = HttpContext.Session.GetString("customerSession");
            if (userId == null)
            {
                return Unauthorized();
            }

            int id = int.Parse(userId);
            var cdata = _dbContext.Qualification.Where(q => q.PersonalinfoId == id).ToList(); //Filters and returns a list of matches
            return Json(new { data = cdata });
            //var cdata = _dbContext.Qualification.ToList();
            //return Json(new { data = cdata });
        }
        [HttpGet]
        public IActionResult getExperience()
        {
            string userId = HttpContext.Session.GetString("customerSession");
            if (userId == null)
            {
                return Unauthorized();
            }

            int id = int.Parse(userId);
            var cdata = _dbContext.Experience.Where(q => q.PersonalinfoId == id).ToList();
            return Json(new { data = cdata });
            //var edata = _dbContext.Experience.ToList();
            //return Json(new { data = edata });
        }
        [HttpGet]
        public IActionResult getLanguage()
        {
            string userId = HttpContext.Session.GetString("customerSession");
            if (userId == null)
            {
                return Unauthorized();
            }

            int id = int.Parse(userId);
            var cdata = _dbContext.Language.Where(q => q.PersonalinfoId == id).ToList();
            return Json(new { data = cdata });
            //var ldata = _dbContext.Language.ToList();
            //return Json(new { data = ldata });
        }
        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult customerRegistration()
        {
           return View();
        }
        [HttpPost]
        public IActionResult customerRegistration(Personalinfo customer)
        {
            if (ModelState.IsValid)
            {
                _dbContext.Personalinfo.Add(customer);
                _dbContext.SaveChanges();
                return RedirectToAction("customerLogin");
            }
            return View(customer);
        }
        public IActionResult customerLogin()
        {
            return View();
        }
        [HttpPost]
        public IActionResult customerLogin(String customerEmail, String customerPassword)
        {
            var customer = _dbContext.Personalinfo.FirstOrDefault(c => c.Email == customerEmail);
            if (customer != null && customer.Password == customerPassword)
            {

                HttpContext.Session.SetString("customerSession", customer.Id.ToString());
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.message = "Incorrect Message or Password";
                return View();

            }

        }
        public IActionResult Personalinfo()
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("customerSession")))
            {
                return RedirectToAction("customerLogin");
            }
            else
            {

                List<Personalinfo> category = _dbContext.Personalinfo.ToList();
                ViewData["category"] = category;
                var customerId = HttpContext.Session.GetString("customerSession");//get the session value
                var row = _dbContext.Personalinfo.Where(c => c.Id == int.Parse(customerId)).ToList();//find the customer id in database
               
                return View(row);
            }

        }
        [HttpPost]
        public IActionResult Personalinfo(Personalinfo customer, IFormFile ImageUrl)
        {
            if (ModelState.IsValid)
            {
                string ImagePath = Path.Combine(_env.WebRootPath, "ImageUrl", ImageUrl.FileName);
                using FileStream fs = new FileStream(ImagePath, FileMode.Create);
                {
                    ImageUrl.CopyTo(fs);
                }
               
                customer.ImageUrl = ImageUrl.FileName;
                _dbContext.Personalinfo.Update(customer);
                _dbContext.SaveChanges();
                return RedirectToAction("Qualification");
            }
            return RedirectToAction("Personalinfo");
        }
        public IActionResult Qualification()
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("customerSession")))
            {
                return RedirectToAction("customerLogin");
            }
            return View();
        }
        [HttpPost]
        public IActionResult Qualification(Qualification qualification)
        {
            
            
           
                string isLogin = HttpContext.Session.GetString("customerSession");
                if (isLogin != null)
                {

                    qualification.PersonalinfoId = int.Parse(isLogin);

                    _dbContext.Qualification.Add(qualification);
                    _dbContext.SaveChanges();
                    TempData["message"] = "Qualification Added";
                    return View();
                }
                else
                {
                    return RedirectToAction("customerLogin");
                }
            

        }
        public IActionResult removeQual(int id)
        {
            var qualification = _dbContext.Qualification.Find(id);
            if (qualification == null)
            {
                return NotFound();
            }
            _dbContext.Qualification.Remove(qualification);
            _dbContext.SaveChanges();
            return RedirectToAction("Qualification");
        }
        public IActionResult updateQual(int id)
        {
            var qualification = _dbContext.Qualification.Find(id);
            if (qualification == null)
            {
                return NotFound();
            }
            return View(qualification);
        }
        [HttpPost]
        public IActionResult updateQual(Qualification qualification)
        {
            var personalInfoExists = _dbContext.Personalinfo.Any(p => p.Id == qualification.PersonalinfoId);
            if (!personalInfoExists)
            {
                ModelState.AddModelError("PersonalinfoId", "Invalid PersonalinfoId.");
                return View(qualification);
            }

            _dbContext.Qualification.Update(qualification);
            _dbContext.SaveChanges();

            return RedirectToAction("Qualification");
        }

        public IActionResult Skill()
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("customerSession")))
            {
                return RedirectToAction("customerLogin");
            }
            return View();
        }
        [HttpPost]
        public IActionResult Skill(Skill skill)
        {



            string isLogin = HttpContext.Session.GetString("customerSession");
            if (isLogin != null)
            {

                skill.PersonalinfoId = int.Parse(isLogin);

                _dbContext.Skill.Add(skill);
                _dbContext.SaveChanges();
                TempData["message"] = "Skills Added";
                return View();
            }
            else
            {
                return RedirectToAction("customerLogin");
            }


        }
        public IActionResult removeSkill(int id)
        {
            var skill = _dbContext.Skill.Find(id);
            if (skill == null)
            {
                return NotFound();
            }
            _dbContext.Skill.Remove(skill);
            _dbContext.SaveChanges();
            return RedirectToAction("Skill");
        }
        public IActionResult updateSkill(int id)
        {
            var skill = _dbContext.Skill.Find(id);
            if (skill == null)
            {
                return NotFound();
            }
            return View(skill);
        }
        [HttpPost]
        public IActionResult updateSkill(Skill skill)
        {
            var personalInfoExists = _dbContext.Personalinfo.Any(p => p.Id == skill.PersonalinfoId);
            if (!personalInfoExists)
            {
                ModelState.AddModelError("PersonalinfoId", "Invalid PersonalinfoId.");
                return View(skill);
            }

            _dbContext.Skill.Update(skill);
            _dbContext.SaveChanges();

            return RedirectToAction("Skill");
        }
        public IActionResult Experience()
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("customerSession")))
            {
                return RedirectToAction("customerLogin");
            }
            return View();
        }
        [HttpPost]
        public IActionResult Experience(Experience experience)
        {
            string isLogin = HttpContext.Session.GetString("customerSession");
            if (isLogin != null)
            {
                experience.PersonalinfoId = int.Parse(isLogin);
                _dbContext.Experience.Add(experience);
                _dbContext.SaveChanges();
                TempData["message"] = "Experience Added";
                return View();
            }
            else
            {
                return RedirectToAction("customerLogin");
            }
        }
        public IActionResult removeExperience(int id)
        {
            var experience = _dbContext.Experience.Find(id);
            if (experience == null)
            {
                return NotFound();
            }
            _dbContext.Experience.Remove(experience);
            _dbContext.SaveChanges();
            return RedirectToAction("Experience");
        }
        public IActionResult updateExperience(int id)
        {
            var experience = _dbContext.Experience.Find(id);
            if (experience == null)
            {
                return NotFound();
            }
            return View(experience);
        }
        [HttpPost]
        public IActionResult updateExperience(Experience experience)
        {
            var personalInfoExists = _dbContext.Personalinfo.Any(p => p.Id == experience.PersonalinfoId); //check if any record match returns true or false
            if (!personalInfoExists)
            {
                ModelState.AddModelError("PersonalinfoId", "Invalid PersonalinfoId.");
                return View(experience);
            }
            _dbContext.Experience.Update(experience);
            _dbContext.SaveChanges();
            return RedirectToAction("Experience");
        }
        public IActionResult Logout()
        {
            HttpContext.Session.Remove("customerSession");
            return RedirectToAction("customerLogin");
        }
        public IActionResult Language()
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("customerSession")))
            {
                return RedirectToAction("customerLogin");
            }
            return View();
        }
        [HttpPost]
        public IActionResult Language(Language language)
        {
            string isLogin = HttpContext.Session.GetString("customerSession");
            if (isLogin != null)
            {
                language.PersonalinfoId = int.Parse(isLogin);
                _dbContext.Language.Add(language);
                _dbContext.SaveChanges();
                TempData["message"] = "Language Added";
                return View();
            }
            else
            {
                return RedirectToAction("customerLogin");
            }
        }
        public IActionResult deleteLanguage(int id)
        {
            var language = _dbContext.Language.Find(id);
            if (language == null)
            {
                return NotFound();
            }
            _dbContext.Language.Remove(language);
            _dbContext.SaveChanges();
            return RedirectToAction("Language");
        }
        public IActionResult updateLanguage(int id)
        {
            var language = _dbContext.Language.Find(id);
            if (language == null)
            {
                return NotFound();
            }
            return View(language);
        }
        [HttpPost]
        public IActionResult updateLanguage(Language language)
        {
            var personalInfoExists = _dbContext.Personalinfo.Any(p => p.Id == language.PersonalinfoId);
            if (!personalInfoExists)
            {
                ModelState.AddModelError("PersonalinfoId", "Invalid PersonalinfoId.");
                return View(language);
            }
            _dbContext.Language.Update(language);
            _dbContext.SaveChanges();
            return RedirectToAction("Language");
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
