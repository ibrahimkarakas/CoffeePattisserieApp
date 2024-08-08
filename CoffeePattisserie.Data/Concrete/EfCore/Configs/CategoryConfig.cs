using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using CoffeePattisserie.Entity.Concrete;

namespace CoffeePattisserie.Data.Concrete.EfCore.Configs
{
    public class CategoryConfig : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Id).ValueGeneratedOnAdd();
            builder.Property(c => c.Name).IsRequired().HasMaxLength(100);
            builder.Property(c => c.Description).HasMaxLength(500);
            builder.Property(c => c.CreatedDate).IsRequired();
            builder.Property(c => c.ModifiedDate).IsRequired();
            builder.Property(c => c.IsActive).IsRequired();
            builder.Property(c => c.IsHome).IsRequired();
            builder.ToTable("Categories");

            builder.HasData(
                new Category
                {
                    Id = 1,
                    Name = "Coffee",
                    Description = "Various types of coffee",
                    IsActive = true,
                    IsHome = true,
                    CreatedDate = DateTime.Now,
                    ModifiedDate = DateTime.Now
                },
                new Category
                {
                    Id = 2,
                    Name = "Moctail",
                    Description = "Various types of moctails",
                    IsActive = true,
                    IsHome = true,
                    CreatedDate = DateTime.Now,
                    ModifiedDate = DateTime.Now
                },
                new Category
                {
                    Id = 3,
                    Name = "Pattisserie",
                    Description = "Various types of pattisseries",
                    IsActive = true,
                    IsHome = true,
                    CreatedDate = DateTime.Now,
                    ModifiedDate = DateTime.Now
                }
            );
        }
    }
}
