using Microsoft.AspNetCore.Mvc;
using Mission6_Walker.Models;
using System.Diagnostics;

namespace Mission6_Walker.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private Mission6ApplicationContext _context;

        public HomeController(ILogger<HomeController> logger, Mission6ApplicationContext application)
        {
            _logger = logger;
            _context = application;
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
            return View();
        }

        [HttpPost]
        public IActionResult AddMovie(AddMovie response)
        {
            _context.Movies.Add(response); // Add the movie to the database
            _context.SaveChanges();

            return View("Confirmation", response);
        } 

        public IActionResult Confirmation()
        {
            return View();
        }

        public IActionResult Privacy()
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
