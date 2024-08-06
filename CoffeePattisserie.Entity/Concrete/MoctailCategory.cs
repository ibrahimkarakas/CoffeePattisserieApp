using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeePattisserie.Entity.Concrete
{
    public class MoctailCategory
    {
        public int MoctailId { get; set; }
        public Moctail Moctail { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
