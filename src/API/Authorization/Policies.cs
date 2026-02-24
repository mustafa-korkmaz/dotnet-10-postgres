namespace API.Authorization
{
    public static class Policies
    {
        public const string RequireAuthenticatedUser = nameof(RequireAuthenticatedUser);
        public const string RequireAdminUser = nameof(RequireAdminUser);
    }
}
