namespace MovieSystem.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using MovieSystem.Data.Models;
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


        //Bind() - It will automatically convert the input fields data on the view to the properties of a complex type parameter of an action method in HttpPost request if the properties' names match with the fields on the view.
        [HttpPost]
        public async Task<IActionResult> Create([Bind("Name,Biography,ImageURL")]Actior actior)
        {
            if (!ModelState.IsValid)
            {
                return View(actior);
            }

            _data.Add(actior);

            return RedirectToAction(nameof(Index));
        }

    }
}
