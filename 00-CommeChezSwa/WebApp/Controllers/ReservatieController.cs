using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;
using WebApp.Data;
using WebApp.Models;
using WebApp.Repositories;


namespace WebApp.Controllers
{
    public class ReservatieController : Controller
    {
        public IActionResult Index()
        {
            IEnumerable<Reservatie> reservaties = ReservatieRepository.GetAll();
            return View(reservaties);
        }

    
        public IActionResult Create()
        {
            ReservatieModel model = new ReservatieModel();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ReservatieModel model)
        {
            if (ModelState.IsValid)
            {
                Reservatie reservatie = new Reservatie
                {
                    Voornaam = model.Voornaam,
                    Familienaam = model.Familienaam,
                    Email = model.Email,
                    Tijdslot = model.Tijdslot,
                    AantalPersonen = model.AantalPersonen,
                    DatumReservatie = model.DatumReservatie
                };
                ReservatieRepository.Add(reservatie);

                //Add to repository
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        public IActionResult Details(int id)
        {
            Reservatie reservatie = ReservatieRepository.GetById(id);
            return View(reservatie);
        }


        [HttpGet]
        public IActionResult Success()
        {
            return View();
        }
    }
}
