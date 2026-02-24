using Application.DTOs.User;
using Domain.Models;

namespace Application.Mappings
{
    public static class UserMappings
    {
        public static UserDto ToDto(this User user)
        {
            return new UserDto(
                user.Id,
                user.Email,
                user.NameSurname,
                user.EmailConfirmed,
                user.CreatedAt
            );
        }
    }
}
