using Microsoft.VisualStudio.TestTools.UnitTesting;
using Kaufmann_Final.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kaufmann_Final.Controllers.Tests
{
    [TestClass()]
    public class ProblemControllerTests
    {
        private readonly List<KeyValuePair<string, string>> _testKeyValues = new()
        {
            new KeyValuePair<string, string>("doge", "coin"),
            new KeyValuePair<string, string>("abc", "def"),
            new KeyValuePair<string, string>("12k", "qrs"),
            new KeyValuePair<string, string>("doge", "coin"),
            new KeyValuePair<string, string>("abc", "def"),
            new KeyValuePair<string, string>("farmnadc", "qrescs"),
            new KeyValuePair<string, string>("abc", "def")
        };

        [TestMethod()]
        public void TwoDuplicateKeysTest()
        {
            var controller = new ProblemController();

            var dictionaries = controller.AddToDictionaries(_testKeyValues);

            string expected = "2";
            string result = dictionaries[1]["doge"];

            Assert.AreEqual(expected, result);
        }

        [TestMethod()]
        public void ThreeDuplicateKeysTest()
        {
            var controller = new ProblemController();

            var dictionaries = controller.AddToDictionaries(_testKeyValues);

            string expected = "3";
            string result = dictionaries[1]["abc"];

            Assert.AreEqual(expected, result);
        }
    }
}