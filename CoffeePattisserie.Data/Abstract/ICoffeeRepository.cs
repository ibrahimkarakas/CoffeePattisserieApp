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
        Task<List<Coffee>> GetCoffeesByCategoryIdAsync();
    }
}