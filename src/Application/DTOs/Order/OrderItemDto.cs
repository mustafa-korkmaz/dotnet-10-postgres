namespace Application.DTOs.Order
{
    public record OrderItemDto(
        Guid ProductId,
        decimal UnitPrice,
        int Quantity
    );
}