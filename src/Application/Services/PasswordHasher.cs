using System.Security.Cryptography;
using System.Text;
using Application.Abstractions;
using Konscious.Security.Cryptography;

namespace Application.Services
{
    public class PasswordHasher : IPasswordHasher
    {
        private const int SaltSize = 16;
        private const int HashSize = 32;
        private const int Iterations = 4;
        private const int MemorySize = 65536; // 64 MB
        private const int DegreeOfParallelism = 2;

        public string HashPassword(string password)
        {
            byte[] salt = RandomNumberGenerator.GetBytes(SaltSize);
            byte[] hash = HashPasswordWithSalt(password, salt);

            byte[] hashBytes = new byte[SaltSize + HashSize];
            Array.Copy(salt, 0, hashBytes, 0, SaltSize);
            Array.Copy(hash, 0, hashBytes, SaltSize, HashSize);

            return Convert.ToBase64String(hashBytes);
        }

        public bool VerifyHashedPassword(string hashedPassword, string providedPassword)
        {
            if (string.IsNullOrWhiteSpace(providedPassword))
                return false;

            byte[] hashBytes = Convert.FromBase64String(hashedPassword);

            if (hashBytes.Length != SaltSize + HashSize)
                return false;

            byte[] salt = new byte[SaltSize];
            Array.Copy(hashBytes, 0, salt, 0, SaltSize);

            byte[] hash = new byte[HashSize];
            Array.Copy(hashBytes, SaltSize, hash, 0, HashSize);

            byte[] providedHash = HashPasswordWithSalt(providedPassword, salt);

            return CryptographicOperations.FixedTimeEquals(hash, providedHash);
        }

        private static byte[] HashPasswordWithSalt(string password, byte[] salt)
        {
            using var argon2 = new Argon2id(Encoding.UTF8.GetBytes(password))
            {
                Salt = salt,
                DegreeOfParallelism = DegreeOfParallelism,
                Iterations = Iterations,
                MemorySize = MemorySize
            };

            return argon2.GetBytes(HashSize);
        }
    }
}
