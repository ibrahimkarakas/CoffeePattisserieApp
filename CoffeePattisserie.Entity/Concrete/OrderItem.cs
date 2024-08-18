using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoffeePattisserie.Entity.Concrete
{
    public class OrderItem
    {
        public int Id { get; set; }
        
        public int OrderId { get; set; }
        public Order Order { get; set; }
        public int ProductId { get; set; }
        public string ProductType { get; set; }
        public Coffee Coffee { get; set; }
        public Moctail Moctail { get; set; }
        public Pattisserie Pattisserie { get; set; }
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