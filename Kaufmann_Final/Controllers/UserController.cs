using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Kaufmann_Final.Models;
using Kaufmann_Final.Data;

namespace Kaufmann_Final.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly Kaufmann_FinaldbContext _dbContext;
        private readonly AuthenticationManager _manager;

        public UserController(Kaufmann_FinaldbContext context, AuthenticationManager manager)
        {
            _dbContext = context;
            _manager = manager;
        }

        [HttpPost]
        public async Task<ActionResult> CreateUser([FromBody] User newUser)
        {
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
                return BadRequest();
            }

            return Created("GetUsers", $"New account created as: {newUser.Username}");
        }

        [HttpPost]
        public async Task<ActionResult<string>> Login([FromBody] LoginDto user)
        {
            List<User> userList = await _dbContext.Users.Where(u => u.Username == user.Username).ToListAsync();

            User? userAccount = null;

            foreach (var possibleUser in userList)
            {
                if (possibleUser.Password == user.Password)
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
