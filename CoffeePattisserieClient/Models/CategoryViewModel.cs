using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace CoffeePattisserieClient.Models
{
    public class CategoryViewModel
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        // Yeni Özellikler
        [JsonPropertyName("imageUrl")]
        public string ImageUrl { get; set; }

        [JsonPropertyName("description")]
        public string Description { get; set; }

        [JsonPropertyName("countOfProducts")]
        public int CountOfProducts { get; set; }
    }
}
