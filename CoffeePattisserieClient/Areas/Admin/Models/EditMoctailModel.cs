using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace CoffeePattisserieClient.Areas.Admin.Models
{
    public class EditMoctailModel
    {
        public int Id { get; set; }

        [JsonPropertyName("isActive")]
        public bool IsActive { get; set; }

        [JsonPropertyName("isHome")]
        public bool IsHome { get; set; }

        [JsonPropertyName("name")]
        [DisplayName("Moctail Adı")]
        [Required(ErrorMessage = "Bu alan boş bırakılamaz")]
        [MinLength(3, ErrorMessage = "Bu alanın uzunluğu 3 karakterden kısa olamaz")]
        public string Name { get; set; }

        [JsonPropertyName("description")]
        [DisplayName("Açıklama")]
        [Required(ErrorMessage = "Bu alan boş bırakılamaz")]
        public string Description { get; set; }

        [JsonPropertyName("ingredients")]
        [DisplayName("İçindekiler")]
        [Required(ErrorMessage = "Bu alan boş bırakılamaz")]
        public string Ingredients { get; set; }

        [JsonPropertyName("preparationMethod")]
        [DisplayName("Hazırlama Yöntemi")]
        [Required(ErrorMessage = "Bu alan boş bırakılamaz")]
        public string PreparationMethod { get; set; }

        [JsonPropertyName("flavorProfile")]
        [DisplayName("Aroma Profili")]
        public string FlavorProfile { get; set; }

        [JsonPropertyName("stockQuantity")]
        [DisplayName("Stok")]
        [Required(ErrorMessage = "Bu alan boş bırakılamaz")]
        [Range(0, 1000, ErrorMessage = "Bu alana 0-1000 aralığı dışında bir değer girilemez")]
        public int? StockQuantity { get; set; }

        [JsonPropertyName("price")]
        [DisplayName("Fiyat")]
        [Required(ErrorMessage = "Bu alan boş bırakılamaz")]
        [Range(0, 10000, ErrorMessage = "Bu alana 0-10000 aralığı dışında bir değer girilemez")]
        public decimal? Price { get; set; }

        [JsonPropertyName("imageUrl")]
        public string ImageUrl { get; set; }

        [JsonPropertyName("categoryIds")]
        public List<int> CategoryIds { get; set; }

        public List<CategoryModel> CategoryList { get; set; }
    }
}
