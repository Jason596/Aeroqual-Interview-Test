using System.Security.Cryptography.X509Certificates;
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


        public async Task CreatePerson(Person person)
        {
            await _peopleRepository.CreatePerson(person);
        }
    }
}