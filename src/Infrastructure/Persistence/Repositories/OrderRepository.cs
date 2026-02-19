using Application.Abstractions;
using Application.Pagination;
using Application.Queries;
using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repositories
{
    internal class OrderRepository(PostgresDbContext dbContext) : IOrderRepository
    {
        public async Task CreateAsync(Order order)
        {
            await dbContext.Orders.AddAsync(order);
            await dbContext.SaveChangesAsync();
        }

        public async Task<Order?> GetDetailsAsync(Guid id)
        {
            return await dbContext.Orders
                .Include(o => o.Items)
                .FirstOrDefaultAsync(o => o.Id == id);
        }

        public async Task<PagedResult<Order>> ListAsync(ListOrdersQuery query)
        {
            int total = 0;
            IQueryable<Order> orders = dbContext.Orders.AsQueryable();

            if (query.UserId is not null)
                orders = orders.Where(o => o.UserId == query.UserId);

            if (query.PaginationOptions.IncludeRecordsTotal)
            {
                total = await orders.CountAsync();
            }

            List<Order> items = await orders
                .OrderByDescending(o=>o.CreatedAt)
                .Skip(query.PaginationOptions.Offset)
                .Take(query.PaginationOptions.Limit)
                .ToListAsync();

            return new PagedResult<Order>(
                items,
                total);
        }
    }
}
