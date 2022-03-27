namespace MovieSystem.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using MovieSystem.Data;
    using MovieSystem.Services.Actiors;
    using System.Threading.Tasks;

    public class ActiorsController : Controller
    {

        private readonly IActiorsService _data;

        public ActiorsController(IActiorsService data)
        {
            this._data = data;
        }

        public async Task<IActionResult> Index()
        {
            var allActiors = await _data.GetAll();
            return View(allActiors);
        }

        public IActionResult Create()
        {
            return View();
        }

    }
}
