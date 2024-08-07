using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoffeePattisserie.Shared.Dtos
{
    public class EditPattisserieDto{
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int StockQuantity { get; set; }
        public string Ingredients { get; set; }
        public string Allergens { get; set; }
        public string ShelfLife { get; set; }
        public List<int> CategoryIds { get; set; } = [];

    }
}