namespace MovieSystem.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using MovieSystem.Data;
    using System.Threading.Tasks;

    public class CinemasController : Controller
    {
        private readonly MovieSystemDbContext data;

        public CinemasController(MovieSystemDbContext data)
        {
            this.data = data;
        }

        public async Task<IActionResult> Index()
        {
            var allCinemas = await data.Cinemas.ToListAsync();
            return View(allCinemas);
        }

    }
}
