using Formulier.Models;
using Microsoft.AspNetCore.Mvc;

namespace Formulier.Controllers
{
    public class BookController : Controller
    {
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(BookModel model)
        {
            //als ons form geen fouten
            if (ModelState.IsValid)
            {
                //bijvoorbeeld opslaan in db (hier is da naar de succes page gaan)
                
                return RedirectToAction(nameof(Success)); //Post/Redirect/Get-pattern
            }
            // formulier bevat fouten => toon form opnieuw
            //geven model => invoervelden bewaren
            return View(model);
        }

        [HttpPost]
        public IActionResult Success()
        {
            return View();
        }
    }
}
