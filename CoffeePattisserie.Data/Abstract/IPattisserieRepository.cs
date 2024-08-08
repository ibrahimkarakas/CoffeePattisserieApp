using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoffeePattisserie.Entity.Concrete;

namespace CoffeePattisserie.Data.Abstract
{
    public interface IPattisserieRepository : IGenericRepository<Pattisserie>
    {
        Task<List<Pattisserie>> GetPattisserieWithCategoriesAsync();
        Task<Pattisserie> GetPattisserieWithCategoriesAsync(int id);
        Task<List<Pattisserie>> GetPattisserieByCategoryIdAsync(int categoryId);
        Task<Pattisserie> CreatePattisserieWithCategoriesAsync(Pattisserie pattisserie, List<int> categoryIds);
        Task ClearPattisserieCategoriesAsync(int pattisserieId);
        Task<List<Pattisserie>> GetActivePattisserieAsync(bool isActive);
        Task<int> GetCount(int? categoryId = null);
        Task<List<Pattisserie>> GetHomePattisserieAsync();
    }
}
