namespace MovieSystem.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using MovieSystem.Services.Movies;
    using System.Threading.Tasks;

    public class MoviesController : Controller
    {
        private readonly IMoviesService _data;

        public MoviesController(IMoviesService data)
        {
            this._data = data;
        }

        public async Task<IActionResult> Index()
        {
            var allMovies = await _data.GetAllAsync(n => n.Cinema);
            return View(allMovies);
        }

        public async Task<IActionResult> Details(int id)
        {
            var moviesDetails = await _data.GetMovieByIdAsync(id);

            return View(moviesDetails);
        }

        public IActionResult Create()
        {
            ViewData["Welcome"] = "Welcome in Movie World !";
            ViewBag.Description = "Here you can find a lot of good movies !";

            return View();
        }

    }
}
