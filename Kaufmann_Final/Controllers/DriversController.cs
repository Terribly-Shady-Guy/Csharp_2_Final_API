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
        public ActionResult<List<Driver>> GetDriver(string firstName = "", string lastName = "", string licensePlate = "", string ssn = "")
        {
            var drivers = new List<Driver>();

            if (firstName != "" && lastName != "")
            {
                drivers = _context.Drivers.Where(d => d.FirstName == firstName && d.LastName == lastName).ToList();
            }
            else if (licensePlate != "")
            {
                drivers = _context.Drivers.Where(d => d.VehicleOwners.Any(vo => vo.LicensePlateNumber == licensePlate)).ToList();
            }
            else if (ssn != "")
            {
                drivers = _context.Drivers.Where(d => d.SocialSecurity == ssn).ToList();
            }
            else
            {
                return BadRequest();
            }

            if (drivers.Count == 0)
            {
                return NotFound();
            }

            return Ok(drivers);
        }

        [Authorize(Roles = "DMV Staff")]
        [HttpPost]
        public async Task<ActionResult> AddNewDriver(NewDriver driver)
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
}
