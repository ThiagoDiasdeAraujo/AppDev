using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting.Internal;
using SportStore.Data;
using SportStore.Data.Entities;
using SportStore.Models.ManageProducts;
using SportStore.Service;
using System;

namespace SportStore.Controllers
{
	public class ManageProductsController : Controller
	{
		private ApplicationDbContext _context;

		private IProductService _productService;


		public ManageProductsController(ApplicationDbContext AppDbContext, IProductService productService)
		{
			_context = AppDbContext;
			_productService = productService;
		}

		// GET: ManageProductsController
		public ActionResult Index()
		{
			//return View(new Product());
			IEnumerable<Product> products = _context.Products.Include(x => x.Category).ToList();
			return View(products);
		}

		// GET: ManageProductsController/Create
		public ActionResult Create()
		{
			CreateProductViewModel model = new()
			{
				AllCategories = _context.Categories
				.Select(x => new SelectListItem(x.Name, x.Id.ToString()))
				.ToList()
			};
			return View(model);
		}

		// POST: ManageProductsController/Create
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Create(CreateProductViewModel model)
		{
			try
			{
				if (ModelState.IsValid)
				{
					_productService.CreateProduct(model);
				}
				return RedirectToAction(nameof(Index));
			}
			catch
			{
				return View();
			}
		}

		// GET: ManageProductsController/Details/5
		public ActionResult Details(int id)
		{
			ProductDetailsViewModel model = _productService.GetProductDetails(id);

			return View(model);
		}


		// GET: ManageProductsController/Edit/5
		public ActionResult Edit(int id)
		{
			EditProductViewModel model = _productService.GetProductForEdit(id);
			return View(model);
		}

		// POST: ManageProductsController/Edit/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Edit(int id, IFormCollection collection)
		{
			try
			{
				return RedirectToAction(nameof(Index));
			}
			catch
			{
				return View();
			}
		}

		// GET: ManageProductsController/Delete/5
		public ActionResult Delete(int id)
		{
			return View();
		}

		// POST: ManageProductsController/Delete/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Delete(int id, IFormCollection collection)
		{
			try
			{
				return RedirectToAction(nameof(Index));
			}
			catch
			{
				return View();
			}
		}
	}
}
