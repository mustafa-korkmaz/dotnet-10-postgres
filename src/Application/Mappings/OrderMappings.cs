using Domain.Models;
using Application.DTOs.Order;

namespace Application.Mappings
{
    public static class OrderMappings
    {
        public static IReadOnlyCollection<OrderDto> ToDtos(
            this IReadOnlyCollection<Order> orders)
        {
            return orders
                .Select(o => o.ToDto())
                .ToList();
        }

        public static OrderDetailDto ToOrderDetailDto(this Order order)
        {
            return new OrderDetailDto(
                order.Id,
                order.UserId,
                order.Price,
                order.CreatedAt,
                order.Items
                    .Select(o => o.ToOrderItemDto())
                    .ToList()
            );
        }

        private static OrderItemDto ToOrderItemDto(
            this OrderItem orderItem)
        {
            return new OrderItemDto(
                orderItem.ProductId,
                orderItem.UnitPrice,
                orderItem.Quantity);
        }

        private static OrderDto ToDto(this Order order)
        {
            return new OrderDto(
                order.Id,
                order.UserId,
                order.CreatedAt
            );
        }
    }
}
