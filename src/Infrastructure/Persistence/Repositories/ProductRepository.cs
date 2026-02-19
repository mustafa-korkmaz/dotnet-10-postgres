using Application.Abstractions;
using Application.Pagination;
using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repositories
{
    internal class ProductRepository(PostgresDbContext dbContext) : IProductRepository
    {
        public async Task<PagedResult<Product>> ListAsync(PaginationOptions paginationOptions)
        {
            int total = 0;
            IQueryable<Product> products = dbContext.Products.AsQueryable();

            if (paginationOptions.IncludeRecordsTotal)
            {
                total = await products.CountAsync();
            }

            List<Product> items = await products
                .OrderByDescending(o => o.CreatedAt)
                .Skip(paginationOptions.Offset)
                .Take(paginationOptions.Limit)
                .ToListAsync();

            return new PagedResult<Product>(
                items,
                total);
        }
        public async Task CreateAsync(Product product)
        {
            await dbContext.Products.AddAsync(product);
            await dbContext.SaveChangesAsync();
        }
    }
}
