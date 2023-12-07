using Microsoft.EntityFrameworkCore;
using SportStore.Data;
using SportStore.Entities;

namespace SportStore.Repositories
{
    public class CartRepository : Repository<Cart>, ICartRepository
    {
        public CartRepository(ApplicationDbContext context) : base(context)
        {
        }

        //public IEnumerable<Cart> GetCartWithCartLine()
        //{
        //    return Cart.Include(x => x.Category).ToList();
        //}
    }
}
