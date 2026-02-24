namespace Domain.Models
{
    public class User
    {
        public Guid Id { get; private init; }

        public string Email { get; private init; } = null!;

        public string? NameSurname { get; private set; }

        public bool EmailConfirmed { get; private set; }

        public string PasswordHash { get; private set; } = null!;

        public DateTimeOffset CreatedAt { get; private init; }

        public static User Create(string email, string? nameSurname, string passwordHash)
        {
            return new User
            {
                Id = Guid.NewGuid(),
                Email = email.ToLowerInvariant(),
                NameSurname = nameSurname,
                PasswordHash = passwordHash,
                EmailConfirmed = false,
                CreatedAt = DateTimeOffset.UtcNow
            };
        }

        public void SetNameSurname(string? nameSurname)
        {
            NameSurname = nameSurname;
        }

        public void SetPasswordHash(string passwordHash)
        {
            PasswordHash = passwordHash;
        }

        public void ConfirmEmail()
        {
            EmailConfirmed = true;
        }
    }
}
