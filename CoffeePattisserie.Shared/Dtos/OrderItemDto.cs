using System;
using System.Text.Json.Serialization;

namespace CoffeePattisserie.Shared.Dtos
{
    public class OrderItemDto
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        
        [JsonIgnore]
        public OrderDto Order { get; set; }
        
        public int ProductId { get; set; }  // Ürün ID'si
        public string ProductType { get; set; }  // Ürün türünü belirten property

        [JsonIgnore]
        public CoffeeDto Coffee { get; set; }
        
        [JsonIgnore]
        public MoctailDto Moctail { get; set; }
        
        [JsonIgnore]
        public PattisserieDto Pattisserie { get; set; }

        // Ürün türüne göre ilgili ürünü döndüren property
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

        public decimal Price { get; set; }
        public int Quantity { get; set; }
    }
}
