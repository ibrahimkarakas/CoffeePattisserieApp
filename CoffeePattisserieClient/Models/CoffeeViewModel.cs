using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text.Json.Serialization;

namespace CoffeePattisserieClient.Models
{
    public class CoffeeViewModel
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("name")]
        [DisplayName("Kahve Adı")]
        public string Name { get; set; }

        [JsonPropertyName("originCountry")]
        [DisplayName("Menşei Ülke")]
        public string OriginCountry { get; set; }

        [JsonPropertyName("roastLevel")]
        [DisplayName("Kavurma Seviyesi")]
        public string RoastLevel { get; set; }

        [JsonPropertyName("flavorNotes")]
        [DisplayName("Lezzet Notları")]
        public string FlavorNotes { get; set; }

        [JsonPropertyName("caffeineContent")]
        [DisplayName("Kafein Miktarı")]
        public int CaffeineContent { get; set; }

        [JsonPropertyName("stockQuantity")]
        [DisplayName("Stok")]
        public int StockQuantity { get; set; }

        [JsonPropertyName("price")]
        [DisplayName("Fiyat")]
        public decimal Price { get; set; }

        [JsonPropertyName("imageUrl")]
        [DisplayName("Resim")]
        public string ImageUrl { get; set; }

        [JsonPropertyName("categories")]
        [DisplayName("Kategoriler")]
        public List<CategoryViewModel> Categories { get; set; }
    }
}
