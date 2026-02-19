using Application.Abstractions;
using Application.DTOs;
using Application.Mappings;
using Domain.Models;

namespace Application.Services
{
    public class ProductService(IProductRepository productRepository) : IProductService
    {
        public async Task<IReadOnlyCollection<ProductDto>> GetProductsAsync()
        {
            IReadOnlyCollection<Product> products = await productRepository.ListAsync();

            return products.ToProductDtos();
        }

        public async Task<Guid> CreateProductAsync(Product product)
        {
            await productRepository.CreateAsync(product);

            return product.Id;
        }
    }
}
