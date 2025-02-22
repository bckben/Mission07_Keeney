using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Mission07_Keeney.Models;
using System.Linq;

namespace Mission07_Keeney.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext _context;

        public HomeController(ApplicationDbContext temp)
        {
            _context = temp;
        }

        // Index Page - Load movies & their categories
        public IActionResult Index()
        {
            var movies = _context.Movies.Include(m => m.Category).ToList();
            return View(movies);
        }

        // GET: AddMovie (Load form)
        [HttpGet]
        public IActionResult AddMovie()
        {
            ViewBag.Categories = _context.Categories.ToList(); // Load categories for dropdown
            return View();
        }

        // POST: AddMovie (Save new movie)
        [HttpPost]
        public IActionResult AddMovie(Movie movie)
        {
            if (ModelState.IsValid)
            {
                _context.Movies.Add(movie);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Categories = _context.Categories.ToList(); // Reload categories if form is invalid
            return View(movie);
        }

        // GET: Edit Movie (Load form with existing data)
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var movie = _context.Movies.Find(id);
            if (movie == null)
            {
                return NotFound();
            }

            ViewBag.Categories = _context.Categories.ToList(); // Load categories for dropdown
            return View(movie);
        }

        // POST: Edit Movie (Save updated movie)
        [HttpPost]
        public IActionResult Edit(Movie movie)
        {
            if (ModelState.IsValid)
            {
                _context.Movies.Update(movie);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Categories = _context.Categories.ToList(); // Reload categories if validation fails
            return View(movie);
        }

        // POST: Delete Movie
        [HttpPost]
        public IActionResult Delete(int id)
        {
            var movie = _context.Movies.Find(id);
            if (movie != null)
            {
                _context.Movies.Remove(movie);
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}
