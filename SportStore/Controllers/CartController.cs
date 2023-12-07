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
    public class CartController : Controller //Deze controller zal alle interacties met de shoppingcart van de gebruiker afhandelen.
    {
        private ICartService _cartService;

        public CartController(ICartService service)
        {
            _cartService = service;
        }

        [HttpPost]
        public IActionResult AddToCart(AddCartLineToCartFormViewModel model)
        {
            _cartService.AddCartLineToCart(model.ProductID, model.Quantity);

            return RedirectToAction("Details");
        }

        public IActionResult Details()
        {
            CartDetailViewModel model = _cartService.GetCartDetails();
            return View(model);
        }
    }
}
