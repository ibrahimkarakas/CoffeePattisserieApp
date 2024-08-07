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
        public EfCoreCoffeeRepository(CoffeeAppDbContext coffeeAppDbContext) : base(coffeeAppDbContext)
        {
        }

        private CoffeeAppDbContext Context
        {
            get
            {
                return _dbContext as CoffeeAppDbContext;
            }
        }

        public async Task ClearCoffeeCategoriesAsync(int coffeeId)
        {
            List<CoffeeCategory> coffeeCategories = await Context
                .CoffeeCategories
                .Where(cc => cc.CoffeeId == coffeeId)
                .ToListAsync();
            Context.CoffeeCategories.RemoveRange(coffeeCategories);
            await Context.SaveChangesAsync();
        }

        public async Task<Coffee> CreateCoffeeWithCategoriesAsync(Coffee coffee, List<int> categoryIds)
        {
            var createdCoffee = await Context.Coffees.AddAsync(coffee);
            if (createdCoffee != null)
            {
                await Context.SaveChangesAsync();
                var coffeeCategories = categoryIds
                    .Select(x => new CoffeeCategory { CoffeeId = coffee.Id, CategoryId = x })
                    .ToList();
                await Context.CoffeeCategories.AddRangeAsync(coffeeCategories);
                await Context.SaveChangesAsync();
            }
            var result = await GetCoffeeWithCategoriesAsync(coffee.Id);
            return result;
        }

        public async Task<List<Coffee>> GetActiveCoffeesAsync(bool isActive)
        {
            List<Coffee> coffees = await Context
                .Coffees
                .Where(c => c.IsActive == isActive)
                .Include(c => c.CoffeeCategories)
                .ThenInclude(cc => cc.Category)
                .ToListAsync();
            return coffees;
        }

        public async Task<List<Coffee>> GetCoffeesByCategoryIdAsync(int categoryId)
        {
            List<Coffee> coffees = await Context
                .Coffees.Include(x => x.CoffeeCategories)
                .ThenInclude(y => y.Category)
                .Where(x => x.CoffeeCategories.Any(y => y.CategoryId == categoryId))
                .ToListAsync();
            return coffees;
        }

        public async Task<List<Coffee>> GetCoffeesWithCategoriesAsync()
        {
            List<Coffee> coffees = await Context
                .Coffees.Include(x => x.CoffeeCategories)
                .ThenInclude(y => y.Category)
                .ToListAsync();
            return coffees;
        }

        public async Task<Coffee> GetCoffeeWithCategoriesAsync(int id)
        {
            Coffee coffee = await Context
                .Coffees.Where(x => x.Id == id)
                .Include(x => x.CoffeeCategories)
                .ThenInclude(y => y.Category)
                .FirstOrDefaultAsync();
            return coffee;
        }
    }
}
