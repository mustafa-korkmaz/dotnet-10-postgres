using Domain.Models;

namespace Application.Abstractions
{
    public interface IProductRepository
    {
        Task<IReadOnlyCollection<Product>> ListAsync();

        Task CreateAsync(Product product);
    }
}