using Microsoft.AspNetCore.Mvc.Rendering;
using SportStore.ViewModels.Cart;
using SportStore.ViewModels.Product;

namespace SportStore.Services
{
    public interface IProductService
    {
        int CreateProduct(AddProductFormViewModel model);
        void UpdateProduct(int id, AddProductFormViewModel model);
        bool DeleteProduct(int id);

        IEnumerable<ProductDetailViewModel> GetProducts();

        IEnumerable<SelectListItem> GetCategories();

        AddProductFormViewModel GetProductForEdit(int id);

        ProductDetailViewModel GetProductDetails(int id);

        string GetUniqueFileName(string fileName);
    }
}
