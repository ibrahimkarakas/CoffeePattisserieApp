using CoffeePattisserie.Shared.ResponseDtos;
using CoffeePattisserie.Shared.Dtos;
using System.Threading.Tasks;

namespace CoffeePattisserie.Service.Abstract
{
    public interface ICartItemService
    {
        Task<Response<NoContent>> AddToCartAsync(AddToCartDto addToCartDto);
        Task<Response<NoContent>> ClearCartAsync(string userId);
        Task<Response<NoContent>> DeleteItemFromCartAsync(int cartItemId);
        Task<Response<NoContent>> ChangeQuantityAsync(int cartItemId, int quantity);
    }
}
