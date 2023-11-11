using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using SportStore.Data;
using SportStore.Data.Entities;
using SportStore.Models.ManageProducts;

namespace SportStore.Service
{
	public interface IProductService
	{
		ProductDetailsViewModel GetProductDetails(int id);
		string GetUniqueFileName(string fileName);
		void CreateProduct(CreateProductViewModel model);
		void EditProduct(int id, EditProductViewModel model);
        void DeleteProduct(int id);

        EditProductViewModel GetProductForEdit(int id);
	}

	public class ProductService : IProductService
	{
		private ApplicationDbContext _context;

		private readonly IHostEnvironment _hostingEnvironment;

		public ProductService(ApplicationDbContext context, IHostEnvironment hostingEnvironment)
		{
			_context = context;
			_hostingEnvironment = hostingEnvironment;
		}

		public ProductDetailsViewModel GetProductDetails(int id)
		{
			ProductDetailsViewModel viewModel = new ProductDetailsViewModel()
			{
				Product = _context.Products
				.Include(p => p.Category)
				.Where(p => p.Id == id)
				.Single()
			};
			return viewModel;
		}

		public EditProductViewModel GetProductForEdit(int id)
		{
			Product toEdit = _context.Products.Find(id);

			EditProductViewModel model = new()
			{
				CategoryId = toEdit.CategoryId,
				Name = toEdit.Name,
				Description = toEdit.Description,
				Price = toEdit.Price,
				//CurrentImageUrl = toEdit.ImageUrl,
                AllCategories = _context.Categories
				.Select(x => new SelectListItem(x.Name, x.Id.ToString()))
				.ToList()
			};
			return model;
		}

		public void EditProduct(int id, EditProductViewModel model)
		{
            Product toEdit = _context.Products.Find(id);

            toEdit.Name = model.Name;
            toEdit.Description = model.Description;
            toEdit.Price = model.Price;
            toEdit.CategoryId = model.CategoryId;

            if (model.ProductImage != null)
            {
                toEdit.ImageUrl = GetUniqueFileName(model.ProductImage.FileName);
                var uploads = Path.Combine(_hostingEnvironment.ContentRootPath, "wwwroot/imgProducts");
                var filePath = Path.Combine(uploads, toEdit.ImageUrl);
                model.ProductImage.CopyTo(new FileStream(filePath, FileMode.Create));
            }

            _context.SaveChanges();

            //productToEdit.ImageUrl = model.ProductImage;        
        }

		public void DeleteProduct(int id)
		{
            Product toDelete = _context.Products.Find(id);

			_context.Remove(toDelete);

			_context.SaveChanges();
        }

        public void CreateProduct(CreateProductViewModel model)
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
			_context.Add(product);
			_context.SaveChanges();
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
