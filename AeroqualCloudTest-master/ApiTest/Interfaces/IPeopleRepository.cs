using System.Threading.Tasks;
using ApiTest.Models;

namespace ApiTest.Interfaces
{
    public interface IPeopleRepository
    {
        /// <summary>
        /// Get all the people from files
        /// </summary>
        /// <returns></returns>
        Task<People> GetPeople();

        /// <summary>
        ///  Adding a new person to the file
        /// </summary>
        /// <param name="person"></param>
        /// <returns></returns>
        Task CreatePerson(Person person);
    }
}