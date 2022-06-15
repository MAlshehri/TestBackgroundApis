using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace TestBackgroundApis.Models
{
    public class Fake
    {
        [Key]
        public long Id { get; set; }
        
        [JsonProperty("id")]
        public int ModelId { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("creationDate")]
        public DateTime CreationDate { get; set; }

        [JsonProperty("label")]
        public string Label { get; set; }

        [JsonProperty("isFriendly")]
        public bool IsFriendly { get; set; }

        [JsonProperty("weatherType")]
        public string WeatherType { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }
        [Timestamp]
        public byte[] Timestamp { get; set; }
    }
}
