using System;
using System.IO;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using ApiTest.Interfaces;
using ApiTest.Models;

namespace ApiTest.DataAccessLayer
{
    public class PeopleRepository : IPeopleRepository
    {
        public async Task<People> GetPeople()
        {
            var results = await File.ReadAllTextAsync("./Resources/data.json");
            var resultsOfJson = JsonSerializer.Deserialize<People>(results);

            return resultsOfJson;
        }


        public async Task CreatePerson(Person person)
        {
            var currentContent = await GetPeople();
            var existingPerson = currentContent.ListOfPeoplePersons
                .Where(item => item.Id == person.Id &&
                                item.Name == person.Name &&
                                item.Age == person.Age);

            if (!existingPerson.Any())
            {
                currentContent.ListOfPeoplePersons.Add(person);
                var personStringValue = JsonSerializer.Serialize(currentContent);
                await File.WriteAllTextAsync("./Resources/data.json", personStringValue);
            }
        }


        public Task UpdatePerson(Person person)
        {
            throw new System.NotImplementedException();
        }


        public async Task DeletePerson(string personId)
        {
            var currentContent = await GetPeople();
            var existingPerson = currentContent.ListOfPeoplePersons.First(item => item.Id == Convert.ToInt32(personId));

            if (existingPerson != null)
            {
                currentContent.ListOfPeoplePersons.RemoveAll(item => item.Id == Convert.ToInt32(personId));
                var personStringValue = JsonSerializer.Serialize(currentContent);
                await File.WriteAllTextAsync("./Resources/data.json", personStringValue);
            }
        }
    }
}