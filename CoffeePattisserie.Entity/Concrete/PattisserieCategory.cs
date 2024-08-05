using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeePattisserie.Entity.Concrete
{
    public class PattisserieCategory
    {
        public int PattisserieId { get; set; }
        public Pattisserie Pattisserie { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
