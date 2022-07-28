using Microsoft.VisualStudio.TestTools.UnitTesting;
using Kaufmann_Final.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Kaufmann_FinalTests;

namespace Kaufmann_Final.Controllers.Tests
{
    [TestClass()]
    public class DriversControllerTests
    {
        [TestMethod()]
        public void GetDriverGoodDataTest()
        {
            var controller = new DriversController(TestDBContextCreator.CreateTestContext());
            var mockData = new DriverLookupModel
            {
                FirstName = "John",
                LastName = "Doe",
                LicensePlate = "ABC123",
                SSN = "123-45-6789"
            };

            var data = controller.GetDriver(mockData).Result;

            Assert.IsInstanceOfType(data, typeof(OkObjectResult));
        }

        [TestMethod()]
        public void GetDriverBadDataTest()
        {
            var controller = new DriversController(TestDBContextCreator.CreateTestContext());
            var mockData = new DriverLookupModel
            {
                FirstName = "Bad",
                LastName = "Data",
                LicensePlate = "ABC123",
                SSN = "123-45-6789"
            };

            var data = controller.GetDriver(mockData).Result;

            Assert.IsInstanceOfType(data, typeof(NotFoundResult));
        }

        [TestMethod()]
        public void AddDriverWithDuplicateKeyTest()
        {
            var controller = new DriversController(TestDBContextCreator.CreateTestContext());
            var mockData = new NewDriver
            {
                DriverLicenseNumber = "M112233445566",
                FirstName = "John",
                LastName = "Doe",
                SocialSecurity = "123-45-6789",
                DateOfBirth = DateTime.Parse("1996-05-25")
            };

            var result = controller.AddNewDriver(mockData).Result;

            Assert.IsInstanceOfType(result, typeof(BadRequestResult));
        }
    }
}