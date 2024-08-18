using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoffeePattisserie.Shared.Dtos;
using CoffeePattisserie.Shared.ResponseDtos;

namespace CoffeePattisserie.Service.Abstract
{
    public interface ICartService
    {
         Task<Response<NoContent>> InitializeCartAsync(string userId);
        Task<Response<CartDto>> GetCartByUserIdAsync(string userId);
    }
}