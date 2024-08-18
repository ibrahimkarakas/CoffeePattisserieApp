using CoffeePattisserie.Data.Abstract;
using CoffeePattisserie.Entity.Concrete;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace CoffeePattisserie.Data.Concrete.EfCore.Repositories
{
    public class EfCoreCartRepository : EfCoreGenericRepository<Cart>, ICartRepository
    {
        public EfCoreCartRepository(CoffeeAppDbContext coffeeAppDbContext) : base(coffeeAppDbContext)
        {
        }

        private CoffeeAppDbContext Context
        {
            get { return _dbContext as CoffeeAppDbContext; }
        }

        public async Task<Cart> GetCartByUserIdAsync(string userId)
        {
            return await Context
                .Carts
                .Where(x => x.UserId == userId)
                .Include(x => x.CartItems)
                .ThenInclude(y => y.Product) // Book yerine Product'ı temsil eden sınıfı kullanın.
                .FirstOrDefaultAsync();
        }
    }
}
