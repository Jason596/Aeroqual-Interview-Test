using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ApiTest.Helper;
using ApiTest.Interfaces;
using ApiTest.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ApiTest.Controllers
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
        public async Task<ActionResult<People>> GetPeople()
        {
            var loggerPrefix = Logging.CreateLoggingPrefix(':', nameof(PeopleController), nameof(GetPeople));
            _logger.LogInformation($"{loggerPrefix} method called");

            try
            {
                return await _peopleService.GetPeople();
            }
            catch (Exception err)
            {
                return StatusCode(400, new ErrorModel()
                {
                    StatusCode = StatusCodes.Status400BadRequest,
                    ErrorMessage = err.Message
                });
            }
        }


        [HttpGet]
        [Route("~/person")]
        public async Task<ActionResult<List<Person>>> SearchByPersonName([FromQuery(Name = "personName")] string personName)
        {
            var loggerPrefix = Logging.CreateLoggingPrefix(':', nameof(PeopleController), nameof(SearchByPersonName));
            _logger.LogInformation($"{loggerPrefix} method called");

            try
            {
                return await _peopleService.SearchByPersonName(personName);
            }
            catch (Exception err)
            {
                return StatusCode(400, new ErrorModel()
                {
                    StatusCode = StatusCodes.Status400BadRequest,
                    ErrorMessage = err.Message
                });
            }
        }


        [HttpPost]
        public async Task<IActionResult> CreatePerson(Person person)
        {
            var loggerPrefix = Logging.CreateLoggingPrefix(':', nameof(PeopleController), nameof(CreatePerson));
            _logger.LogInformation($"{loggerPrefix} method called");

            try
            {
                await _peopleService.CreatePerson(person);
                return StatusCode(201);
            }
            catch (Exception err)
            {
                return StatusCode(400, new ErrorModel()
                {
                    StatusCode = StatusCodes.Status400BadRequest,
                    ErrorMessage = err.Message
                });
            }
        }


        [HttpPut]
        public async Task<IActionResult> UpdatePerson(Person person)
        {
            var loggerPrefix = Logging.CreateLoggingPrefix(':', nameof(PeopleController), nameof(UpdatePerson));
            _logger.LogInformation($"{loggerPrefix} method called");

            try
            {
                await _peopleService.UpdatePerson(person);
                return StatusCode(204);

            }
            catch (Exception err)
            {
                return StatusCode(400, new ErrorModel()
                {
                    StatusCode = StatusCodes.Status400BadRequest,
                    ErrorMessage = err.Message
                });
            }
        }


        [HttpDelete]
        [Route("{personId}")]
        public async Task<IActionResult> DeletePersonById(string personId)
        {
            var loggerPrefix = Logging.CreateLoggingPrefix(':', nameof(PeopleController), nameof(DeletePersonById));
            _logger.LogInformation($"{loggerPrefix} method called");

            try
            {
                await _peopleService.DeletePersonById(personId);
                return StatusCode(204);
            }
            catch (Exception err)
            {
                return StatusCode(400, new ErrorModel()
                {
                    StatusCode = StatusCodes.Status400BadRequest,
                    ErrorMessage = err.Message
                });
            }
        }
    }
}