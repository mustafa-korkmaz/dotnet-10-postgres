using Application.Abstractions;
using Application.DTOs.User;
using Application.Mappings;
using Domain.Models;

namespace Application.Services
{
    public class AccountService(
        IUserRepository userRepository,
        IJwtTokenGenerator jwtTokenGenerator,
        IPasswordHasher passwordHasher) : IAccountService
    {
        private const string NotFoundErrorMessage = "User with id {0} was not found";
        private const string InvalidCredentialsMessage = "Invalid email or password";

        public Task RegisterAsync(User user)
        {
            return userRepository.CreateAsync(user);
        }

        public async Task<UserDto> GetProfileAsync(Guid userId)
        {
            User? user = await userRepository.GetByIdAsync(userId);

            if (user is null)
            {
                throw new KeyNotFoundException(string.Format(NotFoundErrorMessage, userId));
            }
            return user.ToDto();
        }

        public async Task<string> LoginAsync(string email, string password)
        {
            User? user = await userRepository.GetByEmailAsync(email);

            if (user is null)
            {
                throw new UnauthorizedAccessException(InvalidCredentialsMessage);
            }

            bool isPasswordValid = passwordHasher.VerifyHashedPassword(
                user.PasswordHash,
                password);

            if (!isPasswordValid)
            {
                throw new UnauthorizedAccessException(InvalidCredentialsMessage);
            }

            return jwtTokenGenerator.GenerateToken(user);
        }

        public async Task UpdateProfileAsync(Guid userId, string? nameSurname)
        {
            User? user = await userRepository.GetByIdAsync(userId);

            if (user is null)
            {
                throw new KeyNotFoundException(string.Format(NotFoundErrorMessage, userId));
            }

            user.SetNameSurname(nameSurname);

            await userRepository.UpdateAsync(user);
        }
    }
}
