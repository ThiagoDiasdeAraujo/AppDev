using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Drawing.Text;
using WebApp.Data;
using WebApp.Models;
using WebApp.Repositories;

namespace WebApp.Controllers
{
    public class MenuController : Controller
    {
        //private MenuRepository _menuRepo = new MenuRepository();

        private readonly MenuRepository _menuRepo;

        public MenuController()
        {
            _menuRepo = new MenuRepository();
        }

        public IActionResult Index(string id)
        {
            MenuViewModel menuModel = new()
            {
                Menu = _menuRepo.GetById(id),
                Menus = _menuRepo.GetAll().ToList()
            };
            return View(menuModel);
        } 
    }
}

