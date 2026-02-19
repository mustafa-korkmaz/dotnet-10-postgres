using Application.DTOs;
using Application.Pagination;
using Application.Queries;
using Domain.Models;

namespace Application.Abstractions
{
    public interface IOrderService
    {
        Task<Guid> CreateAsync(Order order);

        Task<OrderDetailDto> GetDetailsAsync(Guid id);

        Task<PagedResult<OrderDto>> ListAsync(ListOrdersQuery query);
    }
}