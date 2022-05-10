using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using Kaufmann_Final.Data;
using Kaufmann_Final.Models;
using System.Text;

namespace Kaufmann_Final
{
    public class AuthenticationManager
    {
        private readonly string _key;
        private readonly Kaufmann_FinaldbContext _context;

        public AuthenticationManager(string key, Kaufmann_FinaldbContext context)
        {
            _key = key;
            _context = context;
        }

        public string AuthenticateUser(string username, string password)
        {
            var user = _context.Users.Where(u => u.Username == username)
                .Select(u => new User())
                .ToList();

            if (user[0].Password != password)
            {
                return "";
            }

            var jwtHandler = new JwtSecurityTokenHandler();
            var tokenKey = Encoding.ASCII.GetBytes(_key);

            var tokenDescripter = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, username)
                }),
                Expires = DateTime.UtcNow.AddMinutes(30),
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(tokenKey),
                    SecurityAlgorithms.HmacSha256Signature)
            };

            var token = jwtHandler.CreateToken(tokenDescripter);

            return jwtHandler.WriteToken(token);
        }
    }
}
