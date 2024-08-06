using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CoffeePattisserie.Data.Abstract;
using CoffeePattisserie.Entity.Concrete;

namespace CoffeePattisserie.Data.Concrete.EfCore.Repositories
{
    public class EfCoreMoctailRepository : EfCoreGenericRepository<Moctail>, IMoctailRepository
    {
        public EfCoreMoctailRepository(CoffeeAppDbContext coffeeAppDbContext) : base(coffeeAppDbContext)
        {
        }

        private CoffeeAppDbContext Context
        {
            get
            {
                return _dbContext as CoffeeAppDbContext;
            }
        }

        public async Task<Moctail> CreateMoctailWithCategories(Moctail moctail, List<int> categoryIds)
        {
            var createdMoctail = await Context.Moctails.AddAsync(moctail);
            if (createdMoctail != null)
            {
                await Context.SaveChangesAsync();
                var moctailCategories = categoryIds
                    .Select(x => new MoctailCategory { MoctailId = moctail.Id, CategoryId = x })
                    .ToList();
                await Context.Set<MoctailCategory>().AddRangeAsync(moctailCategories);
                await Context.SaveChangesAsync();
            }
            var result = await GetMoctailWithCategories(moctail.Id);
            return result;
        }

        public async Task<List<Moctail>> GetMoctailsByCategoryIdAsync(int categoryId)
        {
            List<Moctail> moctails = await Context
                .Moctails.Include(x => x.MoctailCategories)
                .ThenInclude(y => y.Category)
                .Where(x => x.MoctailCategories.Any(y => y.CategoryId == categoryId))
                .ToListAsync();
            return moctails;
        }

        public async Task<List<Moctail>> GetMoctailsWithCategoriesAsync()
        {
            List<Moctail> moctails = await Context
                .Moctails.Include(x => x.MoctailCategories)
                .ThenInclude(y => y.Category)
                .ToListAsync();
            return moctails;
        }

        public async Task<Moctail> GetMoctailWithCategories(int id)
        {
            Moctail moctail = await Context
                .Moctails.Where(x => x.Id == id)
                .Include(x => x.MoctailCategories)
                .ThenInclude(y => y.Category)
                .FirstOrDefaultAsync();
            return moctail;
        }
    }
}