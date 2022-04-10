namespace MovieSystem.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using MovieSystem.Models.Movies;
    using MovieSystem.Services.Movies;
    using System.Linq;
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

        public async Task<IActionResult> Filter(string searchString)
        {
            var allMovies = await _data.GetAllAsync(n => n.Cinema);

            if (!string.IsNullOrEmpty(searchString))
            {
                var filteredResult = allMovies.Where(n => n.Name.Contains(searchString) || n.Description.Contains(searchString)).ToList();

                return View("Index", filteredResult);
            }

            return View("Index", allMovies);
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

        //------------------------------

        public async Task<IActionResult> Edit(int id)
        {

            var movieDetails = await _data.GetMovieByIdAsync(id);

            if (movieDetails == null) return View("Not found");

            var response = new NewMoviesViewModel()
            {
                Id = movieDetails.Id,
                Name = movieDetails.Name,
                Description = movieDetails.Description,
                Price = movieDetails.Price,
                StartDate = movieDetails.StartDate,
                EndDate = movieDetails.EndDate,
                ImgUrl = movieDetails.ImgUrl,
                MovieCategory = movieDetails.MovieCategory,
                CinemaId = movieDetails.CinemaId,
                ProducerId = movieDetails.ProducerId,
                ActiorIds = movieDetails.ConnectionTables.Select(c => c.ActiorId).ToList(),
            };

            var dropDownMoviesData = await _data.GetMovieDropDownValues();

            ViewBag.Cinemas = new SelectList(dropDownMoviesData.Cinemas, "Id", "Name");
            ViewBag.Producers = new SelectList(dropDownMoviesData.Producers, "Id", "Name");
            ViewBag.Actiors = new SelectList(dropDownMoviesData.Actiors, "Id", "Name");

            return View(response);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, NewMoviesViewModel movie)
        {
            if (id != movie.Id) return View("NotFound");


            if (!ModelState.IsValid)
            {
                var dropDownMoviesData = await _data.GetMovieDropDownValues();

                ViewBag.Cinemas = new SelectList(dropDownMoviesData.Cinemas, "Id", "Name");
                ViewBag.Producers = new SelectList(dropDownMoviesData.Producers, "Id", "Name");
                ViewBag.Actiors = new SelectList(dropDownMoviesData.Actiors, "Id", "Name");
                return View(movie);
            }

            await _data.UpdateMovieAsync(movie);

            return RedirectToAction(nameof(Index));
        }
    }
}
