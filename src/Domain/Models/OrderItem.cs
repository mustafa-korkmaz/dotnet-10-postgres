namespace Domain.Models
{
    public class OrderItem
    {
        public Guid Id { get; }

        public Guid OrderId { get; }

        public Order? Order { get; init; }

        public Guid ProductId { get; }

        public Product? Product { get; init; }

        public decimal UnitPrice { get; }

        public int Quantity { get; }

        internal OrderItem(Guid orderId, Guid productId, decimal unitPrice, int quantity)
        {
            if (unitPrice < 0 || quantity < 0)
                throw new InvalidOperationException($"{nameof(unitPrice)} or {nameof(quantity)} cannot be negative.");

            Id = Guid.NewGuid();
            OrderId = orderId;
            ProductId = productId;
            UnitPrice = unitPrice;
            Quantity = quantity;
        }

        public decimal GetPrice()
        {
            return Quantity * UnitPrice;
        }
    }
}
