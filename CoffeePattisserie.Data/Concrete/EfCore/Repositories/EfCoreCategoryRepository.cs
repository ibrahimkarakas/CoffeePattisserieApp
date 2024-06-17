using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CoffeePattisserie.Data.Abstract;
using CoffeePattisserie.Entity.Concrete;

namespace CoffeePattisserie.Data.Concrete.EfCore.Repositories
{
    public class EfCoreCategoryRepository : EfCoreGenericRepository<Category>, ICategoryRepository
    {
        public EfCoreCategoryRepository(CoffeeAppDbContext coffeeAppDbContext):base (coffeeAppDbContext)
        {
            
        }
        private CoffeeAppDbContext Context{get{return _dbContext as CoffeeAppDbContext;}}
        public async Task<List<Category>> GetActiveCategoriesAsync()
        {
           List<Category> categories = await Context.Categories.Where(c=>c.IsActive).ToListAsync();
           return categories;
        }
    }
}