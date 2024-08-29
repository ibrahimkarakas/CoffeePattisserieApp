using System.Collections.Generic;
using System.ComponentModel;
using System.Text.Json.Serialization;

namespace CoffeePattisserieClient.Models
{
    public class PattisserieViewModel : ProductViewModel
    {
        [JsonPropertyName("description")]
        [DisplayName("Açıklama")]
        public string Description { get; set; }

        [JsonPropertyName("ingredients")]
        [DisplayName("İçindekiler")]
        public string Ingredients { get; set; }

        [JsonPropertyName("allergens")]
        [DisplayName("Alerjenler")]
        public string Allergens { get; set; }

        [JsonPropertyName("shelfLife")]
        [DisplayName("Raf Ömrü")]
        public string ShelfLife { get; set; }
    }
}
