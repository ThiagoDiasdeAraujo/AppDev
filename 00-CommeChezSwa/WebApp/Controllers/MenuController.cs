using Microsoft.AspNetCore.Mvc;
using WebApp.Models;
using WebApp.Repositories;

namespace WebApp.Controllers
{
    public class MenuController : Controller
    {

        private readonly MenuRepository _menuRepository = new MenuRepository();
        private List<Menu> _menus;
        public MenuController(MenuRepository menuRepository)
        {
            _menuRepository = menuRepository;
        }

        public IActionResult DisplayMenu()
        {
            _menus = _menuRepository.GetAll().ToList();
            return View(_menus);
        }

        public IActionResult DisplayMenu(string id)
        {
            var currentMenu = _menuRepository.GetById(id);

            var allMenus = _menuRepository.GetAll().ToList();

            var viewModel = new ShowMenuModel
            {
                CurrentMenu = currentMenu,
                AllMenus = allMenus
            };

            return View(viewModel);
        }
    }
}
