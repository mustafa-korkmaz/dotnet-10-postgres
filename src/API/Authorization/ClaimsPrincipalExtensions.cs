using System.Security.Claims;

namespace API.Authorization
{
    public static class ClaimsPrincipalExtensions
    {
        public static Guid GetUserId(this ClaimsPrincipal user)
        {
            string? userIdClaim = user.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            if (string.IsNullOrEmpty(userIdClaim) || !Guid.TryParse(userIdClaim, out Guid userId))
            {
                throw new UnauthorizedAccessException("User ID claim is missing or invalid.");
            }

            return userId;
        }
    }
}
