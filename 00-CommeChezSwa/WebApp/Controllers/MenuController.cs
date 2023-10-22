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

        public IActionResult Index()
        {
            var menus = _menuRepo.GetAll().ToList();
            var model = new MenuModel
            {
                CurrentMenu = null, // No menu selected initially
                AllMenus = menus
            };

            return View(model);
        }

        //public IActionResult Index()
        //{
        //    MenuModel model = new MenuModel();
        //    model.AllMenus = _menuRepo.GetAll().ToList();
        //    return View(model);
        //}

        [HttpGet]
        public IActionResult Read(string id)
        {
            Menu menu = _menuRepo.GetById(id);
            var gerechten = menu.Gerechten.ToList();
            return View(gerechten);
        }
        //public IActionResult Display(string id)
        //{
        //    _menus = _menuRepo.GetAll().ToList();
        //    Menu menu = _menus.Single(x => x.Id == id);
        //    return View(menu);
        //}
    }
}

