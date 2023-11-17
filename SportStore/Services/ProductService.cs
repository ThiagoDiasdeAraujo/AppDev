﻿using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using SportStore.Data;
using SportStore.Entities;
using SportStore.Repositories;
using SportStore.ViewModels.ManageProducts;

namespace SportStore.Services
{
    public class ProductService : IProductService
    {
        private readonly IHostEnvironment _hostingEnvironment;

        private IRepository<Category> _categoryRepo;

        private IProductRepository _productRepo;

        public ProductService(IProductRepository productRepo, IRepository<Category> categoryRepo, IHostEnvironment hostingEnvironment)
        {
            _categoryRepo = categoryRepo;
            _productRepo = productRepo;
            _hostingEnvironment = hostingEnvironment;
        }

        public ProductViewModel GetProductDetails(int id)
        {
            Product product = _productRepo.GetById(id);

            ProductViewModel model = new ProductViewModel()
            {
                Id = product.Id,
                Name = product.Name,
                CategoryName = product.Category.Name,
                Description = product.Description,
                Price = product.Price,
                ImageUrl = product.ImageUrl
            };
            return model;
        }

        public ProductFormViewModel GetProductForEdit(int id)
        {
            Product toEdit = _productRepo.GetById(id);

            ProductFormViewModel model = new()
            {
                Name = toEdit.Name,
                Description = toEdit.Description,
                Price = toEdit.Price,
                //ProductImage = toEdit.ImageUrl,
                CategoryId = toEdit.CategoryId,
                AllCategories = GetCategories()
            };
            return model;
        }

        public IEnumerable<SelectListItem> GetCategories()
        {
            return _categoryRepo.GetAll()
                .Select(x => new SelectListItem(x.Name, x.Id.ToString()));
        }

        public IEnumerable<ProductViewModel> GetAllProducts()
        {
            return _productRepo.GetProductWithCategory().Select(p => new ProductViewModel()
            {
                Id = p.Id,
                Name = p.Name,
                CategoryName = p.Category.Name,
                Description = p.Description,
                ImageUrl = p.ImageUrl,
                Price = p.Price
            });
        }

        public void UpdateProduct(int id, ProductFormViewModel model)
        {
            Product toUpdate = _productRepo.GetById(id);

            toUpdate.Name = model.Name;
            toUpdate.Description = model.Description;
            toUpdate.Price = model.Price;
            toUpdate.CategoryId = model.CategoryId;
            toUpdate.ImageUrl = model.ProductImage.ToString();

            if (model.ProductImage != null)
            {
                toUpdate.ImageUrl = GetUniqueFileName(model.ProductImage.FileName);
                var uploads = Path.Combine(_hostingEnvironment.ContentRootPath, "wwwroot/imgProducts");
                var filePath = Path.Combine(uploads, toUpdate.ImageUrl);
                model.ProductImage.CopyTo(new FileStream(filePath, FileMode.Create));
            }

            _productRepo.Update(toUpdate);
            _productRepo.SaveChanges();

            //productToEdit.ImageUrl = model.ProductImage;        
        }

        public bool DeleteProduct(int id)
        {
            Product toDelete = _productRepo.GetById(id);

            _productRepo.Delete(toDelete);

            _productRepo.SaveChanges();

            return true;
        }

        public int CreateProduct(ProductFormViewModel model)
        {
            //How to upload files in ASP.NET Core?
            var uniqueFileName = GetUniqueFileName(model.ProductImage.FileName);
            var uploads = Path.Combine(_hostingEnvironment.ContentRootPath, "wwwroot/imgProducts");
            var filePath = Path.Combine(uploads, uniqueFileName);
            model.ProductImage.CopyTo(new FileStream(filePath, FileMode.Create));

            //Add product in DB
            Product product = new()
            {
                Name = model.Name,
                Description = model.Description,
                Price = model.Price,
                ImageUrl = uniqueFileName,
                CategoryId = model.CategoryId
            };
            _productRepo.Add(product);
            _productRepo.SaveChanges();

            return product.Id;
        }

        public string GetUniqueFileName(string fileName)
        {
            fileName = Path.GetFileName(fileName);
            return Path.GetFileNameWithoutExtension(fileName)
                      + "_"
                      + Guid.NewGuid().ToString().Substring(0, 4)
                      + Path.GetExtension(fileName);
        }
    }
}
