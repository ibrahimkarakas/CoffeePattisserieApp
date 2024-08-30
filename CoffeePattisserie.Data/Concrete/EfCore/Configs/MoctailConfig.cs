using CoffeePattisserie.Entity.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace CoffeePattisserie.Data.Concrete.EfCore.Configs
{
    public class MoctailConfig : IEntityTypeConfiguration<Moctail>
    {
        public void Configure(EntityTypeBuilder<Moctail> builder)
        {
            builder.HasKey(m => m.Id);
            builder.Property(m => m.Id).ValueGeneratedOnAdd();
            
            builder.Property(m => m.Name).IsRequired().HasMaxLength(100);
            builder.Property(m => m.Description).HasMaxLength(500);
            builder.Property(m => m.Ingredients).IsRequired().HasMaxLength(1000);
            builder.Property(m => m.PreparationMethod).HasMaxLength(1000);
            builder.Property(m => m.Price).HasColumnType("decimal(18,2)");
            builder.Property(m => m.StockQuantity).IsRequired();
            builder.Property(m => m.ImageUrl).HasMaxLength(255);
            builder.Property(m => m.FlavorProfile).HasMaxLength(255);
            builder.Property(m => m.CategoryId).IsRequired();
            builder.Property(m => m.IsHome).IsRequired();

            builder.ToTable("Moctails");

builder.HasData(
    new Moctail
    {
        Id = 1,
        Name = "Virgin Mojito",
        CreatedDate = DateTime.Now.AddDays(-10),
        IsActive = true,
        Description = "A refreshing mint and lime drink.",
        Ingredients = "Mint, Lime, Soda Water, Sugar",
        PreparationMethod = "Muddle mint leaves and lime wedges, add sugar and soda water.",
        Price = 140,
        StockQuantity = 50,
        ImageUrl = "virgin-mojito.jpg",
        FlavorProfile = "Minty, Citrusy",
        CategoryId = 1,
        IsHome = true
    },
    new Moctail
    {
        Id = 2,
        Name = "Shirley Temple",
        CreatedDate = DateTime.Now.AddDays(-9),
        IsActive = true,
        Description = "A sweet and fizzy drink with grenadine.",
        Ingredients = "Ginger Ale, Grenadine, Maraschino Cherry",
        PreparationMethod = "Mix ginger ale with grenadine and top with a cherry.",
        Price = 125,
        StockQuantity = 60,
        ImageUrl = "shirley-temple.jpg",
        FlavorProfile = "Sweet, Fizzy",
        CategoryId = 1,
        IsHome = false
    },
    new Moctail
    {
        Id = 3,
        Name = "Pina Colada",
        CreatedDate = DateTime.Now.AddDays(-8),
        IsActive = true,
        Description = "A tropical blend of pineapple and coconut.",
        Ingredients = "Pineapple Juice, Coconut Cream, Ice",
        PreparationMethod = "Blend pineapple juice and coconut cream with ice.",
        Price = 150,
        StockQuantity = 40,
        ImageUrl = "pina-colada.jpg",
        FlavorProfile = "Tropical, Creamy",
        CategoryId = 2,
        IsHome = true
    },
    new Moctail
    {
        Id = 4,
        Name = "Cinderella",
        CreatedDate = DateTime.Now.AddDays(-7),
        IsActive = true,
        Description = "A fruity drink with orange, pineapple, and lemon.",
        Ingredients = "Orange Juice, Pineapple Juice, Lemon Juice, Grenadine",
        PreparationMethod = "Shake all ingredients with ice and strain into a glass.",
        Price = 130,
        StockQuantity = 70,
        ImageUrl = "cinderella.jpg",
        FlavorProfile = "Fruity, Tangy",
        CategoryId = 2,
        IsHome = false
    },
    new Moctail
    {
        Id = 5,
        Name = "Sunrise",
        CreatedDate = DateTime.Now.AddDays(-6),
        IsActive = true,
        Description = "A vibrant mix of orange and grenadine.",
        Ingredients = "Orange Juice, Grenadine, Ice",
        PreparationMethod = "Pour orange juice over ice and drizzle with grenadine.",
        Price = 145,
        StockQuantity = 55,
        ImageUrl = "sunrise.jpg",
        FlavorProfile = "Citrusy, Sweet",
        CategoryId = 1,
        IsHome = true
    },
    new Moctail
    {
        Id = 6,
        Name = "Fruit Punch",
        CreatedDate = DateTime.Now.AddDays(-5),
        IsActive = true,
        Description = "A delightful mix of various fruit juices.",
        Ingredients = "Orange Juice, Pineapple Juice, Cranberry Juice, Lemon Juice",
        PreparationMethod = "Mix all juices together and serve over ice.",
        Price = 120,
        StockQuantity = 65,
        ImageUrl = "fruit-punch.jpg",
        FlavorProfile = "Fruity, Refreshing",
        CategoryId = 3,
        IsHome = false
    },
    new Moctail
    {
        Id = 7,
        Name = "Virgin Mary",
        CreatedDate = DateTime.Now.AddDays(-4),
        IsActive = true,
        Description = "A non-alcoholic version of the classic Bloody Mary.",
        Ingredients = "Tomato Juice, Lemon Juice, Worcestershire Sauce, Tabasco",
        PreparationMethod = "Mix all ingredients together and serve over ice.",
        Price = 135,
        StockQuantity = 45,
        ImageUrl = "virgin-mary.jpg",
        FlavorProfile = "Savory, Spicy",
        CategoryId = 3,
        IsHome = true
    },
    new Moctail
    {
        Id = 8,
        Name = "Berry Cooler",
        CreatedDate = DateTime.Now.AddDays(-3),
        IsActive = true,
        Description = "A refreshing mix of various berries.",
        Ingredients = "Strawberries, Blueberries, Raspberries, Lemonade",
        PreparationMethod = "Blend all ingredients with ice.",
        Price = 125,
        StockQuantity = 50,
        ImageUrl = "berry-cooler.jpg",
        FlavorProfile = "Berry, Tangy",
        CategoryId = 3,
        IsHome = false
    },
    new Moctail
    {
        Id = 9,
        Name = "Mint Lemonade",
        CreatedDate = DateTime.Now.AddDays(-2),
        IsActive = true,
        Description = "A refreshing lemonade with a hint of mint.",
        Ingredients = "Lemon Juice, Mint Leaves, Sugar, Water",
        PreparationMethod = "Mix lemon juice and sugar with water and add mint leaves.",
        Price = 130,
        StockQuantity = 70,
        ImageUrl = "mint-lemonade.jpg",
        FlavorProfile = "Minty, Citrusy",
        CategoryId = 1,
        IsHome = true
    },
    new Moctail
    {
        Id = 10,
        Name = "Tropical Fizz",
        CreatedDate = DateTime.Now.AddDays(-1),
        IsActive = true,
        Description = "A fizzy drink with tropical flavors.",
        Ingredients = "Pineapple Juice, Orange Juice, Soda Water",
        PreparationMethod = "Mix pineapple juice and orange juice with soda water.",
        Price = 140,
        StockQuantity = 55,
        ImageUrl = "tropical-fizz.jpg",
        FlavorProfile = "Tropical, Fizzy",
        CategoryId = 2,
        IsHome = false
    }
);

        }
    }
}
