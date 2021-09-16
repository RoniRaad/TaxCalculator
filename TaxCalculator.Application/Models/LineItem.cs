using System.Text.Json.Serialization;

namespace TaxCalculator.Application.Models
{
    public class LineItem
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("quantity")]
        public int Quantity { get; set; }

        [JsonPropertyName("product_tax_code")]
        public string ProductTaxCode { get; set; }

        [JsonPropertyName("unit_price")]
        public float UnitPrice { get; set; }

        [JsonPropertyName("discount")]
        public float Discount { get; set; }
    }
}