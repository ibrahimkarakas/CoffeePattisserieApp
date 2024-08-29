using System.Collections.Generic;
using System.ComponentModel;
using System.Text.Json.Serialization;

namespace CoffeePattisserieClient.Models
{
    public class ProductViewModel
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("name")]
        [DisplayName("Ürün Adı")]
        public string Name { get; set; }

        [JsonPropertyName("price")]
        [DisplayName("Fiyat")]
        public decimal Price { get; set; }

        [JsonPropertyName("imageUrl")]
        [DisplayName("Resim")]
        public string ImageUrl { get; set; }

        [JsonPropertyName("stockQuantity")]
        [DisplayName("Stok")]
        public int StockQuantity { get; set; }

        [JsonPropertyName("categories")]
        [DisplayName("Kategoriler")]
        public List<CategoryViewModel> Categories { get; set; }
    }
}
