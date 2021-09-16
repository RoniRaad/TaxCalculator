﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace TaxCalculator.Application.Models
{
    public class OrderTaxApiRequest
    {
        [JsonPropertyName("from_country")]
        public string FromCountry { get; set; }

        [JsonPropertyName("from_zip")]
        public string FromZipCode { get; set; }

        [JsonPropertyName("from_state")]
        public string FromState { get; set; }

        [JsonPropertyName("from_city")]
        public string FromCity { get; set; }

        [JsonPropertyName("from_street")]
        public string FromStreet { get; set; }

        [JsonPropertyName("to_zip")]
        public string ToZipCode { get; set; }

        [JsonPropertyName("to_state")]
        public string ToState { get; set; }

        [JsonPropertyName("to_city")]
        public string ToCity { get; set; }

        [JsonPropertyName("from_street")]
        public string ToStreet { get; set; }

        [JsonPropertyName("amount")]
        public float Amount { get; set; }

        [JsonPropertyName("shipping")]
        public float Shipping { get; set; }

        [JsonPropertyName("customer_id")]
        public float CustomerId { get; set; }

        [JsonPropertyName("nexus_addresses")]
        public NexusAddress[] NexusAddresses { get; set; }

        [JsonPropertyName("line_items")]
        public LineItem[] LineItems { get; set; }

    }
}
