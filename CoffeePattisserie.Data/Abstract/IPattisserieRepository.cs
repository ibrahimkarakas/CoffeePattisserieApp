using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoffeePattisserie.Entity.Concrete;

namespace CoffeePattisserie.Data.Abstract
{
    public interface IPattisserieRepository: IGenericRepository<Pattisserie>
    {
        Task<List<Pattisserie>> GetPattisserieWithCategoriesAsync();
        Task<Pattisserie> GetPattisserieWithCategories(int id);
        Task<List<Pattisserie>> GetPattisserieByCategoryIdAsync (int categoryId);
        Task<Pattisserie> CreatePattisserieWithCategories(Pattisserie pattisserie, List<int> categoryIds);
    }
}