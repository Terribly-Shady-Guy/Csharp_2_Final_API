using Kaufmann_Final.Models;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Kaufmann_Final.Services
{
    public class JwtManager : IJwtManager
    {
        private readonly IConfiguration _configuration;

        public JwtManager(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string CreateJwt(User user)
        {
            var jwtHandler = new JwtSecurityTokenHandler();
            byte[] tokenKey = Encoding.ASCII.GetBytes(_configuration["JWT:Key"]);

            var tokenDescripter = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.Username),
                    new Claim(ClaimTypes.Role, user.Role)
                }),
                Expires = DateTime.UtcNow.AddMinutes(15),
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(tokenKey),
                    SecurityAlgorithms.HmacSha256Signature)
            };

            SecurityToken token = jwtHandler.CreateToken(tokenDescripter);

            return jwtHandler.WriteToken(token);
        }
    }
}
