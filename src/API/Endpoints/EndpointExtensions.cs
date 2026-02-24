namespace API.Endpoints
{
    public static class EndpointExtensions
    {
        public static void MapApiEndpoints(this IEndpointRouteBuilder app)
        {
            app.MapProductEndpoints();
            app.MapOrderEndpoints();
            app.MapAccountEndpoints();
        }
    }
}
