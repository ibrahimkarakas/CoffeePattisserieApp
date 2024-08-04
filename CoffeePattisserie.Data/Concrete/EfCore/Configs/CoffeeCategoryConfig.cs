using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using CoffeePattisserie.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace CoffeePattisserie.Data.Concrete.EfCore.Configs
{
    internal class CoffeeCategoryConfig : IEntityTypeConfiguration<CoffeeCategory>
    {
        public void Configure(EntityTypeBuilder<CoffeeCategory> builder)
        {
            builder.HasKey(cc => new { cc.CoffeeId, cc.CategoryId });
            builder.ToTable("CoffeeCategories");

            builder.HasData(
                new CoffeeCategory { CoffeeId = 1, CategoryId = 1 },
        new CoffeeCategory { CoffeeId = 1, CategoryId = 3 },
        new CoffeeCategory { CoffeeId = 1, CategoryId = 4 },
        new CoffeeCategory { CoffeeId = 2, CategoryId = 2 },
        new CoffeeCategory { CoffeeId = 3, CategoryId = 3 }, 
        new CoffeeCategory { CoffeeId = 4, CategoryId = 1 },
        new CoffeeCategory { CoffeeId = 5, CategoryId = 2 },
        new CoffeeCategory { CoffeeId = 5, CategoryId = 3 },
        new CoffeeCategory { CoffeeId = 2, CategoryId = 4 },
        new CoffeeCategory { CoffeeId = 4, CategoryId = 4 },
        new CoffeeCategory { CoffeeId = 3, CategoryId = 4 }, 
        new CoffeeCategory { CoffeeId = 2, CategoryId = 3 },
        new CoffeeCategory { CoffeeId = 3, CategoryId = 1 }
    );
        }
    }
}
