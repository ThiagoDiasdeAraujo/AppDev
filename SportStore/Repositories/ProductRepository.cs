using Microsoft.CodeAnalysis.FlowAnalysis.DataFlow;
using Microsoft.EntityFrameworkCore;
using SportStore.Data;
using SportStore.Entities;
using System;

namespace SportStore.Repositories
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {

        public ProductRepository(ApplicationDbContext context) : base(context)
        {
        }

        public IEnumerable<Product> GetProductWithCategory()
        {
            return _context.Products.Include(x => x.Category).ToList();
        }
    }
}
