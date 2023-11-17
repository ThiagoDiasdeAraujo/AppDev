using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting.Internal;
using SportStore.Data;
using SportStore.Entities;
using SportStore.Services;
using SportStore.ViewModels.ManageProducts;
using System;

namespace SportStore.Controllers
{
    public class ManageProductsController : Controller
    {
        private IProductService _productService;

        public ManageProductsController(IProductService productService)
        {
            _productService = productService;
        }

        // GET: ManageProductsController
        public ActionResult Index()
        {
            //return View(new Product());
            IEnumerable<ProductViewModel> products = _productService.GetAllProducts();
            return View(products);
        }

        // GET: ManageProductsController/Create
        public ActionResult Create()
        {
            ProductFormViewModel model = new()
            {
                AllCategories = _productService.GetCategories(),
            };
            return View(model);
        }

        // POST: ManageProductsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ProductFormViewModel model)
        {
            if (ModelState.IsValid)
            {
                _productService.CreateProduct(model);
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        // GET: ManageProductsController/Details/5
        public ActionResult Details(int id)
        {
            ProductViewModel model = _productService.GetProductDetails(id);

            if (model == null)
            {
                // Handle the null case, redirect to an error page, or return a default view
                return NotFound(); // Or another appropriate result
            }

            return View(model);
        }

        // GET: ManageProductsController/Edit/5
        public ActionResult Edit(int id)
        {
            ProductFormViewModel model = _productService.GetProductForEdit(id);

            return View(model);
        }

        // POST: ManageProductsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, ProductFormViewModel model)
        {
            if (ModelState.IsValid)
            {

                _productService.UpdateProduct(id, model);
                return RedirectToAction(nameof(Index));
            }

            return View(model);
        }

        // POST: ManageProductsController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            _productService.DeleteProduct(id);

            return RedirectToAction(nameof(Index));
        }
    }
}

