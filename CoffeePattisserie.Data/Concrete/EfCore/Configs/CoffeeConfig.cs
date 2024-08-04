using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoffeePattisserie.Entity.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CoffeePattisserie.Data.Concrete.EfCore.Configs
{
    public class CoffeeConfig : IEntityTypeConfiguration<Coffee>
    {
        public void Configure(EntityTypeBuilder<Coffee> builder)
        {
            builder.HasKey(x=> x.Id);
            builder.Property(x=>x.Id).ValueGeneratedOnAdd();

            builder.Property(x=>x.Name).IsRequired().HasMaxLength(40);
            builder.Property(x=>x.StockQuantity).IsRequired();
            builder.Property(x=>x.Price).HasColumnType("real"); 
            // builder.Property(x=>x.CreatedDate).HasDefaultValueSql("getdate()");
            builder.ToTable("Products");

            builder.HasData(
                new Coffee{
                    Id=1,
                    Name="Ethiopian Yirgacheffe",
                    CreatedDate= DateTime.Now.AddDays(-10),
                    IsActive=true,
                    Price=350,
                    StockQuantity=45,
                    OriginCountry="Ethiopia",
                    RoastLevel="Light",
                    FlavorNotes="Floral, Citrus",
                    CaffeineContent=120,
                },
                 new Coffee{
                    Id=2,
                    Name="Colombian Supremo",
                    CreatedDate= DateTime.Now.AddDays(-22),
                    IsActive=true,
                    Price=299,
                    StockQuantity=100,
                    OriginCountry="Colombia",
                    RoastLevel="Medium",
                    FlavorNotes="Nutty, Chocolate",
                    CaffeineContent=110,
                },
                 new Coffee{
                    Id=3,
                    Name="Sumatra Mandheling",
                    CreatedDate= DateTime.Now.AddDays(-5),
                    IsActive=true,
                    Price=499,
                    StockQuantity=30,
                    OriginCountry="Indonesia",
                    RoastLevel="Dark",
                    FlavorNotes="Earthy, Herbal",
                    CaffeineContent=100,
                },
                 new Coffee{
                    Id=4,
                    Name="Brazil Santos",
                    CreatedDate= DateTime.Now.AddDays(-10),
                    IsActive=true,
                    Price=250,
                    StockQuantity=120,
                    OriginCountry="Brazil",
                    RoastLevel="Medium",
                    FlavorNotes="Sweet, Nutty",
                    CaffeineContent=115,
                },
                 new Coffee{
                    Id=5,
                    Name="Jamaican Blue Mountain",
                    CreatedDate= DateTime.Now.AddDays(-30),
                    IsActive=true,
                    Price=899,
                    StockQuantity=10,
                    OriginCountry="Jamaica",
                    RoastLevel="Light",
                    FlavorNotes="Smooth, Sweet, Mild",
                    CaffeineContent=105,
                }
            );

        }
    }
}
