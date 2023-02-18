using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Runtime.CompilerServices;
using AzureFunctions.Autofac;
using Microsoft.Azure.WebJobs.Host;
using System.Diagnostics;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Http;
using System.Net.Http;
using System.Net;
using System.Net.Mime;

namespace HelloWorldFunction
{
    [DependencyInjectionConfig(typeof(AutofacConfig))]
    public static class HelloWorld
    {
        [FunctionName("HelloWorld")]
        public static async Task<IActionResult> GetHelloWorldMessage([HttpTrigger(AuthorizationLevel.Function, "get", Route = null)]HttpRequestMessage req , TraceWriter log, [Inject]IMessage message = null)
        {
            log.Info("C# HTTP trigger function processed a request.");

            string responseMessage = string.IsNullOrEmpty(message.Message())? "Hello world message is empty!":$"{message.Message()}";
            
            return new OkObjectResult(responseMessage);
            
        }


    }

    
}