using System.Text.Json.Serialization;

namespace PostureWebSite.Models.Response
{
    public class DataSugerencias
    {
            [JsonPropertyName("Observaciones")]
            public string Observaciones { get; set; }

            [JsonPropertyName("Sugerencias")]
            public List<string> Sugerencias { get; set; }

    }
}
