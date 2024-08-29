using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace CoffeePattisserieClient.Areas.Admin.Models
{
    public class AddCoffeeModel
    {
        [JsonPropertyName("isActive")]
        public bool IsActive { get; set; }

        [JsonPropertyName("isHome")]
        public bool IsHome { get; set; }

        [JsonPropertyName("name")]
        [DisplayName("Kahve Adı")]
        [Required(ErrorMessage = "Bu alan boş bırakılamaz")]
        [MinLength(3, ErrorMessage = "Bu alanın uzunluğu 3 karakterden kısa olamaz")]
        public string Name { get; set; }

        [JsonPropertyName("originCountry")]
        [DisplayName("Menşei Ülke")]
        [Required(ErrorMessage = "Bu alan boş bırakılamaz")]
        public string OriginCountry { get; set; }

        [JsonPropertyName("roastLevel")]
        [DisplayName("Kavurma Seviyesi")]
        [Required(ErrorMessage = "Bu alan boş bırakılamaz")]
        public string RoastLevel { get; set; }

        [JsonPropertyName("flavorNotes")]
        [DisplayName("Lezzet Notları")]
        [Required(ErrorMessage = "Bu alan boş bırakılamaz")]
        public string FlavorNotes { get; set; }

        [JsonPropertyName("caffeineContent")]
        [DisplayName("Kafein İçeriği (mg)")]
        [Required(ErrorMessage = "Bu alan boş bırakılamaz")]
        [Range(0, int.MaxValue, ErrorMessage = "Kafein içeriği pozitif bir değer olmalıdır.")]
        public int CaffeineContent { get; set; }

        [JsonPropertyName("price")]
        [DisplayName("Fiyat")]
        [Required(ErrorMessage = "Bu alan boş bırakılamaz")]
        [Range(0.01, 10000, ErrorMessage = "Fiyat 0.01 ile 10,000 arasında olmalıdır.")]
        public decimal Price { get; set; }

        [JsonPropertyName("stockQuantity")]
        [DisplayName("Stok Miktarı")]
        [Required(ErrorMessage = "Bu alan boş bırakılamaz")]
        [Range(0, 10000, ErrorMessage = "Stok miktarı 0 ile 10,000 arasında olmalıdır.")]
        public int StockQuantity { get; set; }

        [JsonPropertyName("imageUrl")]
        public string ImageUrl { get; set; }

        [JsonPropertyName("categoryId")]
        [DisplayName("Kategori")]
        [Required(ErrorMessage = "Bu alan boş bırakılamaz")]
        public int CategoryId { get; set; }

        public List<SelectListItem> CategoryList { get; set; }
    }
}
