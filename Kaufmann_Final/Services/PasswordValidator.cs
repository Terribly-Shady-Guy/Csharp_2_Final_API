using Microsoft.AspNetCore.Identity;
using Kaufmann_Final.Models;

namespace Kaufmann_Final.Services
{
    public class PasswordValidator
    {
        public User? ValidatePassword(List<User> users, LoginDto user)
        {
            User? userAccount = null;

            var hasher = new PasswordHasher<User>();

            foreach (var possibleUser in users)
            {
                var result = hasher.VerifyHashedPassword(possibleUser, possibleUser.Password, user.Password);
                if (result == PasswordVerificationResult.Success)
                {
                    userAccount = possibleUser;
                    break;
                }
            }

            return userAccount;
        }
    }
}
