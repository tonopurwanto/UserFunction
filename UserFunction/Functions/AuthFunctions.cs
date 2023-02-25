using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserFunction.Domain;
using UserFunction.Services;

namespace UserFunction.Functions
{
    public static class AuthFunctions
    {
        [FunctionName("FbOauthCallback")]
        public static IActionResult GetProfile(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "oauth/fb/callback")] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");
            log.LogInformation($"QueryString: {req.QueryString}");
            log.LogInformation($"Code: {req.Query["code"]}");

            return new OkObjectResult("OK");
        }
    }
}
