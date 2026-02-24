namespace Application.DTOs.Order
{
    public record OrderDto(
        Guid Id,
        Guid UserId,
        DateTimeOffset CreatedAt);
}
