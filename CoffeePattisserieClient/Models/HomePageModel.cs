using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoffeePattisserieClient.Models
{
    public class HomePageModel
    {
        public List<CategoryViewModel> Categories { get; set; }
        public List<ProductViewModel> Products { get; set; }
    }
}