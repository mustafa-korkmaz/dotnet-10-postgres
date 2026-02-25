using Application.Pagination;
using Application.Queries;
using Domain.Models;

namespace Application.Abstractions
{
    public interface IOrderRepository
    {
        Task CreateAsync(Order order);

        Task<Order?> GetByIdAsync(Guid id);

        Task<PagedResult<Order>> ListAsync(ListOrdersQuery query);
    }
}