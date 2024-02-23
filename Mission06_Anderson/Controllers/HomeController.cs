using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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

            // need to load up the viewbag
            ViewBag.Categories = _context.Categories
                .OrderBy(x=> x.CategoryName)
                .ToList();

            return View(new Movie());
        }

        //sends submission to database then opens new view
        [HttpPost]
        public IActionResult Movies(Movie response)
        {
            if(ModelState.IsValid)
            {
                _context.Movies.Add(response); //add record to database
                _context.SaveChanges();

                return View("Confirmation");
            }
            else
            {
                ViewBag.Categories = _context.Categories
                    .OrderBy(x => x.CategoryName)
                    .ToList();

                return View(response);
            }
            
        }
        
        public IActionResult AllMovies()
        {
            //linq
            var movies = _context.Movies.Include("Category")
                .ToList();

            return View(movies);
        }

        //Editing records functionality
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var recordToEdit = _context.Movies
                .Single(x => x.MovieId == id);

            ViewBag.Categories = _context.Categories
                .OrderBy(x => x.CategoryName)
                .ToList();

            return View("Movies", recordToEdit);
        }
        [HttpPost]
        public IActionResult Edit(Movie updatedInfo) 
        {
            _context.Update(updatedInfo);
            _context.SaveChanges();

            return RedirectToAction("AllMovies");
        }

        //Delete records functionality
        [HttpGet]
        public IActionResult Delete(int id) 
        { 
            var recordToDelete = _context.Movies
                .Single(x=> x.MovieId==id);

            return View(recordToDelete);
        }
        [HttpPost]
        public IActionResult Delete(Movie movie)
        {
            _context.Movies.Remove(movie);
            _context.SaveChanges();

            return RedirectToAction("AllMovies");
        }

    }
}
