using System.Collections.Generic;
using System.Threading.Tasks;
using ApiTest.Helper;
using ApiTest.Interfaces;
using ApiTest.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ApiTest.PeopleController
{
    [ApiController]
    [Route("people")]
    public class PeopleController : ControllerBase
    {
        private readonly IPeopleService _peopleService;
        private readonly ILogger _logger;


        public PeopleController(IPeopleService peopleService, ILogger<PeopleController> logger)
        {
            _peopleService = peopleService;
            _logger = logger;
        }

        [HttpGet]
        public async Task<People> GetPeople()
        {
            var loggerPrefix = Logging.CreateLoggingPrefix(':', nameof(PeopleController), nameof(GetPeople));
            _logger.LogInformation($"{loggerPrefix} method called");

            return await _peopleService.GetPeople();
        }

        [HttpGet]
        [Route("~/person")]
        public async Task<List<Person>> SearchByPersonName([FromQuery(Name = "personName")] string personName)
        {
            var loggerPrefix = Logging.CreateLoggingPrefix(':', nameof(PeopleController), nameof(SearchByPersonName));
            _logger.LogInformation($"{loggerPrefix} method called");

            return await _peopleService.SearchByPersonName(personName);
        }

        [HttpPost]
        public async Task<IActionResult> CreatePerson(Person person)
        {
            var loggerPrefix = Logging.CreateLoggingPrefix(':', nameof(PeopleController), nameof(CreatePerson));
            _logger.LogInformation($"{loggerPrefix} method called");

            await _peopleService.CreatePerson(person);
            return StatusCode(201);
        }


        [HttpPut]
        public async Task<IActionResult> UpdatePerson(Person person)
        {
            var loggerPrefix = Logging.CreateLoggingPrefix(':', nameof(PeopleController), nameof(UpdatePerson));
            _logger.LogInformation($"{loggerPrefix} method called");

            await _peopleService.UpdatePerson(person);
            return StatusCode(204);
        }


        [HttpDelete]
        [Route("{personId}")]
        public async Task<IActionResult> DeletePersonById(string personId)
        {
            var loggerPrefix = Logging.CreateLoggingPrefix(':', nameof(PeopleController), nameof(DeletePersonById));
            _logger.LogInformation($"{loggerPrefix} method called");

            await _peopleService.DeletePersonById(personId);
            return StatusCode(204);
        }
    }
}