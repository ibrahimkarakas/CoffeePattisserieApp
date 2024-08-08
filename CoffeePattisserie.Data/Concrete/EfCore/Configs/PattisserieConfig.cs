using CoffeePattisserie.Entity.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace CoffeePattisserie.Data.Concrete.EfCore.Configs
{
    public class PattisserieConfig : IEntityTypeConfiguration<Pattisserie>
    {
        public void Configure(EntityTypeBuilder<Pattisserie> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).ValueGeneratedOnAdd();
            
            builder.Property(p => p.Name).IsRequired().HasMaxLength(100);
            builder.Property(p => p.Description).HasMaxLength(500);
            builder.Property(p => p.Price).HasColumnType("decimal(18,2)");
            builder.Property(p => p.StockQuantity).IsRequired();
            builder.Property(p => p.Ingredients).IsRequired().HasMaxLength(1000);
            builder.Property(p => p.Allergens).HasMaxLength(500);
            builder.Property(p => p.ShelfLife).HasMaxLength(100);
            builder.Property(p => p.ImageUrl).HasMaxLength(255);
            builder.Property(p => p.CategoryId).IsRequired();
            builder.Property(p => p.IsHome).IsRequired();

            builder.ToTable("Pattisseries");

            builder.HasData(
                new Pattisserie
                {
                    Id = 1,
                    Name = "Chocolate Cake",
                    CreatedDate = DateTime.Now.AddDays(-10),
                    IsActive = true,
                    Description = "A rich and moist chocolate cake.",
                    Price = 120,
                    StockQuantity = 30,
                    Ingredients = "Flour, Sugar, Cocoa, Baking Powder, Eggs, Milk",
                    Allergens = "Eggs, Milk, Gluten",
                    ShelfLife = "3 days",
                    ImageUrl = "chocolate-cake.jpg",
                    CategoryId = 1,
                    IsHome = true
                },
                new Pattisserie
                {
                    Id = 2,
                    Name = "Vanilla Cupcake",
                    CreatedDate = DateTime.Now.AddDays(-9),
                    IsActive = true,
                    Description = "A fluffy vanilla cupcake with buttercream frosting.",
                    Price = 125,
                    StockQuantity = 40,
                    Ingredients = "Flour, Sugar, Butter, Eggs, Vanilla Extract",
                    Allergens = "Eggs, Milk, Gluten",
                    ShelfLife = "2 days",
                    ImageUrl = "vanilla-cupcake.jpg",
                    CategoryId = 1,
                    IsHome = false
                },
                new Pattisserie
                {
                    Id = 3,
                    Name = "Strawberry Tart",
                    CreatedDate = DateTime.Now.AddDays(-8),
                    IsActive = true,
                    Description = "A tart filled with fresh strawberries and cream.",
                    Price = 130,
                    StockQuantity = 25,
                    Ingredients = "Flour, Sugar, Butter, Strawberries, Cream",
                    Allergens = "Milk, Gluten",
                    ShelfLife = "1 day",
                    ImageUrl = "strawberry-tart.jpg",
                    CategoryId = 2,
                    IsHome = true
                },
                new Pattisserie
                {
                    Id = 4,
                    Name = "Lemon Meringue Pie",
                    CreatedDate = DateTime.Now.AddDays(-7),
                    IsActive = true,
                    Description = "A tart lemon pie with a fluffy meringue topping.",
                    Price = 145,
                    StockQuantity = 20,
                    Ingredients = "Flour, Sugar, Eggs, Lemons, Butter",
                    Allergens = "Eggs, Milk, Gluten",
                    ShelfLife = "2 days",
                    ImageUrl = "lemon-meringue-pie.jpg",
                    CategoryId = 2,
                    IsHome = false
                },
                new Pattisserie
                {
                    Id = 5,
                    Name = "Blueberry Muffin",
                    CreatedDate = DateTime.Now.AddDays(-6),
                    IsActive = true,
                    Description = "A moist muffin packed with fresh blueberries.",
                    Price = 135,
                    StockQuantity = 35,
                    Ingredients = "Flour, Sugar, Blueberries, Eggs, Milk",
                    Allergens = "Eggs, Milk, Gluten",
                    ShelfLife = "3 days",
                    ImageUrl = "blueberry-muffin.jpg",
                    CategoryId = 3,
                    IsHome = true
                },
                new Pattisserie
                {
                    Id = 6,
                    Name = "Raspberry Cheesecake",
                    CreatedDate = DateTime.Now.AddDays(-5),
                    IsActive = true,
                    Description = "A creamy cheesecake with a raspberry swirl.",
                    Price = 140,
                    StockQuantity = 15,
                    Ingredients = "Cream Cheese, Sugar, Eggs, Raspberries, Graham Cracker Crust",
                    Allergens = "Eggs, Milk, Gluten",
                    ShelfLife = "5 days",
                    ImageUrl = "raspberry-cheesecake.jpg",
                    CategoryId = 3,
                    IsHome = false
                },
                new Pattisserie
                {
                    Id = 7,
                    Name = "Chocolate Chip Cookie",
                    CreatedDate = DateTime.Now.AddDays(-4),
                    IsActive = true,
                    Description = "A classic cookie loaded with chocolate chips.",
                    Price = 120,
                    StockQuantity = 50,
                    Ingredients = "Flour, Sugar, Butter, Eggs, Chocolate Chips",
                    Allergens = "Eggs, Milk, Gluten",
                    ShelfLife = "5 days",
                    ImageUrl = "chocolate-chip-cookie.jpg",
                    CategoryId = 1,
                    IsHome = true
                },
                new Pattisserie
                {
                    Id = 8,
                    Name = "Macaron",
                    CreatedDate = DateTime.Now.AddDays(-3),
                    IsActive = true,
                    Description = "A delicate French pastry with a creamy filling.",
                    Price = 150,
                    StockQuantity = 45,
                    Ingredients = "Almond Flour, Sugar, Egg Whites, Food Coloring",
                    Allergens = "Eggs, Nuts",
                    ShelfLife = "1 week",
                    ImageUrl = "macaron.jpg",
                    CategoryId = 2,
                    IsHome = false
                },
                new Pattisserie
                {
                    Id = 9,
                    Name = "Croissant",
                    CreatedDate = DateTime.Now.AddDays(-2),
                    IsActive = true,
                    Description = "A buttery, flaky pastry.",
                    Price = 125,
                    StockQuantity = 30,
                    Ingredients = "Flour, Butter, Sugar, Yeast, Salt",
                    Allergens = "Milk, Gluten",
                    ShelfLife = "2 days",
                    ImageUrl = "croissant.jpg",
                    CategoryId = 1,
                    IsHome = true
                },
                new Pattisserie
                {
                    Id = 10,
                    Name = "Pumpkin Pie",
                    CreatedDate = DateTime.Now.AddDays(-1),
                    IsActive = true,
                    Description = "A spiced pumpkin pie with a flaky crust.",
                    Price = 140,
                    StockQuantity = 20,
                    Ingredients = "Pumpkin, Sugar, Eggs, Cream, Spices, Flour",
                    Allergens = "Eggs, Milk, Gluten",
                    ShelfLife = "3 days",
                    ImageUrl = "pumpkin-pie.jpg",
                    CategoryId = 2,
                    IsHome = false
                },
                new Pattisserie
                {
                    Id = 11,
                    Name = "Red Velvet Cake",
                    CreatedDate = DateTime.Now.AddDays(-12),
                    IsActive = true,
                    Description = "A classic red velvet cake with cream cheese frosting.",
                    Price = 135,
                    StockQuantity = 30,
                    Ingredients = "Flour, Sugar, Cocoa, Buttermilk, Eggs, Red Food Coloring",
                    Allergens = "Eggs, Milk, Gluten",
                    ShelfLife = "3 days",
                    ImageUrl = "red-velvet-cake.jpg",
                    CategoryId = 3,
                    IsHome = true
                },
                new Pattisserie
                {
                    Id = 12,
                    Name = "Banana Bread",
                    CreatedDate = DateTime.Now.AddDays(-11),
                    IsActive = true,
                    Description = "A moist bread made with ripe bananas.",
                    Price = 130,
                    StockQuantity = 25,
                    Ingredients = "Flour, Sugar, Bananas, Eggs, Butter",
                    Allergens = "Eggs, Milk, Gluten",
                    ShelfLife = "1 week",
                    ImageUrl = "banana-bread.jpg",
                    CategoryId = 2,
                    IsHome = false
                },
                new Pattisserie
                {
                    Id = 13,
                    Name = "Apple Pie",
                    CreatedDate = DateTime.Now.AddDays(-10),
                    IsActive = true,
                    Description = "A classic pie filled with spiced apples.",
                    Price = 145,
                    StockQuantity = 20,
                    Ingredients = "Apples, Sugar, Flour, Butter, Cinnamon",
                    Allergens = "Milk, Gluten",
                    ShelfLife = "3 days",
                    ImageUrl = "apple-pie.jpg",
                    CategoryId = 3,
                    IsHome = true
                },
                new Pattisserie
                {
                    Id = 14,
                    Name = "Chocolate Eclair",
                    CreatedDate = DateTime.Now.AddDays(-9),
                    IsActive = true,
                    Description = "A choux pastry filled with cream and topped with chocolate.",
                    Price = 125,
                    StockQuantity = 15,
                    Ingredients = "Flour, Eggs, Butter, Cream, Chocolate",
                    Allergens = "Eggs, Milk, Gluten",
                    ShelfLife = "2 days",
                    ImageUrl = "chocolate-eclair.jpg",
                    CategoryId = 1,
                    IsHome = false
                }
            );
        }
    }
}
