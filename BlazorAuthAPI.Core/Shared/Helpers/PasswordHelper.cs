using System.Text;
using Konscious.Security.Cryptography;

namespace BlazorAuthAPI.Core.Shared.Helpers
{
    public class PasswordHelper
    {
        public static bool IsValid(string? password)
        {
            if (string.IsNullOrEmpty(password))
                return false;

            if (string.IsNullOrEmpty(password))
                return false;

            return password.Length >= 8
                   && password.Any(c => c is >= 'A' and <= 'Z')
                   && password.Any(c => c is >= '0' and <= '9');
        }

        public static string HashPassword(string password)
        {
            var bytes = Encoding.UTF8.GetBytes(password);

            var salt = new byte[16];
            var random = new Random();

            random.NextBytes(salt);

            var argon2 = new Argon2i(bytes)
            {
                Salt = salt,
                DegreeOfParallelism = 8,
                MemorySize = 65536,
                Iterations = 4
            };

            var hashBytes = argon2.GetBytes(32);

            var hashBase64 = Convert.ToBase64String(hashBytes);
            var saltBase64 = Convert.ToBase64String(salt);

            return $"{saltBase64}:{hashBase64}";
        }

        public static bool VerifyPassword(string? password, string? storedHash)
        {
            if (string.IsNullOrEmpty(password) || string.IsNullOrEmpty(storedHash))
                return false;

            var parts = storedHash.Split(':');
            if (parts.Length != 2)
                throw new FormatException("Formato de hash armazenado inválido");

            var salt = Convert.FromBase64String(parts[0]);
            var storedHashBytes = Convert.FromBase64String(parts[1]);

            var passwordBytes = Encoding.UTF8.GetBytes(password);

            var argon2 = new Argon2i(passwordBytes)
            {
                Salt = salt,
                DegreeOfParallelism = 8,
                MemorySize = 65536,
                Iterations = 4
            };

            var hashBytes = argon2.GetBytes(32);

            return CompareBytes(hashBytes, storedHashBytes);
        }

        private static bool CompareBytes(byte[] a, byte[] b)
        {
            if (a.Length != b.Length)
                return false;

            return !a.Where((t, i) => t != b[i]).Any();
        }
    }
}
