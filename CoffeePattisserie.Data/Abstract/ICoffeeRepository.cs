using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoffeePattisserie.Entity.Concrete;

namespace CoffeePattisserie.Data.Abstract
{
    public interface ICoffeeRepository: IGenericRepository<Coffee>
    {
        Task<List<Coffee>> GetCoffeesWithCategoriesAsync();
        Task<Coffee> GetCoffeeWithCategoriesAsync(int id);
        Task<List<Coffee>> GetCoffeesByCategoryIdAsync (int categoryId);
        Task<Coffee> CreateCoffeeWithCategoriesAsync(Coffee coffee, List<int> categoryIds);
        // Task<Coffee> UpdateCoffeeWithCategoriesAsync(Coffee coffee, List<int> categoryIds);
        Task ClearCoffeeCategoriesAsync(int coffeeId);
        Task<List<Coffee>> GetActiveCoffeesAsync(bool isActive);
    }
}