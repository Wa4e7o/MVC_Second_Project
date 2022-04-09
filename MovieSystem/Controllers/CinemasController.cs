namespace MovieSystem.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using MovieSystem.Data.Models;
    using MovieSystem.Services.Cinemas;
    using System.Threading.Tasks;

    public class CinemasController : Controller
    {
        private readonly ICinemasService _data;

        public CinemasController(ICinemasService data)
        {
            this._data = data;
        }

        public async Task<IActionResult> Index()
        {
            var allCinemas = await _data.GetAllAsync();
            return View(allCinemas);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("Name,Description,Logo")] Cinema cinema)
        {
            if (!ModelState.IsValid)
            {
                return View(cinema);
            }

            await _data.AddAsync(cinema);

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Details(int id)
        {
            var cinemasDetails = await _data.GetByIdAsync(id);

            if (cinemasDetails == null) return View("_NotExist");

            return View(cinemasDetails);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var cinemaDetails = await _data.GetByIdAsync(id);

            if (cinemaDetails == null) return View("_NotExist");
            return View(cinemaDetails);
        }

    

        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Description,Logo")] Cinema cinema)
        {
            if (!ModelState.IsValid)
            {
                return View(cinema);
            }

            await _data.UpdateAsync(id, cinema);

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int id)
        {
            var cinemaDetails = await _data.GetByIdAsync(id);

            if (cinemaDetails == null) return View("_NotExist");
            return View(cinemaDetails);
        }


        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cinemaDetails = await _data.GetByIdAsync(id);
            if (cinemaDetails == null) return View("_NotExist");

            await _data.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }

    }
}
