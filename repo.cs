using System;
using System.Text.Json.Serialization;

namespace WebAPIClient
{
    public class Repository
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }
        
    }
}