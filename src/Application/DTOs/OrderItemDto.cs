namespace Application.DTOs
{
    public record OrderItemDto(
        Guid ProductId,
        decimal UnitPrice,
        int Quantity
    );
}