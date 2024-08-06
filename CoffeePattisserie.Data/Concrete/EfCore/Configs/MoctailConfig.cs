using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using CoffeePattisserie.Entity.Concrete;
using System;

namespace CoffeePattisserie.Data.Concrete.EfCore.Configs
{
    public class MoctailConfig : IEntityTypeConfiguration<Moctail>
    {
        public void Configure(EntityTypeBuilder<Moctail> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();

            builder.Property(x => x.Name).IsRequired().HasMaxLength(50);
            builder.Property(x => x.Description).HasMaxLength(200);
            builder.Property(x => x.Ingredients).HasMaxLength(500);
            builder.Property(x => x.PreparationMethod).HasMaxLength(500);
            builder.Property(x => x.FlavorProfile).HasMaxLength(100);
            builder.Property(x => x.Price).HasColumnType("real");
            builder.Property(x => x.StockQuantity).IsRequired();

            builder.ToTable("Moctails");

            builder.HasData(
                new Moctail
                {
                    Id = 1,
                    Name = "Virgin Mojito",
                    CreatedDate = DateTime.Now.AddDays(-15),
                    ModifiedDate = DateTime.Now,
                    IsActive = true,
                    Description = "Refreshing non-alcoholic cocktail with mint and lime.",
                    Ingredients = "Mint leaves, Lime juice, Soda water, Sugar",
                    PreparationMethod = "Muddle mint leaves with sugar and lime juice. Add soda water and ice.",
                    FlavorProfile = "Minty, Citrusy, Refreshing",
                    Price = 120,
                    StockQuantity = 20
                },
                new Moctail
                {
                    Id = 2,
                    Name = "Pineapple Coconut Delight",
                    CreatedDate = DateTime.Now.AddDays(-10),
                    ModifiedDate = DateTime.Now,
                    IsActive = true,
                    Description = "Tropical blend of pineapple and coconut.",
                    Ingredients = "Pineapple juice, Coconut milk, Ice",
                    PreparationMethod = "Blend all ingredients until smooth. Serve chilled.",
                    FlavorProfile = "Tropical, Sweet, Creamy",
                    Price = 110,
                    StockQuantity = 30
                },
                new Moctail
                {
                    Id = 3,
                    Name = "Berry Blast",
                    CreatedDate = DateTime.Now.AddDays(-8),
                    ModifiedDate = DateTime.Now,
                    IsActive = true,
                    Description = "A sweet and tangy blend of mixed berries.",
                    Ingredients = "Strawberries, Blueberries, Raspberries, Lemon juice, Soda water",
                    PreparationMethod = "Blend berries with lemon juice. Top with soda water and serve over ice.",
                    FlavorProfile = "Fruity, Tangy, Refreshing",
                    Price = 135,
                    StockQuantity = 25
                },
                new Moctail
                {
                    Id = 4,
                    Name = "Mango Fizz",
                    CreatedDate = DateTime.Now.AddDays(-12),
                    ModifiedDate = DateTime.Now,
                    IsActive = true,
                    Description = "Sparkling mango drink with a hint of lime.",
                    Ingredients = "Mango puree, Lime juice, Sparkling water",
                    PreparationMethod = "Mix mango puree and lime juice. Add sparkling water and serve over ice.",
                    FlavorProfile = "Mango, Citrusy, Sparkling",
                    Price = 135,
                    StockQuantity = 35
                },
                new Moctail
                {
                    Id = 5,
                    Name = "Cucumber Cooler",
                    CreatedDate = DateTime.Now.AddDays(-18),
                    ModifiedDate = DateTime.Now,
                    IsActive = true,
                    Description = "Cool and refreshing cucumber drink with mint.",
                    Ingredients = "Cucumber, Mint leaves, Lemon juice, Soda water",
                    PreparationMethod = "Blend cucumber and mint. Add lemon juice and soda water. Serve chilled.",
                    FlavorProfile = "Fresh, Minty, Light",
                    Price = 125,
                    StockQuantity = 40
                },
                new Moctail
                {
                    Id = 6,
                    Name = "Orange Sunset",
                    CreatedDate = DateTime.Now.AddDays(-20),
                    ModifiedDate = DateTime.Now,
                    IsActive = true,
                    Description = "A vibrant blend of orange and grenadine.",
                    Ingredients = "Orange juice, Grenadine syrup, Ice",
                    PreparationMethod = "Mix orange juice and grenadine. Serve over ice for a layered effect.",
                    FlavorProfile = "Citrusy, Sweet, Vibrant",
                    Price = 120,
                    StockQuantity = 50
                }
            );
        }
    }
}
