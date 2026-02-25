using Application.Abstractions;
using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repositories
{
    internal class UserRepository(PostgresDbContext dbContext) : IUserRepository
    {
        public async Task CreateAsync(User user)
        {
            await dbContext.Users.AddAsync(user);
            await dbContext.SaveChangesAsync();
        }

        public async Task<User?> GetByIdAsync(Guid id)
        {
            return await dbContext.Users
                .FirstOrDefaultAsync(o => o.Id == id);
        }

        public async Task<User?> GetByEmailAsync(string email)
        {
            return await dbContext.Users
                .FirstOrDefaultAsync(u => u.Email == email.ToLowerInvariant());
        }

        public async Task UpdateAsync(User user)
        {
            dbContext.Users.Update(user);
            await dbContext.SaveChangesAsync();
        }
    }
}