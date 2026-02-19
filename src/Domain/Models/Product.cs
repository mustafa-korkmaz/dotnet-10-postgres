namespace Domain.Models
{
    public sealed class Product
    {
        public Guid Id { get; private init; }

        public string Name { get; private init; } = null!;

        public decimal UnitPrice { get; private init; }

        public int StockQuantity { get; private set; }

        public DateTimeOffset CreatedAt { get; private init; }

        private Product() { }

        public static Product Create(string name, decimal unitPrice, int stockQuantity)
        {
            if (unitPrice < 0 || stockQuantity < 0)
                throw new InvalidOperationException($"{nameof(unitPrice)} or {nameof(stockQuantity)} cannot be negative.");

            return new Product
            {
                Id = Guid.NewGuid(),
                Name = name,
                UnitPrice = unitPrice,
                StockQuantity = stockQuantity,
                CreatedAt = DateTimeOffset.UtcNow
            };
        }

        public void RemoveStock(int quantity)
        {
            if (quantity < 0)
                throw new InvalidOperationException($"{nameof(quantity)} cannot be negative.");

            StockQuantity -= quantity;
        }
    }
}