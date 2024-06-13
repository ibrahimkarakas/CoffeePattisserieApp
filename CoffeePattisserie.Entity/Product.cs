using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoffeePattisserie.Entity
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Properties { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public string CreatorUserId { get; set; }
        public string UpdaterUserId { get; set; }
        public bool IsActive { get; set; }
        
        //This section will be used to view the advertised products.
        public bool IsAdvertised { get; set; }
        public DateTime ExpirationDate { get; set; }
    }
}