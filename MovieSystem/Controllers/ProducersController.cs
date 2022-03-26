namespace MovieSystem.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using MovieSystem.Data;
    using System.Threading.Tasks;

    public class ProducersController : Controller
    {
        private readonly MovieSystemDbContext data;

        public ProducersController(MovieSystemDbContext data)
        {
            this.data = data;
        }

        public async Task<IActionResult> Index()
        {
            var allProducers = await data.Producers.ToListAsync();
            return View(allProducers);
        }
    }
}
