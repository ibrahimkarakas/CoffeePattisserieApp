using CoffeePattisserie.Entity.Concrete;
using System.Threading.Tasks;

namespace CoffeePattisserie.Data.Abstract
{
    public interface ICartRepository : IGenericRepository<Cart>
    {
        Task<Cart> GetCartByUserIdAsync(string userId);
    }
}
