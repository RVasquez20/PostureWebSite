﻿using System.Text.Json.Serialization;

namespace PostureWebSite.Models.Response
{
    public class Usage
    {
        [JsonPropertyName("prompt_tokens")]
        public int prompt_tokens { get; set; }

        [JsonPropertyName("completion_tokens")]
        public int completion_tokens { get; set; }

        [JsonPropertyName("total_tokens")]
        public int total_tokens { get; set; }
    }


    public class IAResponse
    {
        [JsonPropertyName("id")]
        public string id { get; set; }

        [JsonPropertyName("object")]
        public string @object { get; set; }

        [JsonPropertyName("created")]
        public int created { get; set; }

        [JsonPropertyName("model")]
        public string model { get; set; }

        [JsonPropertyName("choices")]
        public List<Choice> choices { get; set; }

        [JsonPropertyName("usage")]
        public Usage usage { get; set; }
    }
    // Root myDeserializedClass = JsonSerializer.Deserialize<Root>(myJsonResponse);
    public class Choice
    {
        [JsonPropertyName("index")]
        public int index { get; set; }

        [JsonPropertyName("message")]
        public Message message { get; set; }

        [JsonPropertyName("finish_reason")]
        public string finish_reason { get; set; }
    }

    public class Message
    {
        [JsonPropertyName("role")]
        public string role { get; set; }

        [JsonPropertyName("content")]
        public string content { get; set; }
    }

}
