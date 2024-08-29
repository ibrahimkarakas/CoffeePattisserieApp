using System.Text.Json.Serialization;

namespace CoffeePattisserieClient.Areas.Admin.Models
{
    public class MoctailModel
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("isHome")]
        public bool IsHome { get; set; }

        [JsonPropertyName("createdDate")]
        public DateTime CreatedDate { get; set; }

        [JsonPropertyName("modifiedDate")]
        public DateTime ModifiedDate { get; set; }

        [JsonPropertyName("isActive")]
        public bool IsActive { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("description")]
        public string Description { get; set; }

        [JsonPropertyName("ingredients")]
        public string Ingredients { get; set; }

        [JsonPropertyName("preparationMethod")]
        public string PreparationMethod { get; set; }

        [JsonPropertyName("flavorProfile")]
        public string FlavorProfile { get; set; }

        [JsonPropertyName("price")]
        public decimal Price { get; set; }

        [JsonPropertyName("stockQuantity")]
        public int StockQuantity { get; set; }

        [JsonPropertyName("imageUrl")]
        public string ImageUrl { get; set; }

        [JsonPropertyName("categoryId")]
        public int CategoryId { get; set; }

        [JsonPropertyName("categories")]
        public List<CategoryModel> Categories { get; set; }
    }
}
