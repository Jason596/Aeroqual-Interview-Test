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
    }
}