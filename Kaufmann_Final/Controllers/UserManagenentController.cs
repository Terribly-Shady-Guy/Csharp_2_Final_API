using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Kaufmann_Final.Models;
using Kaufmann_Final.Data;

namespace Kaufmann_Final.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserManagenentController : ControllerBase
    {
        private readonly Kaufmann_FinaldbContext _dbContext;

        public UserManagenentController(Kaufmann_FinaldbContext context)
        {
            _dbContext = context;
        }

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

            return Created("GetUsers", newUser.Username);
        }
    }
}
