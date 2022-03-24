namespace MovieSystem.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using MovieSystem.Data;
    using System.Linq;

    public class ProducersController : Controller
    {
        private readonly MovieSystemDbContext data;

        public ProducersController(MovieSystemDbContext data)
        {
            this.data = data;
        }

        public IActionResult Index()
        {
            var baseData = data.Producers.ToList();
            return View(baseData);
        }
    }
}
