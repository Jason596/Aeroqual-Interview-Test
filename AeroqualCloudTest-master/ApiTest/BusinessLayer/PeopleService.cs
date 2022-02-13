using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ApiTest.Helper;
using ApiTest.Interfaces;
using ApiTest.Models;
using Microsoft.Extensions.Logging;


namespace ApiTest.BusinessLayer
{
    public class PeopleService : IPeopleService
    {
        private readonly IPeopleRepository _peopleRepository;
        private readonly ILogger _logger;


        public PeopleService(IPeopleRepository peopleRepository,
            ILogger<PeopleService> logger)
        {
            _peopleRepository = peopleRepository;
            _logger = logger;
        }


        public async Task<People> GetPeople()
        {
            var loggerPrefix = Logging.CreateLoggingPrefix(':', nameof(PeopleService), nameof(GetPeople));
            _logger.LogInformation($"{loggerPrefix} method called");

            return await _peopleRepository.GetPeople();
        }


        public async Task<List<Person>> SearchByPersonName(string personName)
        {
            var loggerPrefix = Logging.CreateLoggingPrefix(':', nameof(PeopleService), nameof(SearchByPersonName));
            _logger.LogInformation($"{loggerPrefix} method called");

            if (string.IsNullOrWhiteSpace(personName))
            {
                throw new Exception("Wrong person name.");
            }

            return await _peopleRepository.SearchByPersonName(personName);
        }


        public async Task CreatePerson(Person person)
        {
            var loggerPrefix = Logging.CreateLoggingPrefix(':', nameof(PeopleService), nameof(CreatePerson));
            _logger.LogInformation($"{loggerPrefix} method called");

            await _peopleRepository.CreatePerson(person);
        }


        public async Task UpdatePerson(Person person)
        {
            var loggerPrefix = Logging.CreateLoggingPrefix(':', nameof(PeopleService), nameof(UpdatePerson));
            _logger.LogInformation($"{loggerPrefix} method called");

            await _peopleRepository.UpdatePerson(person);
        }


        public async Task DeletePersonById(string personId)
        {
            var loggerPrefix = Logging.CreateLoggingPrefix(':', nameof(PeopleService), nameof(DeletePersonById));
            _logger.LogInformation($"{loggerPrefix} method called");

            if (int.TryParse(personId, out var personIdNumber))
            {
                await _peopleRepository.DeletePersonById(personIdNumber);
            }

            throw new Exception("Please enter correct person id.");
        }
    }
}