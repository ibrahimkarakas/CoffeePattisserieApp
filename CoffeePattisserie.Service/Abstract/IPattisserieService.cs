using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoffeePattisserie.Shared;
using CoffeePattisserie.Shared.Dtos;
using CoffeePattisserie.Shared.ResponseDtos;

namespace CoffeePattisserie.Service.Abstract
{
    public interface IPattisserieService{
        Task<Response<PattisserieDto>> AddAsync(AddPattisserieDto addPattisserieDto);
        Task<Response<List<PattisserieDto>>> GetAllAsync();
        Task<Response<List<PattisserieDto>>> GetPattisserieWithCategoriesAsync();
        Task<Response<List<PattisserieDto>>> GetPattisserieByCategoryIdAsync(int categoryId);
        Task<Response<PattisserieDto>> UpdateAsync(EditPattisserieDto editPattisserieDto);
        Task<Response<PattisserieDto>> GetByIdAsync (int id);
        Task<Response<NoContent>> DeleteAsync (int id);
        Task<Response<List<PattisserieDto>>> GetActivePattisserieAsync(bool isActive = true);

    }
}