using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoffeePattisserie.Entity.Abstract;

namespace CoffeePattisserie.Entity.Concrete
{
    public class Category : IBaseEntity,ICommonEntity
    {
        public int Id { get ; set ; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public bool IsActive { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsHome { get; set; }
        public List<CoffeeCategory> CoffeeCategories { get; set; }
        public List<MoctailCategory> MoctailCategories { get; set; }
        public List<PattisserieCategory> PattisserieCategories { get; set; }
    }
}