using Domain.Models;

namespace Application.Abstractions
{
    public interface IJwtTokenGenerator
    {
        string GenerateToken(User user);
    }
}
