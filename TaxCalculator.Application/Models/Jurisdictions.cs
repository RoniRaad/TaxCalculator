using System.Text.Json.Serialization;

namespace TaxCalculator.Core.Models
{
    public class Jurisdictions
    {
        [JsonPropertyName("country")]
        public string Country { get; set; }

        [JsonPropertyName("state")]
        public string State { get; set; }

        [JsonPropertyName("County")]
        public string County { get; set; }

        [JsonPropertyName("city")]
        public string City { get; set; }
    }
}