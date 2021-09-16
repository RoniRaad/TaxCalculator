using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace TaxCalculator.Application.Models
{
    public class Tax
    {
        [JsonPropertyName("order_total_amount")]
        public string OrderTotalAmount { get; set; }

        [JsonPropertyName("shipping")]
        public string Shipping { get; set; }

        [JsonPropertyName("taxable_amount")]
        public string TaxableAmount { get; set; }

        [JsonPropertyName("amount_to_collect")]
        public string AmountToCollect { get; set; }

        [JsonPropertyName("rate")]
        public string Rate { get; set; }

        [JsonPropertyName("has_nexus")]
        public bool HasNexus { get; set; }

        [JsonPropertyName("freight_taxable")]
        public bool FreightTaxable { get; set; }

        [JsonPropertyName("tax_source")]
        public string TaxSource { get; set; }

        [JsonPropertyName("exemption_type")]
        public string ExemptionType { get; set; }

        [JsonPropertyName("jurisdictions")]
        public Jurisdictions Jurisdictions { get; set; }

        [JsonPropertyName("breakdown")]
        public Breakdown Breakdown { get; set; }


    }
}
