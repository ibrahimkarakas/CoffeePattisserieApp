using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoffeePattisserie.Shared.Dtos
{
    public class AddToCartDto
    {
        public string UserId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public string ProductType { get; set; }
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
    }
}
