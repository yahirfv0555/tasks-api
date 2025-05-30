using EarringsApi.Features.Users.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Text.Json;

namespace earrings_api.Middleware
{
    public class Auth
    {
        private static readonly string payloadIssuer = "TASKS_API";
        private static readonly string payloadAudience = "MY_PROJECTS";
        internal void ValidateJWT(IServiceCollection services)
        {
            string secretKey = JsonConfiguration.AppSetting.GetValue<string>("SecretKey") ?? "";

            services
                .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, jwtBearerOptions => {
                        jwtBearerOptions.TokenValidationParameters = new()
                        {
                            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey)),
                            ValidIssuer = payloadIssuer,
                            ValidAudience = payloadAudience,
                            RequireExpirationTime = true
                        };
                    }
                );
        }

        internal string GetJwt(UserDto user)
        {
            string? secretKey = JsonConfiguration.AppSetting["SecretKey"];

            SymmetricSecurityKey securityKey = new(Encoding.UTF8.GetBytes(secretKey));
            SigningCredentials credentials = new(securityKey, SecurityAlgorithms.HmacSha256);
            JwtHeader header = new(credentials);

            string userJson = JsonSerializer.Serialize(user);

            Claim[] claims = [new("user", userJson, JsonClaimValueTypes.Json)];

            JwtPayload payload = new(
                issuer: payloadIssuer,
                audience: payloadAudience,
                claims: claims,
                notBefore: DateTime.Now,
                expires: DateTime.Now.AddHours(24)
            );

            var token = new JwtSecurityToken(header, payload);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
