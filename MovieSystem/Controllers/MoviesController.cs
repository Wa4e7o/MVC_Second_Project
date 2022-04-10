namespace MovieSystem.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using MovieSystem.Models.Movies;
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

        public async Task<IActionResult> Create()
        {
            var dropDownMoviesData = await _data.GetMovieDropDownValues();

            ViewBag.Cinemas = new SelectList(dropDownMoviesData.Cinemas, "Id", "Name");
            ViewBag.Producers = new SelectList(dropDownMoviesData.Producers, "Id", "Name");
            ViewBag.Actiors = new SelectList(dropDownMoviesData.Actiors, "Id", "Name");

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(NewMoviesViewModel movie)
        {
            if (!ModelState.IsValid)
            {
                var dropDownMoviesData = await _data.GetMovieDropDownValues();

                ViewBag.Cinemas = new SelectList(dropDownMoviesData.Cinemas, "Id", "Name");
                ViewBag.Producers = new SelectList(dropDownMoviesData.Producers, "Id", "Name");
                ViewBag.Actiors = new SelectList(dropDownMoviesData.Actiors, "Id", "Name");
                return View(movie);
            }

            await _data.AddNewMovieAsync(movie);

            return RedirectToAction(nameof(Index));
        }
    }
}
