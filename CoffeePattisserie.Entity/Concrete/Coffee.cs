using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoffeePattisserie.Entity.Abstract;

namespace CoffeePattisserie.Entity.Concrete
{
    public class Coffee : IBaseEntity, ICommonEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public DateTime ModifiedDate { get; set; } = DateTime.Now;
        public bool IsActive { get; set; }
        public decimal Price { get; set; }
        public int StockQuantity { get; set; }
        public string OriginCountry { get; set; }
        public string RoastLevel { get; set; }
        public string FlavorNotes { get; set; }
        public int CaffeineContent { get; set; }
        public int CategoryId  { get; set; }
        public string ImageUrl { get; set; }
        public bool IsHome { get; set; }
        public List<CoffeeCategory> CoffeeCategories {get; set;}
    }
}