using Application.Pagination;
using Domain.Models;

namespace Application.Abstractions
{
    public interface IProductRepository
    {
        Task<PagedResult<Product>> ListAsync(PaginationOptions paginationOptions);

        Task CreateAsync(Product product);
    }
}