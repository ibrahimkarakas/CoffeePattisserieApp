using System;
using System.Text.Json.Serialization;

namespace CoffeePattisserieClient.Models
{
    public class CartItemViewModel
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("createdDate")]
        public DateTime CreatedDate { get; set; }

        [JsonPropertyName("productId")]
        public int ProductId { get; set; }

        [JsonPropertyName("product")]
        public ProductViewModel Product { get; set; } // ProductViewModel: Coffee, Moctail veya Pattisserie olabilir

        [JsonPropertyName("quantity")]
        public int Quantity { get; set; }
    }
}
