using API;
using API.Extensions;
using Application.Abstractions;
using Application.Services;
using Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddValidation();

builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IOrderService, OrderService>();

builder.Services.AddInfrastructure(builder.Configuration);

var app = builder.Build();

app.UseMiddleware<RequestHandlingMiddleware>();
app.MapApiServiceEndpoints();

await app.RunAsync();