namespace MovieSystem.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using MovieSystem.Data;
    using System.Linq;

    public class ActiorsController : Controller
    {

        private readonly MovieSystemDbContext data;

        public ActiorsController(MovieSystemDbContext data)
        {
            this.data = data;
        }

        public IActionResult Index()
        {
            var baseData = data.Actiors.ToList();
            return View(baseData);
        }
    }
}
