using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace ApiTest.Models
{
    public class People
    {
        [JsonPropertyName("People")]
        public List<Person> ListOfPeoplePersons { get; set; }
    }
}