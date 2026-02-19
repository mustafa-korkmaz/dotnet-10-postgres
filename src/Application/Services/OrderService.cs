using Application.Abstractions;
using Application.DTOs;
using Application.Mappings;
using Application.Pagination;
using Application.Queries;
using Domain.Models;

namespace Application.Services
{
    public class OrderService(IOrderRepository orderRepository) : IOrderService
    {
        private const string NotFoundErrorMessage = "Order with id {0} was not found";

        public async Task<Guid> CreateOrderAsync(Order order)
        {
            await orderRepository.CreateAsync(order);

            return order.Id;
        }

        public async Task<OrderDetailDto> GetOrderDetailsAsync(Guid id)
        {
            Order? order = await orderRepository.GetDetailsAsync(id);

            if (order is null)
            {
                throw new KeyNotFoundException(string.Format(NotFoundErrorMessage, id));
            }

            return order.ToOrderDetailDto();
        }

        public async Task<PagedResult<OrderDto>> ListOrdersAsync(ListOrdersQuery query)
        {
            PagedResult<Order> result = await orderRepository.ListOrdersAsync(query);

            return new PagedResult<OrderDto>(
                result.Items.ToOrderDtos(),
                result.RecordsTotal);
        }
    }
}
