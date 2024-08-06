using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoffeePattisserie.Shared.Dtos
{
    public class AddMoctailDto
    {
        public string Name { get; set; }
        public bool IsActive { get; set; }
        public string Description { get; set; }
        public string Ingredients { get; set; }
        public string PreparationMethod { get; set; }
        public decimal Price { get; set; }
        public int StockQuantity { get; set; }
        public string FlavorProfile { get; set; }
    }
}