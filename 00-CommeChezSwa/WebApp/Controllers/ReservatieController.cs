using Microsoft.AspNetCore.Mvc;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class ReservatieController : Controller
    {
        public IActionResult Create()
        {
            CreateReservationModel model = new CreateReservationModel();
            return View(model);
        }

        [HttpPost]
        public IActionResult Create(CreateReservationModel model)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("Success");
            }

            return View(model);
        }

        [HttpPost]
        public IActionResult Success()
        {
            return View();
        }
    }
}
