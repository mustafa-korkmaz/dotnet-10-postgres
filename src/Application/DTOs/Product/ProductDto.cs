namespace Application.DTOs.Product
{
    public record ProductDto(
        Guid Id,
        string Name,
        decimal UnitPrice,
        int StockQuantity
    );
}
