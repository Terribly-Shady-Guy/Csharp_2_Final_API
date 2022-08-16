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
        private readonly JWTManager _manager;

        public UserController(Kaufmann_FinaldbContext context, JWTManager manager)
        {
            _dbContext = context;
            _manager = manager;
        }

        [HttpPost(Name = "signup")]
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

        [HttpPost(Name = "login")]
        public async Task<ActionResult<string>> Login([FromBody] LoginDto user)
        {
            List<User> users = await _dbContext.Users.Where(u => u.Username == user.Username).ToListAsync();

            var validator = new PasswordValidator();
            User? userAccount = validator.ValidatePassword(users, user);

            if (userAccount is null)
            {
                return Unauthorized();
            }

            string token = _manager.CreateJWT(userAccount);

            var options = new CookieOptions
            {
                HttpOnly = true,
                Expires = DateTime.UtcNow.AddMinutes(30),
                SameSite = SameSiteMode.Strict,
                IsEssential = true,
                Secure = true
            };

            Response.Cookies.Append("DMVLaw-Access-Token", token, options);

            return Ok("User logged in");
        }

        [HttpDelete(Name = "logout")]
        public ActionResult Logout()
        {
            if (!Request.Cookies.ContainsKey("DMVLaw-Access-Token"))
            {
                return BadRequest("User is not logged in");
            }

            Response.Cookies.Delete("DMVLaw-Access-Token");
            return NoContent();
        }
    }
}
