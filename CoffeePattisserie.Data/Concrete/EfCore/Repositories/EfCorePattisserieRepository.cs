using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CoffeePattisserie.Data.Abstract;
using CoffeePattisserie.Entity.Concrete;

namespace CoffeePattisserie.Data.Concrete.EfCore.Repositories
{
    public class EfCorePattisserieRepository : EfCoreGenericRepository<Pattisserie>, IPattisserieRepository
    {
        public EfCorePattisserieRepository(CoffeeAppDbContext coffeeAppDbContext) : base(coffeeAppDbContext)
        {
        }

        private CoffeeAppDbContext Context
        {
            get
            {
                return _dbContext as CoffeeAppDbContext;
            }
        }

        public async Task<Pattisserie> CreatePattisserieWithCategories(Pattisserie pattisserie, List<int> categoryIds)
        {
            var createdPattisserie = await Context.Pattisserie.AddAsync(pattisserie);
            if (createdPattisserie != null)
            {
                await Context.SaveChangesAsync();
                var pattisserieCategories = categoryIds
                    .Select(x => new PattisserieCategory { PattisserieId = pattisserie.Id, CategoryId = x })
                    .ToList();
                await Context.Set<PattisserieCategory>().AddRangeAsync(pattisserieCategories);
                await Context.SaveChangesAsync();
            }
            var result = await GetPattisserieWithCategories(pattisserie.Id);
            return result;
        }

        public async Task<List<Pattisserie>> GetPattisserieByCategoryIdAsync(int categoryId)
        {
            List<Pattisserie> pattisseries = await Context
                .Pattisserie.Include(x => x.PattisserieCategories)
                .ThenInclude(y => y.Category)
                .Where(x => x.PattisserieCategories.Any(y => y.CategoryId == categoryId))
                .ToListAsync();
            return pattisseries;
        }

        public async Task<Pattisserie> GetPattisserieWithCategories(int id)
        {
            Pattisserie pattisserie = await Context
                .Pattisserie.Where(x => x.Id == id)
                .Include(x => x.PattisserieCategories)
                .ThenInclude(y => y.Category)
                .FirstOrDefaultAsync();
            return pattisserie;
        }

        public async Task<List<Pattisserie>> GetPattisserieWithCategoriesAsync()
        {
            List<Pattisserie> pattisseries = await Context
                .Pattisserie.Include(x => x.PattisserieCategories)
                .ThenInclude(y => y.Category)
                .ToListAsync();
            return pattisseries;
        }
    }
}
