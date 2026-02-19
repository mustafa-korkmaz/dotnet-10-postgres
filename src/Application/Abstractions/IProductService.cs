using Application.DTOs;
using Domain.Models;

namespace Application.Abstractions
{
    public interface IProductService
    {
        Task<IReadOnlyCollection<ProductDto>> GetProductsAsync();

        Task<Guid> CreateProductAsync(Product product);
    }
}