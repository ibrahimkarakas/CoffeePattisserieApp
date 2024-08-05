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
    internal class PattisserieCategoryConfig : IEntityTypeConfiguration<PattisserieCategory>
    {
        public void Configure(EntityTypeBuilder<PattisserieCategory> builder)
        {
            builder.HasKey(pc => new { pc.PattisserieId, pc.CategoryId });
            builder.ToTable("PattisserieCategories");

            builder.HasData(
                new PattisserieCategory { PattisserieId = 1, CategoryId = 1 },
                new PattisserieCategory { PattisserieId = 1, CategoryId = 3 },
                new PattisserieCategory { PattisserieId = 2, CategoryId = 2 },
                new PattisserieCategory { PattisserieId = 3, CategoryId = 1 },
                new PattisserieCategory { PattisserieId = 4, CategoryId = 4 },
                new PattisserieCategory { PattisserieId = 5, CategoryId = 2 },
                new PattisserieCategory { PattisserieId = 5, CategoryId = 5 },
                new PattisserieCategory { PattisserieId = 2, CategoryId = 4 },
                new PattisserieCategory { PattisserieId = 3, CategoryId = 2 },
                new PattisserieCategory { PattisserieId = 4, CategoryId = 3 }
            );
        }
    }
}
