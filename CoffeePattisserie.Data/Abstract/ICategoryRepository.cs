using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoffeePattisserie.Entity.Concrete;

namespace CoffeePattisserie.Data.Abstract
{
    public interface ICategoryRepository:IGenericRepository<Category>
    {
        Task<List<Category>> GetActiveCategoriesAsync();
        Task<List<Category>> GetHomeCategoriesAsync();
    }
}