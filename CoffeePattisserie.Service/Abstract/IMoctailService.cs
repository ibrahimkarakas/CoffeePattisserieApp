using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoffeePattisserie.Shared.Dtos;
using CoffeePattisserie.Shared.ResponseDtos;

namespace CoffeePattisserie.Service.Abstract
{
    public interface IMoctailService
    {
        Task<Response<MoctailDto>> AddAsync(AddMoctailDto addMoctailDto);
        Task<Response<List<MoctailDto>>> GetAllAsync();
        Task<Response<List<MoctailDto>>> GetMoctailsWithCategoriesAsync();
        Task<Response<List<MoctailDto>>> GetMoctailsByCategoryIdAsync(int categoryId);
        Task<Response<MoctailDto>> GetByIdAsync(int id);
        Task<Response<MoctailDto>> UpdateAsync(EditMoctailDto editMoctailDto);
        Task<Response<NoContent>> DeleteAsync(int id);
        Task<Response<List<MoctailDto>>> GetActiveMoctailsAsync(bool isActive = true);
        Task<Response<List<MoctailDto>>> GetHomeMoctailsAsync();
    }
}
