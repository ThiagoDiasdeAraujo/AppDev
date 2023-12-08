using SportStore.Entities;

namespace SportStore.Repositories
{
    public interface IProductRepository : IRepository<Product>
    {
        IEnumerable<Product> GetProductWithCategory();
    }
}
