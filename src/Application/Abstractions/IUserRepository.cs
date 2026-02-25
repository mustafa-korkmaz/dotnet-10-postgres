using Domain.Models;

namespace Application.Abstractions
{
    public interface IUserRepository
    {
        Task CreateAsync(User user);

        Task<User?> GetByIdAsync(Guid id);

        Task<User?> GetByEmailAsync(string email);

        Task UpdateAsync(User user);
    }
}