using Application.Abstractions;
using Application.DTOs.Order;
using Application.Mappings;
using Application.Pagination;
using Application.Queries;
using Domain.Models;

namespace Application.Services
{
    public class OrderService(IOrderRepository orderRepository) : IOrderService
    {
        private const string NotFoundErrorMessage = "Order with id {0} was not found";

        public async Task<Guid> CreateAsync(Order order)
        {
            await orderRepository.CreateAsync(order);

            return order.Id;
        }

        public async Task<OrderDetailDto> GetByIdAsync(Guid id)
        {
            Order? order = await orderRepository.GetByIdAsync(id);

            if (order is null)
            {
                throw new KeyNotFoundException(string.Format(NotFoundErrorMessage, id));
            }

            return order.ToOrderDetailDto();
        }

        public async Task<PagedResult<OrderDto>> ListAsync(ListOrdersQuery query)
        {
            PagedResult<Order> result = await orderRepository.ListAsync(query);

            return new PagedResult<OrderDto>(
                result.Items.ToDtos(),
                result.RecordsTotal);
        }
    }
}
