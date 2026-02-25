using API.Mappings;
using API.Requests.Order;
using Application.Abstractions;

namespace API.Endpoints
{
    public static class OrderEndpoints
    {
        private const string RoutePattern = "/v1/orders";
        private const string OpenApiSpecsTag = "Orders";

        public static void MapOrderEndpoints(this IEndpointRouteBuilder app)
        {
            app.MapPost(RoutePattern, async (
                CreateOrderRequest request,
                IOrderService service) =>
            {
                Guid id = await service.CreateAsync(request.ToDomainModel());
                return TypedResults.Created($"{RoutePattern}/{id}", id);
            })
            .WithName("CreateOrder")
            .WithTags(OpenApiSpecsTag);

            app.MapGet($"{RoutePattern}/{{id:guid}}", async (
                Guid id,
                IOrderService service) => await service.GetByIdAsync(id))
            .WithName("GetOrderDetails")
            .WithTags(OpenApiSpecsTag);

            app.MapGet(RoutePattern, async (
                [AsParameters] ListOrdersRequest request,
                IOrderService service) => await service.ListAsync(request.ToQuery()))
            .WithName("ListOrders")
            .WithTags(OpenApiSpecsTag);
        }
    }
}
