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
        public async Task<ActionResult> AddNewVehicle([FromBody] NewVehicleModel vehicle)
        {
            Vehicle newVehicle = new Vehicle
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
                return BadRequest();
            }

            return Created("getVehicles", $"Vehicle successfully inserted as {newVehicle.LicensePlateNumber}");
        }
    }

    public class NewVehicleModel
    {
        public string LicensePlateNumber { get; set; }
        public List<string> DriverLicenseNumbers { get; set; }
        public string Model { get; set; }
        public string Make { get; set; }
        public string Year { get; set; }
        public DateTime TitleDateIssued { get; set; }
    }
}
