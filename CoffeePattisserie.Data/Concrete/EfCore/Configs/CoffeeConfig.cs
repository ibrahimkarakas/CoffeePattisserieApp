using CoffeePattisserie.Entity.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace CoffeePattisserie.Data.Concrete.EfCore.Configs
{
    public class CoffeeConfig : IEntityTypeConfiguration<Coffee>
    {
        public void Configure(EntityTypeBuilder<Coffee> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Id).ValueGeneratedOnAdd();

            builder.Property(c => c.Name).IsRequired().HasMaxLength(100);
            builder.Property(c => c.Price).HasColumnType("decimal(18,2)");
            builder.Property(c => c.StockQuantity).IsRequired();
            builder.Property(c => c.OriginCountry).HasMaxLength(100);
            builder.Property(c => c.RoastLevel).HasMaxLength(50);
            builder.Property(c => c.FlavorNotes).HasMaxLength(255);
            builder.Property(c => c.CaffeineContent).IsRequired();
            builder.Property(c => c.ImageUrl).HasMaxLength(255);
            builder.Property(c => c.CategoryId).IsRequired();
            builder.Property(c => c.IsHome).IsRequired();

            builder.ToTable("Coffees");

builder.HasData(
    new Coffee
    {
        Id = 1,
        Name = "Ethiopian Yirgacheffe",
        CreatedDate = DateTime.Now.AddDays(-10),
        IsActive = true,
        Price = 120,
        StockQuantity = 45,
        OriginCountry = "Ethiopia",
        RoastLevel = "Light",
        FlavorNotes = "Floral, Citrus",
        CaffeineContent = 120,
        CategoryId = 1,
        ImageUrl = "ethiopian-yirgacheffe.jpg",
        IsHome = true
    },
    new Coffee
    {
        Id = 2,
        Name = "Colombian Supremo",
        CreatedDate = DateTime.Now.AddDays(-22),
        IsActive = true,
        Price = 125,
        StockQuantity = 100,
        OriginCountry = "Colombia",
        RoastLevel = "Medium",
        FlavorNotes = "Nutty, Chocolate",
        CaffeineContent = 110,
        CategoryId = 2,
        ImageUrl = "colombian-supremo.jpg",
        IsHome = false
    },
    new Coffee
    {
        Id = 3,
        Name = "Sumatra Mandheling",
        CreatedDate = DateTime.Now.AddDays(-5),
        IsActive = true,
        Price = 130,
        StockQuantity = 30,
        OriginCountry = "Indonesia",
        RoastLevel = "Dark",
        FlavorNotes = "Earthy, Herbal",
        CaffeineContent = 100,
        CategoryId = 3,
        ImageUrl = "sumatra-mandheling.jpg",
        IsHome = true
    },
    new Coffee
    {
        Id = 4,
        Name = "Brazil Santos",
        CreatedDate = DateTime.Now.AddDays(-10),
        IsActive = true,
        Price = 135,
        StockQuantity = 120,
        OriginCountry = "Brazil",
        RoastLevel = "Medium",
        FlavorNotes = "Sweet, Nutty",
        CaffeineContent = 115,
        CategoryId = 4,
        ImageUrl = "brazil-santos.jpg",
        IsHome = false
    },
    new Coffee
    {
        Id = 5,
        Name = "Jamaican Blue Mountain",
        CreatedDate = DateTime.Now.AddDays(-30),
        IsActive = true,
        Price = 140,
        StockQuantity = 10,
        OriginCountry = "Jamaica",
        RoastLevel = "Light",
        FlavorNotes = "Smooth, Sweet, Mild",
        CaffeineContent = 105,
        CategoryId = 1,
        ImageUrl = "jamaican-blue-mountain.jpg",
        IsHome = true
    },
    new Coffee
    {
        Id = 6,
        Name = "Kenyan AA",
        CreatedDate = DateTime.Now.AddDays(-15),
        IsActive = true,
        Price = 145,
        StockQuantity = 50,
        OriginCountry = "Kenya",
        RoastLevel = "Medium",
        FlavorNotes = "Fruity, Winey",
        CaffeineContent = 110,
        CategoryId = 2,
        ImageUrl = "kenyan-aa.jpg",
        IsHome = false
    },
    new Coffee
    {
        Id = 7,
        Name = "Costa Rican Tarrazu",
        CreatedDate = DateTime.Now.AddDays(-20),
        IsActive = true,
        Price = 125,
        StockQuantity = 35,
        OriginCountry = "Costa Rica",
        RoastLevel = "Light",
        FlavorNotes = "Citrus, Chocolate",
        CaffeineContent = 115,
        CategoryId = 3,
        ImageUrl = "costa-rican-tarrazu.jpg",
        IsHome = true
    },
    new Coffee
    {
        Id = 8,
        Name = "Guatemalan Antigua",
        CreatedDate = DateTime.Now.AddDays(-25),
        IsActive = true,
        Price = 150,
        StockQuantity = 20,
        OriginCountry = "Guatemala",
        RoastLevel = "Medium",
        FlavorNotes = "Spicy, Smoky",
        CaffeineContent = 105,
        CategoryId = 4,
        ImageUrl = "guatemalan-antigua.jpg",
        IsHome = false
    },
    new Coffee
    {
        Id = 9,
        Name = "Mexican Altura",
        CreatedDate = DateTime.Now.AddDays(-18),
        IsActive = true,
        Price = 140,
        StockQuantity = 60,
        OriginCountry = "Mexico",
        RoastLevel = "Light",
        FlavorNotes = "Nutty, Caramel",
        CaffeineContent = 100,
        CategoryId = 1,
        ImageUrl = "mexican-altura.jpg",
        IsHome = true
    },
    new Coffee
    {
        Id = 10,
        Name = "Hawaiian Kona",
        CreatedDate = DateTime.Now.AddDays(-12),
        IsActive = true,
        Price = 130,
        StockQuantity = 15,
        OriginCountry = "Hawaii",
        RoastLevel = "Medium",
        FlavorNotes = "Rich, Buttery",
        CaffeineContent = 110,
        CategoryId = 2,
        ImageUrl = "hawaiian-kona.jpg",
        IsHome = false
    },
    new Coffee
    {
        Id = 11,
        Name = "Yemen Mocha",
        CreatedDate = DateTime.Now.AddDays(-8),
        IsActive = true,
        Price = 125,
        StockQuantity = 25,
        OriginCountry = "Yemen",
        RoastLevel = "Dark",
        FlavorNotes = "Chocolate, Spicy",
        CaffeineContent = 105,
        CategoryId = 3,
        ImageUrl = "yemen-mocha.jpg",
        IsHome = true
    },
    new Coffee
    {
        Id = 12,
        Name = "Ecuador Vilcabamba",
        CreatedDate = DateTime.Now.AddDays(-6),
        IsActive = true,
        Price = 140,
        StockQuantity = 20,
        OriginCountry = "Ecuador",
        RoastLevel = "Light",
        FlavorNotes = "Sweet, Floral",
        CaffeineContent = 115,
        CategoryId = 4,
        ImageUrl = "ecuador-vilcabamba.jpg",
        IsHome = false
    },
    new Coffee
    {
        Id = 13,
        Name = "Americano",
        CreatedDate = DateTime.Now.AddDays(-5),
        IsActive = true,
        Price = 15,
        StockQuantity = 50,
        OriginCountry = "USA",
        RoastLevel = "Medium",
        FlavorNotes = "Smooth and rich",
        CaffeineContent = 110,
        CategoryId = 2,
        ImageUrl = "americano.jpg",
        IsHome = true
    },
    new Coffee
    {
        Id = 14,
        Name = "Cappuccino",
        CreatedDate = DateTime.Now.AddDays(-3),
        IsActive = true,
        Price = 25,
        StockQuantity = 60,
        OriginCountry = "Italy",
        RoastLevel = "Medium",
        FlavorNotes = "Creamy and frothy",
        CaffeineContent = 115,
        CategoryId = 2,
        ImageUrl = "cappuccino.jpg",
        IsHome = false
    },
    new Coffee
    {
        Id = 15,
        Name = "Cold Brew",
        CreatedDate = DateTime.Now.AddDays(-2),
        IsActive = true,
        Price = 30,
        StockQuantity = 40,
        OriginCountry = "USA",
        RoastLevel = "Light",
        FlavorNotes = "Cool and refreshing",
        CaffeineContent = 100,
        CategoryId = 2,
        ImageUrl = "cold_brew.jpg",
        IsHome = true
    },
    new Coffee
    {
        Id = 16,
        Name = "Espresso",
        CreatedDate = DateTime.Now.AddDays(-1),
        IsActive = true,
        Price = 20,
        StockQuantity = 70,
        OriginCountry = "Italy",
        RoastLevel = "Dark",
        FlavorNotes = "Strong and bold",
        CaffeineContent = 120,
        CategoryId = 2,
        ImageUrl = "espresso.jpg",
        IsHome = false
    },
    new Coffee
    {
        Id = 17,
        Name = "Flat White",
        CreatedDate = DateTime.Now.AddDays(-8),
        IsActive = true,
        Price = 28,
        StockQuantity = 50,
        OriginCountry = "Australia",
        RoastLevel = "Medium",
        FlavorNotes = "Smooth and silky",
        CaffeineContent = 115,
        CategoryId = 2,
        ImageUrl = "flat_white.jpg",
        IsHome = true
    },
    new Coffee
    {
        Id = 18,
        Name = "Latte",
        CreatedDate = DateTime.Now.AddDays(-7),
        IsActive = true,
        Price = 30,
        StockQuantity = 60,
        OriginCountry = "Italy",
        RoastLevel = "Light",
        FlavorNotes = "Mild and creamy",
        CaffeineContent = 110,
        CategoryId = 2,
        ImageUrl = "latte.jpg",
        IsHome = false
    }
);

        }
    }
}
