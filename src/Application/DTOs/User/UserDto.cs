
namespace Application.DTOs.User
{
    public record UserDto(
        Guid Id,
        string Email,
        string? NameSurname,
        bool IsEmailConfirmed,
        DateTimeOffset CreatedAt
    );
}