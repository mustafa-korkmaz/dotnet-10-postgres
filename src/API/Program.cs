using API;
using API.Authorization;
using API.Endpoints;
using Application.Abstractions;
using Application.Services;
using Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddValidation();

builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IOrderService, OrderService>();
builder.Services.AddScoped<IAccountService, AccountService>();
builder.Services.AddSingleton<IPasswordHasher, PasswordHasher>();

builder.Services.ConfigureJwt(builder.Configuration);

builder.Services.AddInfrastructure(builder.Configuration);

var app = builder.Build();

app.UseMiddleware<RequestHandlingMiddleware>();

app.UseAuthentication();
app.UseAuthorization();

app.MapApiEndpoints();

await app.RunAsync();