using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoffeePattisserie.Shared.Dtos
{
    public class PattisserieDto{
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public bool IsActive { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int StockQuantity { get; set; }
        public string Ingredients { get; set; }
        public string Allergens { get; set; }
        public string ShelfLife { get; set; }
        public List<CategoryDto> Categories { get; set; }
        public string ImageUrl { get; set; }
        public bool IsHome { get; set; }
    }
}