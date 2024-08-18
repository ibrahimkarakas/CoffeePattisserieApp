using AutoMapper;
using CoffeePattisserie.Data.Abstract;
using CoffeePattisserie.Entity.Concrete;
using CoffeePattisserie.Service.Abstract;
using CoffeePattisserie.Shared.Dtos;
using CoffeePattisserie.Shared.ResponseDtos;
using System.Threading.Tasks;

namespace CoffeePattisserie.Service.Concrete
{
    public class CartItemService : ICartItemService
    {
        private readonly ICartItemRepository _cartItemRepository;
        private readonly ICartRepository _cartRepository;
        private readonly IMapper _mapper;

        public CartItemService(ICartItemRepository cartItemRepository, IMapper mapper, ICartRepository cartRepository)
        {
            _cartItemRepository = cartItemRepository;
            _mapper = mapper;
            _cartRepository = cartRepository;
        }

        public async Task<Response<NoContent>> AddToCartAsync(AddToCartDto addToCartDto)
        {
            var cart = await _cartRepository.GetCartByUserIdAsync(addToCartDto.UserId);
            if (cart == null)
            {
                return Response<NoContent>.Fail("Bir hata oluştu", 400);
            }

            int index = cart.CartItems.FindIndex(x => x.ProductId == addToCartDto.ProductId);
            if (index < 0) // Eklenmeye çalışılan ürün sepette daha önceden yoksa
            {
                cart.CartItems.Add(new CartItem
                {
                    ProductId = addToCartDto.ProductId,
                    CartId = cart.Id,
                    Quantity = addToCartDto.Quantity
                });
            }
            else // Eklenmeye çalışılan ürün sepette daha önceden varsa
            {
                cart.CartItems[index].Quantity += addToCartDto.Quantity;
            }

            await _cartRepository.UpdateAsync(cart);
            return Response<NoContent>.Success(204);
        }

        public async Task<Response<NoContent>> ChangeQuantityAsync(int cartItemId, int quantity)
        {
            CartItem cartItem = await _cartItemRepository.GetByIdAsync(cartItemId);
            cartItem.Quantity = quantity;
            await _cartItemRepository.UpdateAsync(cartItem);
            return Response<NoContent>.Success(204);
        }

        public async Task<Response<NoContent>> ClearCartAsync(string userId)
        {
            Cart cart = await _cartRepository.GetCartByUserIdAsync(userId);
            cart.CartItems = new List<CartItem>();
            await _cartRepository.UpdateAsync(cart);
            return Response<NoContent>.Success(200);
        }

        public async Task<Response<NoContent>> DeleteItemFromCartAsync(int cartItemId)
        {
            CartItem cartItem = await _cartItemRepository.GetByIdAsync(cartItemId);
            await _cartItemRepository.DeleteAsync(cartItem);
            return Response<NoContent>.Success(200);
        }
    }
}
