using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoffeePattisserie.Data.Concrete.EfCore.Configs;
using CoffeePattisserie.Entity.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace CoffeePattisserie.Data
{
    public class CoffeeAppDbContext : DbContext
    {
        // Aşağıda Connection string'i karşılıyoruz.
        public CoffeeAppDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Moctail> Moctails { get; set; }
        public DbSet<MoctailCategory> MoctailCategories { get; set; }
        public DbSet<Pattisserie> Pattisserie { get; set; } 
        public DbSet<PattisserieCategory> PattisserieCategories { get; set; }
        public DbSet<Coffee> Coffees { get; set; }
        public DbSet<CoffeeCategory> CoffeeCategories { get; set; }
        public DbSet<Cart> Carts { get; set; } // Sepet tablosu
        public DbSet<CartItem> CartItems { get; set; } // Sepet öğeleri tablosu
        public DbSet<Order> Orders { get; set; } // Sipariş tablosu
        public DbSet<OrderItem> OrderItems { get; set; } // Sipariş öğeleri tablosu

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(CategoryConfig).Assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}
