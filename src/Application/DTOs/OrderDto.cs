namespace Application.DTOs
{
    public record OrderDto(
        Guid Id,
        Guid UserId,
        DateTimeOffset CreatedAt);
}
