using Domain.Models;
using Application.DTOs;

namespace Application.Mappings
{
    public static class ProductMappings
    {
        public static IReadOnlyCollection<ProductDto> ToProductDtos(
                this IReadOnlyCollection<Product> products)
        {
            return products
                .Select(o => o.ToProductDto())
                .ToList();
        }

        private static ProductDto ToProductDto(this Product product)
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
