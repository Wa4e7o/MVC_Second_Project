namespace MovieSystem.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using MovieSystem.Data;
    using System.Linq;
    using System.Threading.Tasks;

    public class ActiorsController : Controller
    {

        private readonly MovieSystemDbContext data;

        public ActiorsController(MovieSystemDbContext data)
        {
            this.data = data;
        }

        public async Task<IActionResult> Index()
        {
            var allActiors = await data.Actiors.ToListAsync();
            return View(allActiors);
        }

    }
}
