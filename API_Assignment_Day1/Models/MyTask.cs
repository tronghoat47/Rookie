using System.Text.Json.Serialization;

namespace API_Assignment_Day1.Models
{
    public class MyTask
    {
        public Guid Id { get; set; }
        [JsonPropertyName("Description")]
        [JsonPropertyOrder(2)]
        public string Title { get; set; }
        [JsonPropertyName("Success")]
        [JsonPropertyOrder(1)]
        public bool IsCompleted { get; set; } 
    }
}
