using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoffeePattisserie.Entity.Concrete;
using Microsoft.EntityFrameworkCore;

namespace CoffeePattisserie.Data
{
    public class AppContext:DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Moctail> Moctails { get; set; }
        public DbSet<Pattisserie> PattisserieProducts { get; set; }
        public DbSet<Coffee> Coffees { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-TIS7K1K\\SQLEXPRESS;Database=PattisserieAppDb;User=sa;Password=1234;TrustServerCertificate=true");
            base.OnConfiguring(optionsBuilder);
        }
    }
}