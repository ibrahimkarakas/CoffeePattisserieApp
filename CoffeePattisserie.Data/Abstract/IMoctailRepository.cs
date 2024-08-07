using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoffeePattisserie.Entity.Concrete;

namespace CoffeePattisserie.Data.Abstract
{
    public interface IMoctailRepository: IGenericRepository<Moctail>
    {
        Task<List<Moctail>> GetMoctailsWithCategoriesAsync();
        Task<Moctail> GetMoctailWithCategoriesAsync(int id);
        Task<List<Moctail>> GetMoctailsByCategoryIdAsync (int categoryId);
        Task<Moctail> CreateMoctailWithCategoriesAsync(Moctail moctail, List<int> categoryIds);
        // Task<Coffee> UpdateMoctailWithCategoriesAsync(Coffee coffee, List<int> categoryIds);
        Task ClearMoctailCategoriesAsync(int moctailId);
        Task<List<Moctail>> GetActiveMoctailsAsync(bool isActive);
    }
}