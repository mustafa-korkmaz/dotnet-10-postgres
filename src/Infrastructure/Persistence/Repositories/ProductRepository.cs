using Application.Abstractions;
using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repositories
{
    internal class ProductRepository(PostgresDbContext dbContext) : IProductRepository
    {
        public async Task<IReadOnlyCollection<Product>> ListAsync()
        {
            return await dbContext.Products.ToListAsync();
        }
        public async Task CreateAsync(Product product)
        {
            await dbContext.Products.AddAsync(product);
            await dbContext.SaveChangesAsync();
        }
    }
}
