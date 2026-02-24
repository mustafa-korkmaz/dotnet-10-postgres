using Application.DTOs.Product;
using Application.Pagination;
using Domain.Models;

namespace Application.Abstractions
{
    public interface IProductService
    {
        Task<PagedResult<ProductDto>> ListAsync(PaginationOptions paginationOptions);

        Task<Guid> CreateAsync(Product product);
    }
}