using Kaufmann_Final.Models;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Kaufmann_Final.Services
{
    public class JWTManager
    {
        private readonly string _key;

        public JWTManager(string key)
        {
            _key = key;
        }

        public string CreateJWT(User user)
        {
            var jwtHandler = new JwtSecurityTokenHandler();
            byte[] tokenKey = Encoding.ASCII.GetBytes(_key);

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
