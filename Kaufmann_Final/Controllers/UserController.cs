using Kaufmann_Final.Data;
using Kaufmann_Final.Models;
using Kaufmann_Final.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Kaufmann_Final.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly Kaufmann_FinaldbContext _dbContext;
        private readonly JwtManager _manager;

        public UserController(Kaufmann_FinaldbContext context, JwtManager manager)
        {
            _dbContext = context;
            _manager = manager;
        }

        [HttpPost(Name = "signup")]
        public async Task<ActionResult> CreateUserAsync([FromBody] User newUser)
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

        [HttpPost(Name = "login")]
        public async Task<ActionResult<string>> LoginAsync([FromBody] LoginDto user)
        {
            List<User> users = await _dbContext.Users.Where(u => u.Username == user.Username).ToListAsync();

            var validator = new PasswordValidator();
            User? userAccount = validator.ValidatePassword(users, user);

            if (userAccount is null)
            {
                return Unauthorized();
            }

            string token = _manager.CreateJwt(userAccount);

            return Ok(token);
        }

        [HttpPut]
        public async Task<ActionResult> UpdatePasswordAsync(LoginDto user)
        {
            User? userData = await _dbContext.Users.Where(u => u.Username == user.Username).FirstOrDefaultAsync();

            if (userData is null) 
            {
                return NotFound();
            }

            var hasher = new PasswordHasher<User>();
            userData.Password = hasher.HashPassword(userData, user.Password);

            _dbContext.Attach(userData);
            _dbContext.Entry(userData).Property(u => u.Password).IsModified = true;

            try
            { 
                await _dbContext.SaveChangesAsync(); 
            }
            catch (DbUpdateException) 
            {
                return BadRequest();
            }

            return Ok($"User {user.Username} password updated");
        }
    }
}
