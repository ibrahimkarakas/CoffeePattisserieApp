using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoffeePattisserie.Entity.Concrete
{
    public class CartItem
    {
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public int ProductId { get; set; }
        public string ProductType { get; set; }
        public int CartId { get; set; }
        public Cart Cart { get; set; }
        public int Quantity { get; set; }
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
    }
}
