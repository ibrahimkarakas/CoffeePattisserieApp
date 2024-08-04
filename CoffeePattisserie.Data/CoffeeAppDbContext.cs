using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoffeePattisserie.Data.Concrete.EfCore.Configs;
using CoffeePattisserie.Entity.Concrete;
using Microsoft.EntityFrameworkCore;

namespace CoffeePattisserie.Data
{
    public class CoffeeAppDbContext:DbContext
    {
        //Aşağıda Connection stringi karşılıyoruz.
        public CoffeeAppDbContext(DbContextOptions options):base(options)
        {
            
        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Moctail> Moctails { get; set; }
        public DbSet<Pattisserie> PattisserieProducts { get; set; }
        public DbSet<Coffee> Coffees { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(CategoryConfig).Assembly);
            modelBuilder.Entity<CoffeeC
            base.OnModelCreating(modelBuilder);
        }

    }
}