using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace TaxCalculator.Application.Models.ApiResponses
{
    public class OrderTaxApiResponse
    {
        [JsonPropertyName("tax")]
        public Tax Tax { get; set; }

        [JsonPropertyName("breakdown")]
        public Breakdown Breakdown { get; set; }
    }
}
