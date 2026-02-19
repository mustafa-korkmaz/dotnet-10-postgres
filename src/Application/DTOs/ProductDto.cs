namespace Application.DTOs
{
    public record ProductDto(
        Guid Id,
        string Name,
        decimal UnitPrice,
        int StockQuantity
    );
}
