using System.Collections.Generic;
using System.ComponentModel;
using System.Text.Json.Serialization;

namespace CoffeePattisserieClient.Models
{
    public class CoffeeViewModel : ProductViewModel
    {
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
    }
}
