namespace Application.DTOs
{
    public record OrderDetailDto(
        Guid Id,
        Guid UserId,
        decimal Price,
        DateTimeOffset CreatedAt,
        IReadOnlyCollection<OrderItemDto> Items);
}
