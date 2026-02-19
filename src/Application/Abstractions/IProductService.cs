using Application.DTOs;
using Application.Pagination;
using Domain.Models;

namespace Application.Abstractions
{
    public interface IProductService
    {
        Task<PagedResult<ProductDto>> ListProductsAsync(PaginationOptions paginationOptions);

        Task<Guid> CreateProductAsync(Product product);
    }
}