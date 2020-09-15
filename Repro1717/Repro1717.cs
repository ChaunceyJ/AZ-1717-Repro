
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Microsoft.Data.SqlClient;

namespace Repro1717
{
    public static class Repro1717
    {
        [FunctionName("Repro1717")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = null)] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");


            var conn = new SqlConnection("<YOUR CONNECTION STRING GOES HERE>");


            string cmdString = "SELECT TOP (1) [ID] ,[NAME] FROM[dbo].[MyTable]";

            var cmd = new SqlCommand(cmdString, conn);

            cmd.Connection.Open();
            var sqlReader = cmd.ExecuteReader();


            string result = string.Empty;
            while(sqlReader.Read())
            {
                result += sqlReader[0] + " - " + sqlReader[1];
            }

            return new OkObjectResult(result);
        }
    }
}
