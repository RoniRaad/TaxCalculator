using TaxCalculator.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using TaxCalculator.Core.Models;

namespace TaxCalculator.Core.Responses
{
    public class TaxRatesForLocationResponse
    { 
        [JsonPropertyName("rate")]
        public TaxRate TaxRate { get; set; }
    }
}
