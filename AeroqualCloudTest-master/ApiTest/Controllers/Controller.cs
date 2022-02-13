using System.Collections.Generic;
using System.Threading.Tasks;
using ApiTest.Interfaces;
using ApiTest.Models;
using Microsoft.AspNetCore.Mvc;

namespace ApiTest.Controllers
{
    [ApiController]
    [Route("people")]
    public class Controller : ControllerBase
    {
        private readonly IPeopleService _peopleService;


        public Controller(IPeopleService peopleService)
        {
            _peopleService = peopleService;
        }


        [HttpGet]
        public async Task<People> GetPeople()
        {
            return await _peopleService.GetPeople();
        }


        [HttpPost]
        public async Task<IActionResult> CreatePerson(Person person)
        {
            await _peopleService.CreatePerson(person);
            return StatusCode(204);
        }

    }
}