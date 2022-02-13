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
    /// <summary>
    /// People controllers, allow user to create, update, delete and get people.
    /// As well as search a person by name.
    /// </summary>
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


        /// <summary>
        /// Get all the people.
        /// </summary>
        /// <returns></returns>
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

        /// <summary>
        /// Search a person by name.
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("~/person")]
        public async Task<ActionResult<List<Person>>> SearchByPersonName([FromQuery(Name = "name")] string personName)
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


        /// <summary>
        /// Adding a new person.
        /// </summary>
        /// <param name="person"></param>
        /// <returns></returns>
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


        /// <summary>
        /// Update a person information.
        /// </summary>
        /// <param name="person"></param>
        /// <returns></returns>
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


        /// <summary>
        /// Delete a person by id.
        /// </summary>
        /// <param name="personId"></param>
        /// <returns></returns>
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