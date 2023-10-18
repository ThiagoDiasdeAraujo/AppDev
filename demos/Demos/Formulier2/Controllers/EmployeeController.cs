using Formulier2.Data;
using Formulier2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Formulier2.Controllers
{
    public class EmployeeController : Controller
    {
        private DepartmentRepository _repo = new DepartmentRepository();

        public IActionResult Create()
        {
            CreateEmployeeModel model = new CreateEmployeeModel();
            model.AllDepartments = _repo.GetAll().Select(x => new SelectListItem(x.Name, x.Id.ToString()));
            return View(model);
        }

        [HttpPost]
        public IActionResult Create(CreateEmployeeModel model)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("Success");
            }

            return View(model);
        }

        public IActionResult Success()
        {
            return View();
        }
    }
}
