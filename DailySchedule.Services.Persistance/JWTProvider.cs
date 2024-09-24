using DailySchedule.Domain.Core;
using DailySchedule.Infrastructure.Interfaces;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace DailySchedule.Services.Persistance
{
    public class JWTProvider: IJwtProvider
    {
        private readonly JwtOptions options;
        public JWTProvider(IOptions<JwtOptions> options)
        {
            this.options = options.Value;
        }
        public string GenerateToken(User user)
        {
            Claim[] claims = [new("userId", user.Id.ToString())];
            var signingCredentials = new SigningCredentials(
                new SymmetricSecurityKey(Encoding.UTF8.GetBytes(options.SecretKey)), SecurityAlgorithms.Sha256);
            var token = new JwtSecurityToken(
                claims: claims,
                signingCredentials: signingCredentials,
                expires: DateTime.UtcNow.AddHours(options.ExpiresHours)
                );

            var tokenValue = new JwtSecurityTokenHandler().WriteToken(token);

            return tokenValue.ToString();
        }
    }
}
