using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using Microsoft.EntityFrameworkCore;
using Kaufmann_Final.Data;
using Kaufmann_Final.Models;
using System.Text;

namespace Kaufmann_Final
{
    public class AuthenticationManager
    {
        private readonly string _key;

        public AuthenticationManager(string key)
        {
            _key = key;
        }

        public string AuthenticateUser(string username, string password, Kaufmann_FinaldbContext context)
        {
            List<User>? userList = context.Users.Where(u => u.Username == username)
                                                .Select(u => u)
                                                .ToList();

            User? user = null;

            foreach (var possibleUser in userList)
            {
                if (possibleUser.Password == password)
                {
                    user = possibleUser;
                    break;
                }
            }

            if (user == null)
            {
                return "";
            }

            var jwtHandler = new JwtSecurityTokenHandler();
            var tokenKey = Encoding.ASCII.GetBytes(_key);

            var tokenDescripter = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, username),
                    new Claim(ClaimTypes.Role, user.Role)
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
