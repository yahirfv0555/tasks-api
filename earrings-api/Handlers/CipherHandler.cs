using earrings_api;
using EarringsApi.Features.Users.Models;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;

namespace EarringsApi.Handlers
{
    public class CipherHandler
    {
        private static readonly string payloadIssuer = "TASKS_API";
        private static readonly string payloadAudience = "MY_PROJECTS";

        internal (byte[] hash, byte[] salt) HashPassword(string password)
        {
            byte[] salt = new byte[128];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(salt);
            }

            using var pbkdf2 = new Rfc2898DeriveBytes(password, salt, 100_000, HashAlgorithmName.SHA256);
            byte[] hash = pbkdf2.GetBytes(64);
            return (hash, salt);
        }

        internal AuthenticationStatus ComparePasswords(byte[] hash, byte[] salt, string password)
        {
            using var pbkdf2 = new Rfc2898DeriveBytes(password, salt, 100_000, HashAlgorithmName.SHA256);

            byte[] computedHash = pbkdf2.GetBytes(64);

            return CryptographicOperations.FixedTimeEquals(computedHash, hash) ? AuthenticationStatus.AUTHENTICATED : AuthenticationStatus.NOT_AUTHENTICATED;
        }

    }
}
