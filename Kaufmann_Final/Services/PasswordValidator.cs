using Kaufmann_Final.Models;
using Microsoft.AspNetCore.Identity;

namespace Kaufmann_Final.Services
{
    public class PasswordValidator
    {
        public User? ValidatePassword(List<User> users, LoginDto user)
        {
            var hasher = new PasswordHasher<User>();

            foreach (var possibleUser in users)
            {
                var result = hasher.VerifyHashedPassword(possibleUser, possibleUser.Password, user.Password);
                if (result == PasswordVerificationResult.Success)
                {
                    return possibleUser;
                }
            }

            return null;
        }
    }
}
