using Application.DTOs.User;
using Domain.Models;

namespace Application.Abstractions
{
    public interface IAccountService
    {
        /*
         * app.MapPost($"{AccountRoutePattern}/password/confirm" => Confirm password reset (validate token and update password)
         */

        Task RegisterAsync(User user);

        Task<UserDto> GetProfileAsync(Guid userId);

        Task<string> LoginAsync(string email, string password);
    }
}