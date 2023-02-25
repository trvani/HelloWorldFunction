
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;
using HelloWorldFunction;
using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities;
using Microsoft.AspNetCore.Mvc;
using System.Web.Http.Results;
using Microsoft.Extensions.Configuration;

namespace HelloWorldFunctionTest
{
    [TestClass]
    public class HelloWorldTests
    {


        [TestMethod]
        public async Task ShouldGetHelloWorldMessage()
        {
            var req = TestHelpers.CreateGetReq();
            var log = new TracerWriterStub(System.Diagnostics.TraceLevel.Info);

            ActionResult response = (ActionResult)await HelloWorld.GetHelloWorldMessage(req, log,new HwMessage());
            var okResult = response as OkObjectResult;

            Assert.AreEqual("Hello World", okResult.Value);
        }

        //// Actually I could not find any fail test because there was no input. Which is why I removed it. 

        //[TestMethod]
        //public async Task ShouldFailBecauseOfDependencyClassError()
        //{
        //    try
        //    {
        //        var req = TestHelpers.CreateGetReq();
        //        var log = new TracerWriterStub(System.Diagnostics.TraceLevel.Info);

        //        ActionResult response = (ActionResult)await HelloWorld.GetHelloWorldMessage(req, log, null);
        //        var okResult = response as OkObjectResult;

        //        Assert.AreNotEqual("Hello World", okResult.Value);
        //    }
        //    catch (Exception)
        //    {
        //        Assert.Fail();
        //    }
            
        //}
    }
}