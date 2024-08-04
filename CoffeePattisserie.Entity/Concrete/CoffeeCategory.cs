using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeePattisserie.Entity.Concrete
{
    public class CoffeeCategory
    {
        public int CoffeeId { get; set; }
        public Coffee Coffee { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
