using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoffeePattisserie.Entity.Concrete;
using Microsoft.EntityFrameworkCore;

namespace CoffeePattisserie.Data
{
    public class CoffeeAppContext:DbContext
    {
        //Aşağıda Connection stringi karşılıyoruz.
        public CoffeeAppContext(DbContextOptions options):base(options)
        {
            
        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Moctail> Moctails { get; set; }
        public DbSet<Pattisserie> PattisserieProducts { get; set; }
        public DbSet<Coffee> Coffees { get; set; }

    }
}