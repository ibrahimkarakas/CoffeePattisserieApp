using System.Collections.Generic;
using System.ComponentModel;
using System.Text.Json.Serialization;

namespace CoffeePattisserieClient.Models
{
    public class MoctailViewModel : ProductViewModel
    {
        [JsonPropertyName("ingredients")]
        [DisplayName("İçindekiler")]
        public string Ingredients { get; set; }

        [JsonPropertyName("preparationMethod")]
        [DisplayName("Hazırlanış")]
        public string PreparationMethod { get; set; }

        [JsonPropertyName("flavorProfile")]
        [DisplayName("Lezzet Profili")]
        public string FlavorProfile { get; set; }
    }
}
