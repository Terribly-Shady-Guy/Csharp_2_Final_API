using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Kaufmann_Final.Data;
using Kaufmann_Final.Models;

namespace Kaufmann_Final.Controllers
{
    [Authorize(Roles = "DMV Staff")]
    [Route("api/[controller]")]
    [ApiController]
    public class VehiclesController : ControllerBase
    {
        private readonly Kaufmann_FinaldbContext _context;

        public VehiclesController(Kaufmann_FinaldbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<ActionResult> AddNewVehicle(Vehicle newVehicle)
        {
            _context.Vehicles.Add(newVehicle);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                return Conflict();
            }

            return Created("getVehicles", $"Vehicle successfully inserted as {newVehicle.LicensePlateNumber}");
        }
    }
}
