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
        public IActionResult Movies()
        {
            ViewBag.Category = _context.Movies
                .OrderBy(x => x.Category).ToList();
            return View();
        }

        [HttpPost]
        public IActionResult Movies(Application response)
        {
            if (response.LentTo == null) // If LentTo was not entered in the form, sets the value to an empty string (can't do null)
            {
                response.LentTo = "";
            }

            if (response.Notes == null) // If Notes was not entered in the form, sets the value to an empty string (can't do null)
            {
                response.Notes = "";
            }

            _context.Movies.Add(response); // Adds response into the database and saves changes
            _context.SaveChanges();
            return View("Index");
        }

        public IActionResult MovieDatabase()
        {
            var applications = _context.Movies.ToList();

            return View(applications);
        }
    }
}
