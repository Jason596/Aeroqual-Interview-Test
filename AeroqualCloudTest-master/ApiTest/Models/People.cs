using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ApiTest.Models
{
    public class People
    {
        [Required]
        [JsonPropertyName("People")]
        public List<Person> ListOfPeoplePersons { get; set; }
    }
}