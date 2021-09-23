using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace TaxCalculator.Core.Requests
{
    public class TaxRatesForLocationRequest
    { 
        [JsonPropertyName("country")]
        public string Country { get; set; }

        [JsonPropertyName("zip")]
        public string ZipCode { get; set; }

        [JsonPropertyName("state")]
        public string State { get; set; }

        [JsonPropertyName("city")]
        public string City { get; set; }

        [JsonPropertyName("street")]
        public string Street { get; set; }
    }
}
