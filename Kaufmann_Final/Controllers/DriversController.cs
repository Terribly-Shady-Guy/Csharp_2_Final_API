using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Kaufmann_Final.Data;
using Kaufmann_Final.Models;

namespace Kaufmann_Final.Controllers
{
    [Authorize(Roles = "Law Enforcement, DMV Staff")]
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class DriversController : ControllerBase
    {
        private readonly Kaufmann_FinaldbContext _context;

        public DriversController(Kaufmann_FinaldbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult> GetDriverByName([FromQuery] DriverNameDto driver)
        {
            Driver? foundDriver = await _context.Drivers.Where(d => d.FirstName == driver.FirstName && d.LastName == driver.LastName)
                                                        .Include(d => d.VehicleOwners)
                                                        .ThenInclude(vo => vo.Infractions)
                                                        .FirstOrDefaultAsync();

            if (foundDriver is null)
            {
                return NotFound();
            }


            return Ok(foundDriver);
        }

        [HttpGet]
        public async Task<ActionResult> GetDriverBySsn(string ssn)
        {
            Driver? foundDriver = await _context.Drivers.Where(d => d.SocialSecurity == ssn)
                                                        .Include(d => d.VehicleOwners)
                                                        .ThenInclude(vo => vo.Infractions)
                                                        .FirstOrDefaultAsync();

            if (foundDriver is null)
            {
                return NotFound();
            }


            return Ok(foundDriver);
        }

        [HttpGet]
        public async Task<ActionResult> GetDriversByLicensePlate(string licensePlateNumber)
        {
            List<Vehicle> foundDrivers = await _context.Vehicles.Where(v => v.LicensePlateNumber == licensePlateNumber)
                                                                .Include(v => v.VehicleOwners)
                                                                .ThenInclude(vo => vo.DriverLicenseNumberNavigation)
                                                                .ToListAsync();

            if (foundDrivers.Count == 0)
            {
                return NotFound();
            }

            return Ok(foundDrivers);
        }

        [Authorize(Roles = "DMV Staff")]
        [HttpPost]
        public async Task<ActionResult> AddNewDriver([FromBody] DriverDto driver)
        {
            Driver newDriver = new Driver
            {
                DriverLicenseNumber = driver.DriverLicenseNumber,
                FirstName = driver.FirstName,
                LastName = driver.LastName,
                SocialSecurity = driver.SocialSecurity,
                DateOfBirth = driver.DateOfBirth,
            };

            _context.Drivers.Add(newDriver);

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
                return BadRequest("This driver's license number already exists");
            }

            return Created("getDriver", $"New driver {newDriver.FirstName} {newDriver.LastName} added");
        }
    }
}
