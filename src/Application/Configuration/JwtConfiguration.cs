namespace Application.Configuration
{
    public record JwtConfiguration
    {
        public string Secret { get; init; } = null!;
        public string Issuer { get; init; } = null!;
        public string Audience { get; init; } = null!;
        public int ExpirationMinutes { get; init; }
    }
}
