using System.Text;
using Application.Abstractions;
using Application.Configuration;
using Application.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

namespace API.Authorization
{
    public static class JwtExtensions
    {
        public static void ConfigureJwt(this IServiceCollection services, IConfiguration configuration)
        {
            IConfigurationSection jwtSection = configuration.GetSection("Jwt");

            JwtConfiguration? jwtConfig = jwtSection.Get<JwtConfiguration>();

            if (jwtConfig == null)
            {
                throw new InvalidOperationException("JWT configuration is missing or invalid.");
            }

            services.Configure<JwtConfiguration>(jwtSection);

            services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();
            services.AddJwtAuthentication(jwtConfig);
            services.AddJwtAuthorization();
        }

        private static void AddJwtAuthentication(this IServiceCollection services, JwtConfiguration configuration)
        {
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = configuration.Issuer,
                        ValidAudience = configuration.Audience,
                        IssuerSigningKey = new SymmetricSecurityKey(
                            Encoding.UTF8.GetBytes(configuration.Secret)),
                        ClockSkew = TimeSpan.FromSeconds(5)
                    };
                });
        }

        private static void AddJwtAuthorization(this IServiceCollection services)
        {
            services.AddAuthorization(options =>
            {
                options.AddPolicy(Policies.RequireAuthenticatedUser, policy =>
                    policy.RequireAuthenticatedUser());
            });
        }
    }
}
