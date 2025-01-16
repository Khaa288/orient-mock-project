using System.Globalization;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using MockProject.Application.Constants;
using MockProject.Application.Enums;
using MockProject.Application.Services.Token;
using MockProject.Domain.Entities;

namespace MockProject.Infrastructure.Services.Token
{
    internal class TokenService : ITokenService
    {
        private readonly TokenConfiguration _configuration;

        public TokenService(TokenConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string CreateToken(User user, string tokenType = TokenTypeNames.Access)
        {
            var now = DateTime.Now;
            var issuer = _configuration.Issuer;
            var audience = _configuration.Audience;
            var key = Encoding.ASCII.GetBytes(_configuration.Key!);
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
                new Claim(JwtRegisteredClaimNames.Email, user.Email!),
                // new Claim(JwtRegisteredClaimNames.Jti, tokenId.ToString()),
                new Claim(JwtRegisteredClaimNames.Iat, now.ToString(CultureInfo.InvariantCulture))
            };

            claims.Add(new Claim("type", tokenType));

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = now.AddMinutes((int)TokenLifeTimeDuration.AccessLifeTimeDuration),
                Issuer = issuer,
                Audience = audience,
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha512Signature),
            };
            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }
    }
}
