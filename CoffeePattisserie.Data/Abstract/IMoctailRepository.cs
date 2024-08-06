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
        Task<Moctail> GetMoctailWithCategories(int id);
        Task<List<Moctail>> GetMoctailsByCategoryIdAsync (int categoryId);
        Task<Moctail> CreateMoctailWithCategories(Moctail moctail, List<int> categoryIds);
    }
}