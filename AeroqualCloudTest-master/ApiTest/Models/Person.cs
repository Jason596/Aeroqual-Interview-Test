using System.Text.Json.Serialization;

namespace ApiTest.Models
{
    public class Person
    {
        [JsonPropertyName("Id")]
        public int Id { get; set; }

        [JsonPropertyName("Name")]
        public string Name { get; set; }

        [JsonPropertyName("Age")]
        public int Age { get; set; }
    }
}