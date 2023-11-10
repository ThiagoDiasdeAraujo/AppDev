using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
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
                AllCategories = _context.Categories
				.Select(x => new SelectListItem(x.Name, x.Id.ToString()))
				.ToList()
			};
			return model;
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
				CategoryId = model.CategoryId,
				Name = model.Name,
				Description = model.Description,
				Price = model.Price,
				ImageUrl = uniqueFileName,
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
