using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.Text;
using TwitterClone.Application.DTOs;
using TwitterClone.Application.Interfaces;

namespace TwitterClone.Infrastructure.Auth
{
    public class JwtTokenService: ITokenService
    {
        private readonly JwtSettings _jwtSettings;
        private JsonWebTokenHandler _jwtHandler = new JsonWebTokenHandler();
        public JwtTokenService(JwtSettings jwtSettings)
        {
            _jwtSettings = jwtSettings;
        }
        public (string, DateTime) GetToken(UserDto user)
        {
            // buisness logic to return token and expiry date

            var claims = new List<Claim>()
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
                new Claim(JwtRegisteredClaimNames.Email, user.Email)
            };

            var signKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.key));


            var expiryTime = DateTime.UtcNow.AddMinutes(_jwtSettings.ExpiryTimeInMinutes);

            var descriptor = new SecurityTokenDescriptor()
            {
                Audience = _jwtSettings.Audience,
                Issuer = _jwtSettings.Issuer,
                Subject = new ClaimsIdentity(claims),
                Expires = expiryTime,
                SigningCredentials = new SigningCredentials(signKey, SecurityAlgorithms.HmacSha256)
            };

            return (_jwtHandler.CreateToken(descriptor), expiryTime);
        }
    }
}
