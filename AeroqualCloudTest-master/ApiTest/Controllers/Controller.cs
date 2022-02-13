using System.Collections;
using Microsoft.AspNetCore.Mvc;

namespace ApiTest.Controllers
{
    [ApiController]
    [Route("[people]")]
    public class Controller : ControllerBase
    {

        [HttpGet]
        public void GetPeople()
        {

        }

    }
}