using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using UserFunction.Domain;
using UserFunction.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections;

namespace UserFunction.Functions
{
    public static class ProfileFunctions
    {
        [FunctionName("GetProfile")]
        public static IActionResult GetProfile(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "users/{userId}/profile")] HttpRequest req,
            string userId,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");

            IProfileService service = DIContainer.Instance.GetService<IProfileService>();

            var envs = Environment.GetEnvironmentVariables();
            foreach (DictionaryEntry item in envs)
            {
                log.LogInformation($"{item.Key}: {item.Value}");
            }

            userId += Environment.GetEnvironmentVariable("CacheExpired");

            var result = service.GetProfile(userId);

            return new OkObjectResult(result);
        }
    }
}
