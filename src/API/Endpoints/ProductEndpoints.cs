using API.Mappings;
using API.Requests;
using API.Requests.Product;
using Application.Abstractions;

namespace API.Endpoints
{
    public static class ProductEndpoints
    {
        private const string RoutePattern = "/v1/products";
        private const string OpenApiSpecsTag = "Products";

        public static void MapProductEndpoints(this IEndpointRouteBuilder app)
        {
            app.MapPost(RoutePattern, async (
                CreateProductRequest request,
                IProductService service) =>
            {
                Guid id = await service.CreateAsync(request.ToDomainModel());
                return TypedResults.Created($"{RoutePattern}/{id}", id);
            })
            .WithName("CreateProduct")
            .WithTags(OpenApiSpecsTag);

            app.MapGet(RoutePattern, async (
                [AsParameters] PaginationRequest request,
                IProductService service) => await service.ListAsync(request.ToPaginationOptions()))
            .WithName("ListProducts")
            .WithTags(OpenApiSpecsTag);
        }
    }
}
