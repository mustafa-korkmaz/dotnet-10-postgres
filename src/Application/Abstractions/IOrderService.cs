using Application.DTOs;
using Application.Pagination;
using Application.Queries;
using Domain.Models;

namespace Application.Abstractions
{
    public interface IOrderService
    {
        Task<Guid> CreateOrderAsync(Order order);

        Task<OrderDetailDto> GetOrderDetailsAsync(Guid id);

        Task<PagedResult<OrderDto>> ListOrdersAsync(ListOrdersQuery query);
    }
}