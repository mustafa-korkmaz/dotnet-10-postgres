using Application.DTOs.User;
using Domain.Models;

namespace Application.Abstractions
{
    public interface IAccountService
    {
        Task RegisterAsync(User user);

        Task<UserDto> GetProfileAsync(Guid userId);

        Task<string> LoginAsync(string email, string password);

        Task UpdateProfileAsync(Guid userId, string? nameSurname);
    }
}