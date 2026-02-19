namespace Domain.Models
{
    public sealed class Order
    {
        public Guid Id { get; private init; }

        public Guid UserId { get; private init; }

        public decimal Price => Items.Sum(x => x.GetPrice());

        public DateTimeOffset CreatedAt { get; private init; }

        private readonly List<OrderItem> _items = new();

        public IReadOnlyCollection<OrderItem> Items => _items;

        private Order() { }

        public static Order Create(Guid userId)
        {
            return new Order
            {
                Id = Guid.NewGuid(),
                UserId = userId,
                CreatedAt = DateTimeOffset.UtcNow
            };
        }

        public void AddItem(Guid productId, decimal unitPrice, int quantity)
        {
            _items.Add(new OrderItem(Id, productId, unitPrice, quantity));
        }
    }
}
