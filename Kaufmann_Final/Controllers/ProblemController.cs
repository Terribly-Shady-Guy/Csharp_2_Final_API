using Microsoft.AspNetCore.Mvc;

namespace Kaufmann_Final.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProblemController : ControllerBase
    {
        [HttpPost] //solution to problem solving portion
        public List<Dictionary<string, string>> AddToDictionaries(List<KeyValuePair<string, string>> keyValuePairs)
        {
            var keyValues = new Dictionary<string, string>(keyValuePairs.Count);
            var keyCount = new Dictionary<string, string>(keyValuePairs.Count / 2);

            foreach (var keyValue in keyValuePairs)
            {
                if (!keyValues.ContainsKey(keyValue.Key))
                {
                    keyValues.Add(keyValue.Key, keyValue.Value);
                }
                else if (!keyCount.ContainsKey(keyValue.Key))
                {
                    keyCount.Add(keyValue.Key, "2");
                }
                else
                {
                    int count = int.Parse(keyCount[keyValue.Key]);
                    count++;
                    keyCount[keyValue.Key] = count.ToString();
                }
            }

            return new List<Dictionary<string, string>>
            {
                keyValues,
                keyCount
            };
        }
    }
}
