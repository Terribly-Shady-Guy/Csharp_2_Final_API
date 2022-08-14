using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Kaufmann_Final.Models;
using Kaufmann_Final.Data;

namespace Kaufmann_Final.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly Kaufmann_FinaldbContext _dbContext;
        private readonly JWTManager _manager;

        public UserController(Kaufmann_FinaldbContext context, JWTManager manager)
        {
            _dbContext = context;
            _manager = manager;
        }

        [HttpPost]
        public async Task<ActionResult> CreateUser([FromBody] User newUser)
        {
            var hasher = new PasswordHasher<User>();

            newUser.Password = hasher.HashPassword(newUser, newUser.Password);

            _dbContext.Users.Add(newUser);

            try
            {
                await _dbContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                return Conflict();
            }
            catch (DbUpdateException)
            {
                return BadRequest("This user already exists");
            }

            return Created("GetUsers", $"New account created as: {newUser.Username}");
        }

        [HttpPost]
        public async Task<ActionResult<string>> Login([FromBody] LoginDto user)
        {
            List<User> userList = await _dbContext.Users.Where(u => u.Username == user.Username).ToListAsync();

            User? userAccount = null;

            var hasher = new PasswordHasher<User>();

            foreach (var possibleUser in userList)
            {
                var result = hasher.VerifyHashedPassword(possibleUser, possibleUser.Password, user.Password);
                if (result == PasswordVerificationResult.Success)
                {
                    userAccount = possibleUser;
                    break;
                }
            }

            if (userAccount is null)
            {
                return Unauthorized();
            }

            string token = _manager.CreateJWT(userAccount);

            return Ok(token);
        }
    }
}
