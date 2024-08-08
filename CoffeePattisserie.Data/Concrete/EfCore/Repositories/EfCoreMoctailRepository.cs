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
        public EfCoreMoctailRepository(CoffeeAppDbContext coffeeAppDbContext)
            : base(coffeeAppDbContext) { }

        private CoffeeAppDbContext Context
        {
            get { return _dbContext as CoffeeAppDbContext; }
        }

        public async Task ClearMoctailCategoriesAsync(int moctailId)
        {
            List<MoctailCategory> moctailCategories = await Context
                .MoctailCategories
                .Where(mc => mc.MoctailId == moctailId)
                .ToListAsync();
            Context.MoctailCategories.RemoveRange(moctailCategories);
            await Context.SaveChangesAsync();
        }

        public async Task<Moctail> CreateMoctailWithCategoriesAsync(Moctail moctail, List<int> categoryIds)
        {
            var createdMoctail = await Context.Moctails.AddAsync(moctail);
            if (createdMoctail != null)
            {
                await Context.SaveChangesAsync();
                var moctailCategories = categoryIds
                    .Select(x => new MoctailCategory { MoctailId = moctail.Id, CategoryId = x })
                    .ToList();
                await Context.MoctailCategories.AddRangeAsync(moctailCategories);
                await Context.SaveChangesAsync();
            }
            var result = await GetMoctailWithCategoriesAsync(moctail.Id);
            return result;
        }

        public async Task<List<Moctail>> GetActiveMoctailsAsync(bool isActive)
        {
            List<Moctail> moctails = await Context
                .Moctails
                .Where(m => m.IsActive == isActive)
                .Include(m => m.MoctailCategories)
                .ThenInclude(mc => mc.Category)
                .ToListAsync();
            return moctails;
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
                .Moctails
                .Include(x => x.MoctailCategories)
                .ThenInclude(y => y.Category)
                .ToListAsync();
            return moctails;
        }

        public async Task<Moctail> GetMoctailWithCategoriesAsync(int id)
        {
            Moctail moctail = await Context
                .Moctails.Where(x => x.Id == id)
                .Include(x => x.MoctailCategories)
                .ThenInclude(y => y.Category)
                .FirstOrDefaultAsync();
            return moctail;
        }

        public async Task<int> GetCount(int? categoryId = null)
        {
            int count = 0;
            if (categoryId == null)
            {
                count = await Context.Moctails.CountAsync();
            }
            else
            {
                var moctailCategoryList = await Context.MoctailCategories.ToListAsync();
                foreach (var mc in moctailCategoryList)
                {
                    if (mc.CategoryId == categoryId)
                    {
                        count++;
                    }
                }
            }
            return count;
        }

        public async Task<List<Moctail>> GetHomeMoctailsAsync()
        {
            List<Moctail> moctails = await Context
                .Moctails
                .Where(m => m.IsActive && m.IsHome)
                .Include(m => m.MoctailCategories)
                .ThenInclude(mc => mc.Category)
                .ToListAsync();
            return moctails;
        }
    }
}
