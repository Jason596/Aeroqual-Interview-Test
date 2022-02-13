using System.IO;
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
    }
}