using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using Kaufmann_Final.Data;
using Kaufmann_Final.Models;

namespace Kaufmann_Final.Controllers
{
    [Authorize(Roles = "Law Enforcement")]
    [Route("api/[controller]")]
    [ApiController]

    public class InfractionController : ControllerBase
    {
        private readonly Kaufmann_FinaldbContext _dbContext;

        public InfractionController(Kaufmann_FinaldbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] DriverInfraction infraction)
        {
            int vehicleOwnerID = _dbContext.VehicleOwners.Where(vo => vo.DriverLicenseNumber == infraction.DriverLicenseNumber && vo.LicensePlateNumber == infraction.LicensePlateNumber)
                                                         .Select(vo => vo.VehicleOwnerId)
                                                         .FirstOrDefault();

            if (vehicleOwnerID == 0)
            {
                return NotFound();
            }

            Infraction driverInfraction = new Infraction
            {
                InfractionDate = infraction.InfractionDate,
                VehicleOwnerId = vehicleOwnerID,
                Offence = infraction.Offence,
                FineAmount = infraction.FineAmount,
            };

            _dbContext.Add(driverInfraction);

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

            return Created("getinfraction", $"Infraction for {infraction.DriverLicenseNumber} was successfully added");
        }
    }

    public class DriverInfraction
    {
        public string DriverLicenseNumber { get; set; }
        public string LicensePlateNumber { get; set; }
        public string Offence { get; set; }
        public DateTime InfractionDate { get; set; }
        public decimal FineAmount { get; set; }
    }

}
