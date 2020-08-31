using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Sample.HelloWorld.Business.Interfaces; 

namespace Sample.HelloWorld.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HelloWorldController : ControllerBase
    {      
        private readonly ILogger<HelloWorldController> _logger;
        private readonly IHelloWorldService _helloWorldService; 

        public HelloWorldController(ILogger<HelloWorldController> logger, IHelloWorldService helloWorldService)
        {
            _logger = logger;
            _helloWorldService = helloWorldService; 
        }

        /// <summary>
        /// Returns a message from the hellow world service
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        [HttpPost]     
        [Route("say-hello")]
        [Consumes("application/json")]
        public async Task<IActionResult> Write(string message)
        {
            var result = await _helloWorldService.WriteMessage(message);
            return Ok(result); 
        }
        
    }
}
