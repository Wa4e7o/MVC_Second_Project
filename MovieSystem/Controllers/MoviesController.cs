namespace MovieSystem.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using MovieSystem.Data;
    using System.Linq;
    using System.Threading.Tasks;

    public class MoviesController : Controller
    {
        private readonly MovieSystemDbContext data;

        public MoviesController(MovieSystemDbContext data)
        {
            this.data = data;
        }
        public async Task<IActionResult> Index()
        {
            var allMovies = await data
                .Movies
                .Include(m => m.Cinema)
                .OrderBy(m => m.Name)
                .ToListAsync();
            return View(allMovies);
        }

    }
}
