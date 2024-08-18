using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoffeePattisserie.Shared.Dtos;
using CoffeePattisserie.Shared.ResponseDtos;

namespace CoffeePattisserie.Service.Abstract
{
    public interface IOrderService
    {
        Task<Response<NoContent>> CreateAsync(OrderDto orderDto);
        Task<Response<OrderDto>> GetOrderAsync(int orderId);
        Task<Response<List<OrderDto>>> GetAllOrdersAsync(string? userId=null);
    }
}