using Microsoft.AspNetCore.Mvc;
using Mission6_Walker.Models;
using System.Diagnostics;

namespace Mission6_Walker.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private Mission6ApplicationContext _context;

        public HomeController(ILogger<HomeController> logger, Mission6ApplicationContext movie)
        {
            _logger = logger;
            _context = movie;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult GetToKnowJoel() 
        { 
            return View(); 
        }

        public IActionResult ViewMovies() 
        {
            var movies = _context.Movies.OrderBy(x => x.Title).ToList();

            return View(movies); 
        }

        [HttpGet]
        public IActionResult AddMovie()
        {
            ViewBag.Categories = _context.Categories.ToList();

            return View("AddMovie", new Movies());
        }

        [HttpPost]
        public IActionResult AddMovie(Movies response)
        {
            // Check that the data is correct. If not, send them back to the form to add a movie
            if (ModelState.IsValid)
            {
                _context.Movies.Add(response); // Add the movie to the database
                _context.SaveChanges();

                ViewData["MovieTitle"] = response.Title;

                return View("Confirmation", response);
            }
            else
            {
                ViewBag.Categories = _context.Categories.ToList();
                return View(response);
            }
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var movieToEdit = _context.Movies.Single(x => x.MovieId == id);

            ViewBag.Categories = _context.Categories.ToList();

            return View("AddMovie", movieToEdit);
        }

        [HttpPost]
        public IActionResult Edit(Movies updatedInfo)
        {
            // Check that the data is correct. If not, send them back to the form to edit
            if (ModelState.IsValid) 
            {
                _context.Update(updatedInfo); // Edit the movie info in database
                _context.SaveChanges();

                return RedirectToAction("ViewMovies");
            }
            else
            {
                ViewBag.Categories = _context.Categories.ToList();
                return View("AddMovie", updatedInfo);
            }
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var movieToDelete = _context.Movies.Single(x => x.MovieId == id);

            return View(movieToDelete);
        }

        [HttpPost]
        public IActionResult Delete(Movies movie)
        {
            _context.Movies.Remove(movie); // Delete the movie from the database
            _context.SaveChanges();

            return RedirectToAction("ViewMovies");
        }

        public IActionResult Confirmation()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
