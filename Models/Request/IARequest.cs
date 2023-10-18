using System.Text.Json.Serialization;

namespace PostureWebSite.Models.Request
{
    
        // Root myDeserializedClass = JsonSerializer.Deserialize<Root>(myJsonResponse);
        public class Messages
        {
            [JsonPropertyName("role")]
            public string role { get; set; }

            [JsonPropertyName("content")]
            public string content { get; set; }
        }

        public class IARequest
        {
        [JsonPropertyName("model")]
            public string model { get; set; }

            [JsonPropertyName("messages")]
            public List<Messages> messages { get; set; }
        }

}
