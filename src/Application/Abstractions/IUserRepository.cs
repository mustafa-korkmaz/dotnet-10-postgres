using Domain.Models;

namespace Application.Abstractions
{
    public interface IUserRepository
    {
        Task CreateAsync(User user);

        Task<User?> GetDetailsAsync(Guid id);

        Task<User?> GetByEmailAsync(string email);
    }
}