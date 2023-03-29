using System.Text;
using System.Security.Cryptography;

namespace Domain.Core
{
    public static class ShortIdGenerator
    {
        private const int IdLengthMin = 10;
        private const int IdLengthMax = 12;
        private const string AllowedCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";

        public static string GenerateShortId()
        {
            int idLength = new Random().Next(IdLengthMin, IdLengthMax + 1);
            var bytes = new byte[idLength];

            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(bytes);
            }

            var result = new StringBuilder(idLength);
            foreach (var b in bytes)
            {
                result.Append(AllowedCharacters[b % AllowedCharacters.Length]);
            }

            return result.ToString();
        }
    }
}

