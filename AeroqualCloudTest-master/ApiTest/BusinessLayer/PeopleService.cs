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


        public Task<People> GetPeople()
        {
            return _peopleRepository.GetPeople();
        }


        public Task CreatePerson(Person person)
        {
            return _peopleRepository.CreatePerson(person);
        }
    }
}