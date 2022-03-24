namespace MovieSystem.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using MovieSystem.Data;
    using System.Linq;

    public class MoviesController : Controller
    {
        private readonly MovieSystemDbContext data;

        public MoviesController(MovieSystemDbContext data)
        {
            this.data = data;
        }

        public IActionResult Index()
        {
            var baseData = data.Movies.ToList();
            return View(baseData);
        }
    }
}
