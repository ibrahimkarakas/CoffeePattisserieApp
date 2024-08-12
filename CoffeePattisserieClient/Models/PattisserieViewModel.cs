using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text.Json.Serialization;

namespace CoffeePattisserieClient.Models
{
    public class PattisserieViewModel
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("name")]
        [DisplayName("Pastane Ürünü Adı")]
        public string Name { get; set; }

        [JsonPropertyName("description")]
        [DisplayName("Açıklama")]
        public string Description { get; set; }

        [JsonPropertyName("price")]
        [DisplayName("Fiyat")]
        public decimal Price { get; set; }

        [JsonPropertyName("stockQuantity")]
        [DisplayName("Stok")]
        public int StockQuantity { get; set; }

        [JsonPropertyName("ingredients")]
        [DisplayName("İçindekiler")]
        public string Ingredients { get; set; }

        [JsonPropertyName("allergens")]
        [DisplayName("Alerjenler")]
        public string Allergens { get; set; }

        [JsonPropertyName("shelfLife")]
        [DisplayName("Raf Ömrü")]
        public string ShelfLife { get; set; }

        [JsonPropertyName("imageUrl")]
        [DisplayName("Resim")]
        public string ImageUrl { get; set; }

        [JsonPropertyName("categories")]
        [DisplayName("Kategoriler")]
        public List<CategoryViewModel> Categories { get; set; }
    }
}
