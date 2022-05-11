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
            var driverOwner = _dbContext.VehicleOwners.Where(vo => vo.DriverLicenseNumber == infraction.DriverLicenseNumber && vo.LicensePlateNumber == infraction.LicensePlatenumber).FirstOrDefault();

            if (driverOwner == null)
            {
                return NotFound();
            }

            Infraction driverInfraction = new Infraction
            {
                InfractionDate = infraction.InfractionDate,
                VehicleOwnerId = driverOwner.VehicleOwnerId,
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

            return Created("getinfraction", $"Infraction was successfully added");
        }
    }

    public class DriverInfraction
    {
        public string DriverLicenseNumber { get; set; }
        public string LicensePlatenumber { get; set; }
        public string Offence { get; set; }
        public DateTime InfractionDate { get; set; }

        public decimal FineAmount { get; set; }
    }

}
