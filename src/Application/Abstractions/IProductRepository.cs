using Application.Pagination;
using Domain.Models;

namespace Application.Abstractions
{
    public interface IProductRepository
    {
        Task<PagedResult<Product>> ListProductsAsync(PaginationOptions paginationOptions);

        Task CreateProductAsync(Product product);
    }
}