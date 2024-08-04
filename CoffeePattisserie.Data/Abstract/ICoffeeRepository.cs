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
        Task<Coffee> GetCoffeeWithCategories(int id);
        Task<List<Coffee>> GetCoffeesByCategoryIdAsync (int categoryId);
        Task<Coffee> CreateCoffeeWithCategories(Coffee coffee, List<int> categoryIds);
    }
}