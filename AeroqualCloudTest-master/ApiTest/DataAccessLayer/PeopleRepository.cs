using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using ApiTest.Helper;
using ApiTest.Interfaces;
using ApiTest.Models;
using Microsoft.Extensions.Logging;

namespace ApiTest.DataAccessLayer
{
    public class PeopleRepository : IPeopleRepository
    {
        private readonly ILogger _logger;


        public PeopleRepository(ILogger<PeopleRepository> logger)
        {
            _logger = logger;
        }


        public async Task<People> GetPeople()
        {
            var loggerPrefix = Logging.CreateLoggingPrefix(':', nameof(PeopleRepository), nameof(GetPeople));
            _logger.LogInformation($"{loggerPrefix} method called");

            try
            {
                var currentContents = await File.ReadAllTextAsync("./Resources/data.json");

                if (string.IsNullOrWhiteSpace(currentContents))
                {
                    return new People()
                    {
                        ListOfPeoplePersons = new List<Person>()
                    };
                }

                var resultsOfJson = JsonSerializer.Deserialize<People>(currentContents);
                return resultsOfJson;
            }
            catch (Exception err)
            {
                _logger.LogError($"{loggerPrefix} - {err.Message}");
                throw;
            }
        }


        public async Task<List<Person>> SearchByPersonName(string personName)
        {
            var loggerPrefix = Logging.CreateLoggingPrefix(':', nameof(PeopleRepository), nameof(SearchByPersonName));
            _logger.LogInformation($"{loggerPrefix} method called");

            var currentContent = await GetPeople();
            var existingPerson = currentContent.ListOfPeoplePersons.Where(
                item => string.Equals(item.Name, personName, StringComparison.CurrentCultureIgnoreCase) ||
                        item.Name.ToLower().Contains(personName.ToLower())).ToList();

            return existingPerson;
        }


        public async Task CreatePerson(Person person)
        {
            var loggerPrefix = Logging.CreateLoggingPrefix(':', nameof(PeopleRepository), nameof(CreatePerson));
            _logger.LogInformation($"{loggerPrefix} method called");

            var currentContent = await GetPeople();
            var isPersonExists = currentContent.ListOfPeoplePersons
                .Where(item => item.Id == person.Id &&
                               string.Equals(item.Name, person.Name, StringComparison.CurrentCultureIgnoreCase) &&
                               item.Age == person.Age);

            if (!isPersonExists.Any())
            {
                currentContent.ListOfPeoplePersons.Add(person);
                var newContent = JsonSerializer.Serialize(currentContent);
                await File.WriteAllTextAsync("./Resources/data.json", newContent);
            }
        }


        public async Task UpdatePerson(Person person)
        {
            var loggerPrefix = Logging.CreateLoggingPrefix(':', nameof(PeopleRepository), nameof(UpdatePerson));
            _logger.LogInformation($"{loggerPrefix} method called");

            var currentContent = await GetPeople();
            var isPersonExists = currentContent.ListOfPeoplePersons
                .Where(item => item.Id == person.Id)
                .ToList();

            if (!isPersonExists.Any()) return;

            foreach (var item in isPersonExists)
            {
                item.Name = person.Name;
                item.Age = person.Age;
            }

            var newContent = JsonSerializer.Serialize(currentContent);
            await File.WriteAllTextAsync("./Resources/data.json", newContent);
        }


        public async Task DeletePersonById(int personId)
        {
            var loggerPrefix = Logging.CreateLoggingPrefix(':', nameof(PeopleRepository), nameof(DeletePersonById));
            _logger.LogInformation($"{loggerPrefix} method called");

            var currentContent = await GetPeople();
            var isPersonExists = currentContent.ListOfPeoplePersons.FirstOrDefault(item => item.Id == personId);

            if (isPersonExists != null)
            {
                currentContent.ListOfPeoplePersons.RemoveAll(item => item.Id == personId);
                var newContent = JsonSerializer.Serialize(currentContent);
                await File.WriteAllTextAsync("./Resources/data.json", newContent);
            }
        }
    }
}