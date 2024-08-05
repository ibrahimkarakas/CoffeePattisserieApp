using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using CoffeePattisserie.Entity.Concrete;

namespace CoffeePattisserie.Data.Concrete.EfCore.Configs
{
    public class PattisserieConfig : IEntityTypeConfiguration<Pattisserie>
    {
        public void Configure(EntityTypeBuilder<Pattisserie> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();

            builder.Property(x => x.Name).IsRequired().HasMaxLength(50);
            builder.Property(x => x.Description).HasMaxLength(200);
            builder.Property(x => x.Price).HasColumnType("real");
            builder.Property(x => x.StockQuantity).IsRequired();
            builder.Property(x => x.Ingredients).HasMaxLength(500);
            builder.Property(x => x.Allergens).HasMaxLength(200);
            builder.Property(x => x.ShelfLife).HasMaxLength(50);

            builder.ToTable("PattisserieProducts");

            builder.HasData(
                new Pattisserie
                {
                    Id = 1,
                    Name = "Paris Brest",
                    CreatedDate = DateTime.Now.AddDays(-15),
                    ModifiedDate = DateTime.Now,
                    IsActive = true,
                    Description = "Traditional French dessert made with choux pastry and praline-flavored cream.",
                    Price = 155,
                    StockQuantity = 20,
                    Ingredients = "Choux pastry, Praline cream, Almonds",
                    Allergens = "Dairy, Nuts, Gluten",
                    ShelfLife = "2 days in refrigerator",
                    PattisserieCategories = new List<PattisserieCategory>()
                },
                new Pattisserie
                {
                    Id = 2,
                    Name = "Tiramisu",
                    CreatedDate = DateTime.Now.AddDays(-10),
                    ModifiedDate = DateTime.Now,
                    IsActive = true,
                    Description = "Classic Italian dessert with coffee-soaked ladyfingers and mascarpone cheese.",
                    Price = 145,
                    StockQuantity = 30,
                    Ingredients = "Ladyfingers, Mascarpone cheese, Coffee, Cocoa",
                    Allergens = "Dairy, Gluten, Eggs",
                    ShelfLife = "3 days refrigerated",
                    PattisserieCategories = new List<PattisserieCategory>()
                },
                new Pattisserie
                {
                    Id = 3,
                    Name = "Baklava",
                    CreatedDate = DateTime.Now.AddDays(-5),
                    ModifiedDate = DateTime.Now,
                    IsActive = true,
                    Description = "Traditional Turkish dessert made with layers of filo pastry, nuts, and honey syrup.",
                    Price = 700,
                    StockQuantity = 50,
                    Ingredients = "Filo pastry, Walnuts, Honey syrup",
                    Allergens = "Nuts, Gluten",
                    ShelfLife = "5 days",
                    PattisserieCategories = new List<PattisserieCategory>()
                },
                new Pattisserie
                {
                    Id = 4,
                    Name = "Cheesecake",
                    CreatedDate = DateTime.Now.AddDays(-20),
                    ModifiedDate = DateTime.Now,
                    IsActive = true,
                    Description = "Rich dessert with a cream cheese filling on a graham cracker crust.",
                    Price = 150,
                    StockQuantity = 40,
                    Ingredients = "Cream cheese, Graham crackers, Sugar",
                    Allergens = "Dairy, Gluten",
                    ShelfLife = "5 days refrigerated",
                    PattisserieCategories = new List<PattisserieCategory>()
                },
                 new Pattisserie
                {
                    Id = 5,
                    Name = "Éclair",
                    CreatedDate = DateTime.Now.AddDays(-10),
                    ModifiedDate = DateTime.Now,
                    IsActive = true,
                    Description = "Long French pastry made with choux dough filled with cream and topped with icing.",
                    Price = 80,
                    StockQuantity = 50,
                    Ingredients = "Choux pastry, Chocolate icing, Pastry cream",
                    Allergens = "Dairy, Gluten, Eggs",
                    ShelfLife = "1 day",
                    PattisserieCategories = new List<PattisserieCategory>()
                },
                new Pattisserie
                {
                    Id = 6,
                    Name = "Danish Pastry",
                    CreatedDate = DateTime.Now.AddDays(-7),
                    ModifiedDate = DateTime.Now,
                    IsActive = true,
                    Description = "Light, flaky pastry with a variety of sweet fillings.",
                    Price = 140,
                    StockQuantity = 60,
                    Ingredients = "Flour, Butter, Sugar, Fruit filling",
                    Allergens = "Gluten, Dairy",
                    ShelfLife = "2 days",
                    PattisserieCategories = new List<PattisserieCategory>()
                }
            );
        }
    }
}
