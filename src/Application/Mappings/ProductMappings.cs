using Domain.Models;
using Application.DTOs.Product;

namespace Application.Mappings
{
    public static class ProductMappings
    {
        public static IReadOnlyCollection<ProductDto> ToDtos(
                this IReadOnlyCollection<Product> products)
        {
            return products
                .Select(o => o.ToDto())
                .ToList();
        }

        private static ProductDto ToDto(this Product product)
        {
            return new ProductDto(
                product.Id,
                product.Name,
                product.UnitPrice,
                product.StockQuantity
            );
        }
    }
}
