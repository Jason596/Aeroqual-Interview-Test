using System.Collections.Generic;
using System.Threading.Tasks;
using ApiTest.Interfaces;
using ApiTest.Models;

namespace ApiTest.BusinessLayer
{
    public class PeopleService : IPeopleService
    {
        private readonly IPeopleRepository _peopleRepository;

        public PeopleService(IPeopleRepository peopleRepository)
        {
            _peopleRepository = peopleRepository;
        }


        public async Task<People> GetPeople()
        {
            return await _peopleRepository.GetPeople();
        }


        public async Task<List<Person>> SearchByPersonName(string personName)
        {
            return await _peopleRepository.SearchByPersonName(personName);
        }


        public async Task CreatePerson(Person person)
        {
            await _peopleRepository.CreatePerson(person);
        }


        public async Task UpdatePerson(Person person)
        {
            await _peopleRepository.UpdatePerson(person);
        }


        public async Task DeletePerson(string personId)
        {
            await _peopleRepository.DeletePerson(personId);
        }
    }
}