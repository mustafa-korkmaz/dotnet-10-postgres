using API.Requests.Order;
using Application.Queries;
using Domain.Models;

namespace API.Mappings
{
    public static class OrderRequestMappings
    {
        public static Order ToDomainModel(this CreateOrderRequest request)
        {
            Order order = Order.Create(Guid.Parse(request.UserId!));

            request.Items!.ToList().ForEach(item =>
            {
                order.AddItem(Guid.Parse(item.ProductId!), item.UnitPrice!.Value, item.Quantity!.Value);
            });

            return order;
        }

        public static ListOrdersQuery ToQuery(this ListOrdersRequest request)
        {
            return new ListOrdersQuery(
                request.UserId == null ? null : Guid.Parse(request.UserId),
                request.ToPaginationOptions());
        }
    }
}