using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CoffeePattisserie.Data.Abstract;
using CoffeePattisserie.Entity.Concrete;

namespace CoffeePattisserie.Data.Concrete.EfCore.Repositories
{
    public class EfCoreCoffeeRepository : EfCoreGenericRepository<Coffee>, ICoffeeRepository
    {
        public EfCoreCoffeeRepository(CoffeeAppDbContext coffeeAppDbContext): base(coffeeAppDbContext)
        {
            
        }
        private CoffeeAppDbContext Context
        {
            get{
                return _dbContext as CoffeeAppDbContext;
            }
        }
        public async Task<List<Coffee>> GetCoffeesByCategoryIdAsync(int categoryId)
        {
            List<Coffee> coffees = await Context
            .Coffees
            .Include(x=>x.CoffeCategories)
            .ThenInclude(y=>y.Category)
            .Where(x=>x.CoffeCategories.Any(y=>y.CategoryId==categoryId))
            .ToListAsync();
        }

        public async Task<List<Coffee>> GetCoffeesWithCategoriesAsync()
        {
            var coffees = await Context
            .Coffees
            .Include(x=>x.CoffeCategories)
            .ThenInclude(y => y.Category)
            .ToListAsync();
            return coffees;
        }
    }
}