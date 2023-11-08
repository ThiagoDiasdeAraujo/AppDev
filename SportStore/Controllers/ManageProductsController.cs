using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting.Internal;
using SportStore.Data;
using SportStore.Data.Entities;
using SportStore.Models.ManageProducts;
using System;

namespace SportStore.Controllers
{
    public class ManageProductsController : Controller
    {
        private ApplicationDbContext _context;

        private readonly IHostEnvironment _hostingEnvironment;

        public ManageProductsController(IHostEnvironment environment, ApplicationDbContext AppDbContext)
        {
            _context = AppDbContext;
            _hostingEnvironment = environment;
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
                    //How to upload files in ASP.NET Core?
                    var uniqueFileName = GetUniqueFileName(model.ProductImage.FileName);
                    var uploads = Path.Combine(_hostingEnvironment.ContentRootPath, "wwwroot/imgProducts");
                    var filePath = Path.Combine(uploads, uniqueFileName);
                    model.ProductImage.CopyTo(new FileStream(filePath, FileMode.Create));

                    //sla product op in DB
                    Product product = new()
                    {
                        CategoryId = model.CategoryId,
                        Name = model.Name,
                        Description = model.Description,
                        Price = model.Price,
                        ImageUrl = uniqueFileName,
                    }; 
                    _context.Add(product);
                    _context.SaveChanges();
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        private string GetUniqueFileName(string fileName)
        {
            fileName = Path.GetFileName(fileName);
            return Path.GetFileNameWithoutExtension(fileName)
                      + "_"
                      + Guid.NewGuid().ToString().Substring(0, 4)
                      + Path.GetExtension(fileName);
        }

        // GET: ManageProductsController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ManageProductsController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
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
