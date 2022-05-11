using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Kaufmann_Final.Models;
using Kaufmann_Final.Data;

namespace Kaufmann_Final.Controllers
{
    [Route("api/[controller]")]
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

        [Route("/signup")]
        [HttpPost]
        public async Task<ActionResult> CreateUser(User newUser)
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

            return Created("GetUsers", $"New account created as: {newUser.Username}");
        }

        [Route("/login")]
        [HttpPost]
        public ActionResult<string> Login(UserLogin user)
        {
            string token = _manager.AuthenticateUser(user.Username, user.Password, _dbContext);

            if (token == "")
            {
                return Unauthorized();
            }

            return Ok(token);
        }
    }

    public class UserLogin
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
