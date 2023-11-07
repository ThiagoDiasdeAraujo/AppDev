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
            ReservatieViewModel model = new ReservatieViewModel();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ReservatieViewModel model)
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
                return RedirectToAction(nameof(Success));
            }
            return View(model);
        }

        public IActionResult Edit(int id)
        {
            Reservatie reservatie = ReservatieRepository.GetById(id);
            return View(reservatie);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Reservatie reservatie)
        {
            if (ModelState.IsValid)
            {
                ReservatieRepository.Update(reservatie);
                return RedirectToAction("Details", new { id = reservatie.ReservatieID });
            }

            return View(reservatie);
        }


        public IActionResult Details(int id)
        {
            Reservatie reservatie = ReservatieRepository.GetById(id);
            return View(reservatie);
        }

        //public IActionResult Delete(int id)
        //{
        //    Reservatie toDelete = ReservatieRepository.GetById(id);
        //    return View(toDelete);
        //}

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id) /* extra parameter nodig voor overload */
        {
            Reservatie toDelete = ReservatieRepository.GetById(id);
            ReservatieRepository.Delete(toDelete);

            return RedirectToAction("Index");
        }

        public IActionResult Success()
        {
            return View();
        }
    }
}
