using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;
using SportStore.Entities;
using SportStore.Helpers;
using SportStore.Models;
using SportStore.Services;
using SportStore.ViewModels.Cart;
using SportStore.ViewModels.Product;
using System.Text.Json;

namespace SportStore.Controllers
{
    [Authorize]
    public class CartController : Controller //Deze controller zal alle interacties met de shoppingcart van de gebruiker afhandelen.
    {
        private ICartService _cartService;

        public CartController(ICartService service)
        {
            _cartService = service;
        }

        public IActionResult Index()
        {
            CartDetailViewModel model = _cartService.GetCartDetails();
            return View(model);
        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult AddToCart(AddCartLineToCartFormViewModel model)
        {
            if (model.Quantity > 0)
            {
                _cartService.AddCartLineToCart(model.ProductID, model.Quantity);
                return RedirectToAction(nameof(Index));
            }
            return RedirectToAction("Details", "Product", new { id = model.ProductID });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult RemoveCartLine(int id)
        {
            _cartService.RemoveCartLineFromCart(id);
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EmptyCart()
        {
            _cartService.ClearCart();
            return RedirectToAction("Index", "Product");
        }
    }
}
