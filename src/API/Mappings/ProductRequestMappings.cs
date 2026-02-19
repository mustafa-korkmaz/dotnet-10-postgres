using API.Requests.Product;
using Domain.Models;

namespace API.Mappings
{
    public static class ProductRequestMappings
    {
        public static Product ToDomainModel(this CreateProductRequest request)
        {
            return Product.Create(
                request.Name!,
                request.UnitPrice!.Value,
                request.StockQuantity!.Value);
        }
    }
}