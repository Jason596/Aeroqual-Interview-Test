using System.Collections.Generic;
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
        ///  Get a person by name
        /// </summary>
        /// <param name="personName"></param>
        /// <returns></returns>
        Task<List<Person>> SearchByPersonName(string personName);

        /// <summary>
        ///  Adding a new person to the file
        /// </summary>
        /// <param name="person"></param>
        /// <returns></returns>
        Task CreatePerson(Person person);

        /// <summary>
        /// Update a person in the file
        /// </summary>
        /// <param name="person"></param>
        /// <returns></returns>
        Task UpdatePerson(Person person);

        /// <summary>
        /// Delete a person in the file
        /// </summary>
        /// <param name="person"></param>
        /// <returns></returns>
        Task DeletePerson(string personId);
    }
}