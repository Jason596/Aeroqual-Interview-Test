using Microsoft.AspNetCore.Mvc;

namespace ApiTest.Controllers
{
    public class HealthController : ControllerBase
    {
        /// <summary>
        /// Health Controller for checking the api running status
        /// </summary>
        /// <returns></returns>
        [Route("health")]
        [HttpGet]
        public ActionResult<string> HealthCheck()
        {
            return Ok("api is working");
        }
    }
}