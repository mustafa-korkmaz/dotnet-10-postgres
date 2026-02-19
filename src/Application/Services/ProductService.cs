using Application.Abstractions;
using Application.DTOs;
using Application.Mappings;
using Application.Pagination;
using Domain.Models;

namespace Application.Services
{
    public class ProductService(IProductRepository productRepository) : IProductService
    {
        public async Task<PagedResult<ProductDto>> ListProductsAsync(PaginationOptions paginationOptions)
        {
            PagedResult<Product> result = await productRepository.ListProductsAsync(paginationOptions);

            return new PagedResult<ProductDto>(
                result.Items.ToProductDtos(),
                result.RecordsTotal);
        }

        public async Task<Guid> CreateProductAsync(Product product)
        {
            await productRepository.CreateProductAsync(product);

            return product.Id;
        }
    }
}
