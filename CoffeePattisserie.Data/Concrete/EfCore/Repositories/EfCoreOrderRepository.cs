using CoffeePattisserie.Data.Abstract;
using CoffeePattisserie.Entity.Concrete;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoffeePattisserie.Data.Concrete.EfCore.Repositories
{
    public class EfCoreOrderRepository : EfCoreGenericRepository<Order>, IOrderRepository
    {
        public EfCoreOrderRepository(CoffeeAppDbContext coffeeAppDbContext) : base(coffeeAppDbContext) { }

        private CoffeeAppDbContext Context
        {
            get { return _dbContext as CoffeeAppDbContext; }
        }

        public async Task<List<Order>> GetAllOrdersAsync(string userId = null)
        {
            if (userId == null)
            {
                return await Context
                    .Orders
                    .Include(x => x.OrderItems)
                    .ThenInclude(y => y.Product)
                    .ToListAsync();
            }

            return await Context
                .Orders
                .Where(x => x.UserId == userId)
                .Include(x => x.OrderItems)
                .ThenInclude(y => y.Product)
                .ToListAsync();
        }

        public async Task<Order> GetOrderAsync(int orderId)
        {
            return await Context
                .Orders
                .Where(x => x.Id == orderId)
                .Include(x => x.OrderItems)
                .ThenInclude(y => y.Product)
                .FirstOrDefaultAsync();
        }
    }
}
