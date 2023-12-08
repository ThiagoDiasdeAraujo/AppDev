using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SportStore.Authentication;
using SportStore.Services;
using SportStore.ViewModels.Order;
using SportStore.ViewModels.Product;

namespace SportStore.Controllers
{
    [Authorize]
    public class OrderController : Controller
    {
        private readonly IOrderService _orderService;
        private readonly UserManager<ApplicationUser> _userManager;


        public OrderController(IOrderService orderService, UserManager<ApplicationUser> userManager)
        {
            _orderService = orderService;
            _userManager = userManager;
        }

        //public ActionResult Create()
        //{

        //    AddOrderFormViewModel model = new();
        //    return View(model);
        //}

        public async Task<IActionResult> Create()
        {
            if (HttpContext.User.Identity.IsAuthenticated)
            {
                var user = await _userManager.GetUserAsync(HttpContext.User);
                if (user != null)
                {
                    AddOrderFormViewModel model = new()
                    {
                        CustomerID = user.Id,
                        OrderItems = _orderService.GetOrderItems(user.Id).ToList()
                    };
                    return View(model);
                }
            }
            return RedirectToAction("Login", "Account");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(AddOrderFormViewModel model)
        {
            var user = await _userManager.GetUserAsync(HttpContext.User);
            if (user != null)
            {
                if (ModelState.IsValid)
                {
                    model.CustomerID = user.Id;
                    _orderService.AddOrder(model);

                    return RedirectToAction(nameof(Success));
                }
                return View(model);
            }
            return RedirectToAction("Login", "Account");
        }

        public ActionResult Success()
        {
            return View();
        }

    }
}
