using Application.Abstractions;
using Application.DTOs.Product;
using Application.Mappings;
using Application.Pagination;
using Domain.Models;

namespace Application.Services
{
    public class ProductService(IProductRepository productRepository) : IProductService
    {
        public async Task<PagedResult<ProductDto>> ListAsync(PaginationOptions paginationOptions)
        {
            PagedResult<Product> result = await productRepository.ListAsync(paginationOptions);

            return new PagedResult<ProductDto>(
                result.Items.ToDtos(),
                result.RecordsTotal);
        }

        public async Task<Guid> CreateAsync(Product product)
        {
            await productRepository.CreateAsync(product);

            return product.Id;
        }
    }
}
