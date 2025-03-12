using hw.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace hw.Controllers
{
    public class MoviesController: Controller
    {
        MovieContext db;
        public MoviesController(MovieContext context)
        {
            db = context;
        }

        public async Task<IActionResult> GetMovies()
        {
            IEnumerable<Movie> movies = await db.Movies.ToListAsync(); 
            ViewBag.Movies = movies;
            return View();
        }
    }
}