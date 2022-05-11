#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Kaufmann_Final.Data;
using Kaufmann_Final.Models;

namespace Kaufmann_Final.Controllers
{
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
        [Route("/drivername")]
        [Authorize(Roles = "Law Enforcement, DMV Staff")]
        public ActionResult<List<Driver>> GetDriversByName(string firstName, string lastName)
        {
            List<Driver> drivers = _context.Drivers.Where(d => d.FirstName == firstName && d.LastName == lastName).ToList();

            if (drivers.Count == 0)
            {
                return NotFound();
            }

            return Ok(drivers);
        }

        [HttpGet]
        [Route("/driverssn")]
        [Authorize(Roles = "Law Enforcement, DMV Staff")]
        public ActionResult<Driver> GetDriverBySSN(string ssn)
        {
            Driver driver = _context.Drivers.Where(d => d.SocialSecurity == ssn).ToArray()[0];

            if (driver == null)
            {
                return NotFound();
            }

            return Ok(driver);
        }

        [HttpGet]
        [Route("/driverlicenseplate")]
        [Authorize(Roles = "Law Enforcement, DMV Staff")]
        public ActionResult<List<Driver>> GetDriversByPlate(string licensePlate)
        {
            List<Driver> drivers = _context.Drivers.Where(d => d.VehicleOwners.Any(v => v.DriverLicenseNumber == licensePlate)).ToList();

            if (drivers.Count == 0)
            {
                return NotFound();
            }

            return Ok(drivers);
        }

        [HttpPost]
        [Route("/newdriver")]
        [Authorize(Roles = "DMV Staff")]
        public async Task<ActionResult> AddNewDriver(Driver newDriver)
        {
            _context.Drivers.Add(newDriver);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                return Conflict();
            }

            return Created("getDriver", $"New driver {newDriver.FirstName} {newDriver.LastName} added");
        }
    }
}
