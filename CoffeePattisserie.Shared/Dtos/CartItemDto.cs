using System;
using System.Text.Json.Serialization;

namespace CoffeePattisserie.Shared.Dtos
{
    public class CartItemDto
    {
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public int ProductId { get; set; }  // Ürün ID'si
        public string ProductType { get; set; }  // Ürün türünü belirten property

        public CoffeeDto Coffee { get; set; }
        public MoctailDto Moctail { get; set; }
        public PattisserieDto Pattisserie { get; set; }
        public object Product
        {
            get
            {
                return ProductType switch
                {
                    "Coffee" => Coffee,
                    "Moctail" => Moctail,
                    "Pattisserie" => Pattisserie,
                    _ => null,
                };
            }
        }
        public int CartId { get; set; }
        [JsonIgnore]
        public CartDto Cart { get; set; }
        public int Quantity { get; set; }
    }
}
