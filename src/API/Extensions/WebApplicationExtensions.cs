using API.Mappings;
using API.Requests;
using API.Requests.Order;
using API.Requests.Product;
using Application.Abstractions;

namespace API.Extensions
{
    public static class WebApplicationExtensions
    {
        private const string ProductRoutePattern = "/v1/products";
        private const string OrderRoutePattern = "/v1/orders";

        public static void MapApiServiceEndpoints(this WebApplication app)
        {
            app.MapProductEndpoints();
            app.MapOrderEndpoints();
        }

        private static void MapProductEndpoints(this WebApplication app)
        {
            app.MapPost(ProductRoutePattern, async (
                CreateProductRequest request,
                    IProductService service) =>
            {
                Guid id = await service.CreateAsync(request.ToDomainModel());

                return TypedResults.Created($"{ProductRoutePattern}/{id}", id);
            });

            app.MapGet(ProductRoutePattern, async (
                [AsParameters] PaginationRequest request,
                IProductService service) => await service.ListAsync(request.ToPaginationOptions()));
        }

        private static void MapOrderEndpoints(this WebApplication app)
        {
            app.MapPost(OrderRoutePattern, async (
                CreateOrderRequest request,
                IOrderService service) =>
            {
                Guid id = await service.CreateAsync(request.ToDomainModel());

                return TypedResults.Created($"{OrderRoutePattern}/{id}", id);
            });

            app.MapGet($"{OrderRoutePattern}/{{id:guid}}", async (
                 Guid id,
                 IOrderService service) => await service.GetDetailsAsync(id));

            app.MapGet(OrderRoutePattern, async (
                [AsParameters] ListOrdersRequest request,
                IOrderService service) => await service.ListAsync(request.ToQuery()));
        }
    }
}
