using AutoMapper;
using CoffeePattisserie.Data.Abstract;
using CoffeePattisserie.Entity.Concrete;
using CoffeePattisserie.Service.Abstract;
using CoffeePattisserie.Shared.Dtos;
using CoffeePattisserie.Shared.ResponseDtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CoffeePattisserie.Service.Concrete
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;

        public OrderService(IOrderRepository orderRepository, IMapper mapper)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
        }

        public async Task<Response<NoContent>> CreateAsync(OrderDto orderDto)
        {
            await _orderRepository.CreateAsync(_mapper.Map<Order>(orderDto));
            return Response<NoContent>.Success(201);
        }

        public async Task<Response<List<OrderDto>>> GetAllOrdersAsync(string? userId = null)
        {
            var orders = await _orderRepository.GetAllOrdersAsync(userId);
            return Response<List<OrderDto>>.Success(_mapper.Map<List<OrderDto>>(orders), 200);
        }

        public async Task<Response<OrderDto>> GetOrderAsync(int orderId)
        {
            var order = await _orderRepository.GetOrderAsync(orderId);
            return Response<OrderDto>.Success(_mapper.Map<OrderDto>(order), 200);
        }
    }
}
