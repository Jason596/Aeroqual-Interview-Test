using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
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


        public async Task<List<Person>> SearchByPersonName(string personName)
        {
            var currentContent = await GetPeople();
            var existingPerson = currentContent.ListOfPeoplePersons.Where(item =>
                string.Equals(item.Name, personName, StringComparison.CurrentCultureIgnoreCase) || item.Name.ToLower()
                .Contains(personName.ToLower())).ToList();
            return existingPerson;
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


        public async Task UpdatePerson(Person person)
        {
            var currentContent = await GetPeople();
            var existingPerson = currentContent.ListOfPeoplePersons
                .Where(item => item.Id == person.Id);

            foreach (var item in existingPerson)
            {
                item.Name = person.Name;
                item.Age = person.Age;
            }

            var personStringValue = JsonSerializer.Serialize(currentContent);
            await File.WriteAllTextAsync("./Resources/data.json", personStringValue);
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