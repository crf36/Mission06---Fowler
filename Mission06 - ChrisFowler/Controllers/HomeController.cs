using Microsoft.AspNetCore.Mvc;
using Mission06___ChrisFowler.Models;
using System.Diagnostics;

namespace Mission06___ChrisFowler.Controllers
{
    public class HomeController : Controller
    {
        private Context _context;
        public HomeController(Context temp) // Constructor
        {
            _context = temp;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult GetToKnowJoel()
        {
            return View();
        }

        [HttpGet]
        public IActionResult AddMovie()
        {
            ViewBag.ViewCategory = _context.Category
                .OrderBy(x => x.CategoryName).ToList();
            return View();
        }

        [HttpPost]
        public IActionResult AddMovie(NewMovie response)
        {
            if (ModelState.IsValid)
            {
                _context.Movies.Add(response); // Adds response into the database and saves changes
                _context.SaveChanges();
                return View("Confirm", response);
            }

            else
            {
                ViewBag.ViewCategory = _context.Category.ToList();
                ViewBag.Title = "Error";
                return View(response);
            }
        }

        public IActionResult ViewMovies()
        {
            ViewBag.ViewCategory = _context.Category
                .OrderBy(x => x.CategoryName).ToList();
            var movies = _context.Movies.ToList();

            return View(movies);
        }

        [HttpGet]
        public IActionResult Edit(int id) 
        {
            var record = _context.Movies
                .Single(x => x.MovieId == id);

            ViewBag.ViewCategory = _context.Category
                .OrderBy(x => x.CategoryName).ToList();

            return View("AddMovie", record);
        }
    }
}
