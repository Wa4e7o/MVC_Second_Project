namespace MovieSystem.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using MovieSystem.Data.Models;
    using MovieSystem.Services.Producers;
    using System.Threading.Tasks;

    public class ProducersController : Controller
    {
        private readonly IProducersService _data;

        public ProducersController(IProducersService data)
        {
            this._data = data;
        }

        public async Task<IActionResult> Index()
        {
            var allProducers = await _data.GetAllAsync();
            return View(allProducers);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("Name,Biography,ImageURL")] Producer producer)
        {
            if (!ModelState.IsValid)
            {
                return View(producer);
            }

            await _data.AddAsync(producer);

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Details(int id)
        {
            var producersDetails = await _data.GetByIdAsync(id);

            if (producersDetails == null) return View("_NotExist");

            return View(producersDetails);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var actorDetails = await _data.GetByIdAsync(id);

            if (actorDetails == null) return View("_NotExist");
            return View(actorDetails);
        }


        //Bind() - It will automatically convert the input fields data on the view to the properties of a complex type parameter of an action method in HttpPost request if the properties' names match with the fields on the view.
        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Biography,ImageURL")] Producer producer)
        {
            if (!ModelState.IsValid)
            {
                return View(producer);
            }

            await _data.UpdateAsync(id, producer);

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int id)
        {
            var actorDetails = await _data.GetByIdAsync(id);

            if (actorDetails == null) return View("_NotExist");
            return View(actorDetails);
        }


        //Bind() - It will automatically convert the input fields data on the view to the properties of a complex type parameter of an action method in HttpPost request if the properties' names match with the fields on the view.
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var actorDetails = await _data.GetByIdAsync(id);
            if (actorDetails == null) return View("_NotExist");

            await _data.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
