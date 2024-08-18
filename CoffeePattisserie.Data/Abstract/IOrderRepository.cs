using CoffeePattisserie.Entity.Concrete;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CoffeePattisserie.Data.Abstract
{
    public interface IOrderRepository : IGenericRepository<Order>
    {
        Task<List<Order>> GetAllOrdersAsync(string userId = null);
        Task<Order> GetOrderAsync(int orderId);
    }
}
