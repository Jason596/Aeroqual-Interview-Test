using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ApiTest.Models
{
    public class Person
    {
        [Required]
        [JsonPropertyName("Id")]
        public int? Id { get; set; }

        [Required]
        [JsonPropertyName("Name")]
        public string Name { get; set; }

        [Required]
        [JsonPropertyName("Age")]
        public int? Age { get; set; }
    }
}