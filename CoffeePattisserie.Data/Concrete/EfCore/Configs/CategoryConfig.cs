using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoffeePattisserie.Entity.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CoffeePattisserie.Data.Concrete.EfCore.Configs
{
    public class CategoryConfig : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(x=>x.Id);
            builder.Property(x=>x.Id).ValueGeneratedOnAdd();
            builder.Property(x=>x.Name).IsRequired().HasMaxLength(50);
            builder.Property(x=>x.Description).IsRequired(false).HasMaxLength(500);
            builder.ToTable("Categories");

            builder.HasData(
                new Category{
                    Id=1,
                    Name="Coffees",
                    Description="Kahve kategorisi"
                },
                new Category{
                    Id=2,
                    Name="Deserts",
                    Description="Tatlı kategorisi"
                },
                new Category{
                    Id=3,
                    Name="Pattisserie",
                    Description="Fırın kategorisi",
                    IsActive=false
                },
                new Category{
                    Id=4,
                    Name="Wholesales",
                    Description="Toptan satış kategorisi"
                },
                new Category{
                    Id=5,
                    Name="Moctails",
                    Description="Alkolsüz karışım içecekler."
                }           
            );
        }
    }
}