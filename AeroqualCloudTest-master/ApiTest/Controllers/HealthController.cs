using Microsoft.AspNetCore.Mvc;

namespace ApiTest.Controllers
{
    public class HealthController : ControllerBase
    {
        [Route("health")]
        [HttpGet]
        public ActionResult<string> HealthCheck()
        {
            return Ok("api is working");
        }
    }
}