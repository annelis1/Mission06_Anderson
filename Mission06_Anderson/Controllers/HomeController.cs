using Microsoft.AspNetCore.Mvc;
using Mission06_Anderson.Models;
using System.Diagnostics;

namespace Mission06_Anderson.Controllers
{
    public class HomeController : Controller
    {
        //Database
        private MovieSubmissionContext _context;

        public HomeController(MovieSubmissionContext movieSubmissionContext) //Constructor
        {
            _context = movieSubmissionContext;
        }

        //Views
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Movies()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Movies(Submission response)
        {
            _context.Submissions.Add(response); //add record to database
            _context.SaveChanges();
            
            return View("Confirmation");
        }

    }
}
