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
        public IActionResult MovieForm()
        {
            ViewBag.Categories = _context.Categories
                .OrderBy(x => x.CategoryName).ToList();
            return View(new Movie());
        }

        [HttpPost]
        public IActionResult MovieForm(Movie response)
        {
            if (ModelState.IsValid)
            {
                _context.Movies.Add(response); // Adds response into the database and saves changes
                _context.SaveChanges();
                return View("Index");
            }

            else
            {
                ViewBag.Categories = _context.Categories.ToList();
                ViewBag.Title = "Error";
                return View(response);
            }
        }

        public IActionResult ViewMovies()
        {
            ViewBag.Categories = _context.Categories
                .OrderBy(x => x.CategoryName).ToList();
            var movies = _context.Movies.ToList();

            return View(movies);
        }

        [HttpGet]
        public IActionResult EditMovie(int id)
        {
            var record = _context.Movies
                .SingleOrDefault(x => x.MovieId == id);

            ViewBag.Categories = _context.Categories
                .OrderBy(x => x.CategoryName)
                .ToList();

            return View("MovieForm", record);
        }

        [HttpPost]
        public IActionResult EditMovie(Movie record) 
        {
            _context.Update(record);
            _context.SaveChanges();

            return RedirectToAction("ViewMovies");
        }

        [HttpGet]
        public IActionResult DeleteMovie(int id)
        {
            var record = _context.Movies
                .Single(x => x.MovieId == id);

            return View(record);
        }

        [HttpPost]
        public IActionResult DeleteMovie(Movie record)
        {
            _context.Movies.Remove(record);
            _context.SaveChanges();

            return RedirectToAction("ViewMovies");
        }
    }
}
