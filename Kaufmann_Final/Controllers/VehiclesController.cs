using Kaufmann_Final.Data;
using Kaufmann_Final.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
        public async Task<ActionResult> AddNewVehicleAsync([FromBody] VehicleDto vehicle)
        {
            var newVehicle = new Vehicle
            {
                LicensePlateNumber = vehicle.LicensePlateNumber,
                Model = vehicle.Model,
                Make = vehicle.Make,
                Year = vehicle.Year
            };

            foreach (string driverLicenseNumber in vehicle.DriverLicenseNumbers)
            {
                newVehicle.VehicleOwners.Add(new VehicleOwner
                {
                    DriverLicenseNumber = driverLicenseNumber,
                    LicensePlateNumber = vehicle.LicensePlateNumber,
                    TitleDateIssued = vehicle.TitleDateIssued
                });
            }

            _context.Vehicles.Add(newVehicle);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                return Conflict();
            }
            catch (DbUpdateException)
            {
                return BadRequest("This license plate number already exists");
            }

            return Created("getVehicles", $"Vehicle successfully inserted as {newVehicle.LicensePlateNumber}");
        }
    }
}
