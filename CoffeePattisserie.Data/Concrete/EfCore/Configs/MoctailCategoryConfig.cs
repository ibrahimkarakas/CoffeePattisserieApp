using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using CoffeePattisserie.Entity.Concrete;

namespace CoffeePattisserie.Data.Concrete.EfCore.Configs
{
    public class MoctailCategoryConfig : IEntityTypeConfiguration<MoctailCategory>
    {
        public void Configure(EntityTypeBuilder<MoctailCategory> builder)
        {
            builder.HasKey(mc => new { mc.MoctailId, mc.CategoryId });
            builder.ToTable("MoctailCategories");

            builder.HasData(
                new MoctailCategory { MoctailId = 1, CategoryId = 1 },
                new MoctailCategory { MoctailId = 1, CategoryId = 2 },
                new MoctailCategory { MoctailId = 2, CategoryId = 3 },
                new MoctailCategory { MoctailId = 3, CategoryId = 1 },
                new MoctailCategory { MoctailId = 3, CategoryId = 2 },
                new MoctailCategory { MoctailId = 4, CategoryId = 4 },
                new MoctailCategory { MoctailId = 5, CategoryId = 3 },
                new MoctailCategory { MoctailId = 6, CategoryId = 5 }
            );
        }
    }
}
