using Microsoft.VisualStudio.TestTools.UnitTesting;
using Kaufmann_Final.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Kaufmann_FinalTests;
using Kaufmann_Final.Models;

namespace Kaufmann_Final.Controllers.Tests
{
    [TestClass()]
    public class DriversControllerTests
    {
        [TestMethod()]
        public void GetDriverGoodDataTest()
        {
            var controller = new DriversController(TestDBContextCreator.CreateTestContext());
            var mockData = new DriverNameDto
            {
                FirstName = "John",
                LastName = "Doe",
            };

            var data = controller.GetDriverByNameAsync(mockData).Result;

            Assert.IsInstanceOfType(data, typeof(OkObjectResult));
        }

        [TestMethod()]
        public void GetDriverBadDataTest()
        {
            var controller = new DriversController(TestDBContextCreator.CreateTestContext());
            var mockData = new DriverNameDto
            {
                FirstName = "Bad",
                LastName = "Data",
            };

            var data = controller.GetDriverByNameAsunc(mockData).Result;

            Assert.IsInstanceOfType(data, typeof(NotFoundResult));
        }

        [TestMethod()]
        public void AddDriverWithDuplicateKeyTest()
        {
            var controller = new DriversController(TestDBContextCreator.CreateTestContext());
            var mockData = new DriverDto
            {
                DriverLicenseNumber = "M112233445566",
                FirstName = "John",
                LastName = "Doe",
                SocialSecurity = "123-45-6789",
                DateOfBirth = DateTime.Parse("1996-05-25")
            };

            var result = controller.AddNewDriverAsync(mockData).Result;

            Assert.IsInstanceOfType(result, typeof(BadRequestResult));
        }
    }
}