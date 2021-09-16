using TaxCalculator.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace TaxCalculator.Application.Models.ApiResponses
{
    public class TaxRatesForLocationResponse
    { 
        [JsonPropertyName("rate")]
        public TaxRate TaxRate { get; set; }
    }
}
