using System.Security.Claims;
using API.Authorization;
using API.Mappings;
using API.Requests.Account;
using Application.Abstractions;
using Application.DTOs.User;

namespace API.Endpoints
{
    public static class AccountEndpoints
    {
        private const string RoutePattern = "/v1/account";
        private const string OpenApiSpecsTag = "Account";

        public static void MapAccountEndpoints(this IEndpointRouteBuilder app)
        {
            app.MapPost($"{RoutePattern}/register", async (
                RegisterRequest request,
                IAccountService service,
                IPasswordHasher hasher) =>
            {
                string passwordHash = hasher.HashPassword(request.Password!);
                await service.RegisterAsync(request.ToDomainModel(passwordHash));
                return TypedResults.Created($"{RoutePattern}/profile");
            })
            .WithName("Register")
            .WithTags(OpenApiSpecsTag);

            app.MapPost($"{RoutePattern}/login", async (
                LoginRequest request,
                IAccountService service) =>
            {
                string token = await service.LoginAsync(request.Email!, request.Password!);
                return TypedResults.Ok(new { token });
            })
            .WithName("Login")
            .WithTags(OpenApiSpecsTag);

            app.MapGet($"{RoutePattern}/profile", async (
                ClaimsPrincipal user,
                IAccountService service) =>
            {
                UserDto userProfile = await service.GetProfileAsync(user.GetUserId());
                return TypedResults.Ok(userProfile);
            })
            .RequireAuthorization(Policies.RequireAuthenticatedUser)
            .WithName("GetProfile")
            .WithTags(OpenApiSpecsTag);

            app.MapPatch($"{RoutePattern}/profile", async (
                ClaimsPrincipal user,
                UpdateProfileRequest request,
                IAccountService service) =>
            {
                await service.UpdateProfileAsync(user.GetUserId(), request.NameSurname);
                return TypedResults.NoContent();
            })
            .RequireAuthorization(Policies.RequireAuthenticatedUser)
            .WithName("UpdateProfile")
            .WithTags(OpenApiSpecsTag);

            // Future endpoints:
            // - POST /v1/account/password/reset - Initiate password reset (send email with reset link)
            // - POST /v1/account/password/confirm - Confirm password reset (validate token and update password)
        }
    }
}
