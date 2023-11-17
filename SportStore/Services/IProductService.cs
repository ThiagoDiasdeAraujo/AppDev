using Microsoft.AspNetCore.Mvc.Rendering;
using SportStore.ViewModels.ManageProducts;

namespace SportStore.Services
{
    public interface IProductService
    {
        int CreateProduct(ProductFormViewModel model);
        void UpdateProduct(int id, ProductFormViewModel model);
        bool DeleteProduct(int id);

        IEnumerable<ProductViewModel> GetAllProducts();
        IEnumerable<SelectListItem> GetCategories();

        string GetUniqueFileName(string fileName);

        ProductFormViewModel GetProductForEdit(int id);
        ProductViewModel GetProductDetails(int id);
    }
}
