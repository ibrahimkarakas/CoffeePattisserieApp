using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace CoffeePattisserieClient.Models
{
    public class CartViewModel
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("userId")]
        public string UserId { get; set; }

        [JsonPropertyName("cartItems")]
        public List<CartItemViewModel> CartItems { get; set; } = new List<CartItemViewModel>();

        [JsonPropertyName("createdDate")]
        public DateTime CreatedDate { get; set; }

        [JsonPropertyName("modifiedDate")]
        public DateTime ModifiedDate { get; set; }
    }
}
