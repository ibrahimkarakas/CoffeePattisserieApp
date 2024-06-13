using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoffeePattisserie.Entity.Abstract;

namespace CoffeePattisserie.Entity.Concrete
{
    public class Moctails : IBaseEntity, ICommonEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public bool IsActive { get; set; }
        public string Ingredients { get; set; }
        public string PreparationMethod { get; set; }
        public decimal Price { get; set; }
        public int StockQuantity { get; set; }
        public string FlavorProfile { get; set; }
        public int CategoryId { get; set; }
    }
}