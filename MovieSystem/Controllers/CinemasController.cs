namespace MovieSystem.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using MovieSystem.Data;
    using System.Linq;

    public class CinemasController : Controller
    {
        private readonly MovieSystemDbContext data;

        public CinemasController(MovieSystemDbContext data)
        {
            this.data = data;
        }

        public IActionResult Index()
        {
            var baseData = data.Cinemas.ToList();
            return View(baseData);
        }
    }
}
