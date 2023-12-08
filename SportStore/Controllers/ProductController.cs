using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting.Internal;
using SportStore.Data;
using SportStore.Entities;
using SportStore.Services;
using SportStore.ViewModels.Product;
using System;

namespace SportStore.Controllers
{
    [Authorize(Policy = "AdminOnly")]
    public class ProductController : Controller
    {
        private IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [AllowAnonymous]
        public ActionResult Index()
        {
            //return View(new Product());
            IEnumerable<ProductDetailViewModel> products = _productService.GetProducts();
            return View(products);
        }

        public ActionResult Create()
        {
            AddProductFormViewModel model = new()
            {
                AllCategories = _productService.GetCategories(),
            };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(AddProductFormViewModel model)
        {
            if (ModelState.IsValid)
            {
                _productService.CreateProduct(model);
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        public ActionResult Details(int id)
        {
            ProductDetailViewModel model = _productService.GetProductDetails(id);

            if (model == null)
            {
                // Handle the null case, redirect to an error page, or return a default view
                return NotFound(); // Or another appropriate result
            }

            return View(model);
        }

        public ActionResult Edit(int id)
        {
            AddProductFormViewModel model = _productService.GetProductForEdit(id);

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, AddProductFormViewModel model)
        {
            if (ModelState.IsValid)
            {

                _productService.UpdateProduct(id, model);
                return RedirectToAction(nameof(Index));
            }

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            _productService.DeleteProduct(id);

            return RedirectToAction(nameof(Index));
        }
    }
}

