using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Kaufmann_Final.Data;
using Kaufmann_Final.Models;

namespace Kaufmann_Final.Controllers
{
    [Authorize(Roles = "Law Enforcement, DMV Staff")]
    [Route("api/[controller]")]
    [ApiController]
    public class DriversController : ControllerBase
    {
        private readonly Kaufmann_FinaldbContext _context;

        public DriversController(Kaufmann_FinaldbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult> GetDriver([FromBody] DriverLookupModel driver)
        {
            Driver? foundDriver = await _context.Drivers.Where(d => d.FirstName == driver.FirstName && d.LastName == driver.LastName && d.SocialSecurity == driver.SSN)
                                                        .Include(d => d.VehicleOwners.Where(vo => vo.LicensePlateNumber == driver.LicensePlate))
                                                        .ThenInclude(vo => vo.Infractions)
                                                        .FirstOrDefaultAsync();

            if (foundDriver is null)
            {
                return NotFound();
            }


            return Ok(foundDriver);
        }

        [Authorize(Roles = "DMV Staff")]
        [HttpPost]
        public async Task<ActionResult> AddNewDriver([FromBody] NewDriver driver)
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
                return BadRequest();
            }

            return Created("getDriver", $"New driver {newDriver.FirstName} {newDriver.LastName} added");
        }
    }

    public class NewDriver
    {
        public string DriverLicenseNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string SocialSecurity { get; set; }
        public DateTime DateOfBirth { get; set; }
    }

    public class DriverLookupModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string LicensePlate { get; set; }
        public string SSN { get; set; }
    }
}
