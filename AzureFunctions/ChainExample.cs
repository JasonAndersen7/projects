using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.DurableTask;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;

namespace AzureFunctions
{
    public static class ChainExample
    {
        [FunctionName("ChainExample")]
        public static async Task<List<string>> RunOrchestrator(
            [OrchestrationTrigger] IDurableOrchestrationContext context)
        {
            var outputs = new List<string>();
            var numbers = new AddNumbers()
            {
                number2 = 10,
                number1 = 20
            };

            // Replace "hello" with the name of your Durable Activity Function.
            outputs.Add(await context.CallActivityAsync<string>("ChainExample_Hello", "Tokyo"));
            outputs.Add(await context.CallActivityAsync<string>("ChainExample_Hello", "Seattle"));
            outputs.Add(await context.CallActivityAsync<string>("ChainExample_Hello", "London"));
           
            
            outputs.Add(await context.CallActivityAsync<string>("ChainExample_AddNumber", numbers));

            // returns ["Hello Tokyo!", "Hello Seattle!", "Hello London!"]
            return outputs;
        }

        [FunctionName("ChainExample_Hello")]
        public static string SayHello([ActivityTrigger] string name, ILogger log)
        {
            log.LogInformation($"Saying hello to {name}.");
            return $"Hello {name}!";
        }

        [FunctionName("ChainExample_AddNumber")]
        public static string AddNumber([ActivityTrigger] AddNumbers number, ILogger log)
        {
            log.LogInformation($"Adding number to {number.number1} and {number.number2}.");

            return $"Sum  {number.number1+number.number2}!";
        }

        [FunctionName("ChainExample_HttpStart")]
        public static async Task<HttpResponseMessage> HttpStart(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post")] HttpRequestMessage req,
            [DurableClient] IDurableOrchestrationClient starter,
            ILogger log)
        {
            // Function input comes from the request content.
           string instanceId = await starter.StartNewAsync("ChainExample", null);

            log.LogInformation($"Started orchestration with ID = '{instanceId}'.");

            var result = HttpCall(req, log);
            return starter.CreateCheckStatusResponse(req, instanceId);
          //return new HttpResponseMessage(HttpStatusCode.Accepted);
        }

        [FunctionName("CallAnotherTrigger")]
        public static async Task<HttpResponseMessage> HttpCall(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post")] HttpRequestMessage req,
            ILogger log)
        {
            // Function input comes from the request content.

            log.LogInformation($"Started another HTTP Call");

            //  return starter.CreateCheckStatusResponse(req, instanceId);
            return new HttpResponseMessage(HttpStatusCode.Created);
        }

    }

    public class AddNumbers
    {
        public int number1;
        public int number2;

    }

}