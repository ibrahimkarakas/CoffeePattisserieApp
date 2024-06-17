using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoffeePattisserie.Shared;
using CoffeePattisserie.Shared.Dtos;
using CoffeePattisserie.Shared.ResponseDtos;

namespace CoffeePattisserie.Service.Abstract
{
    public interface ICategoryService
    {
        Task<Response<CategoryDto>> AddAsync(AddCategoryDto addCategoryDto);
        Task<Response<List<CategoryDto>>> GetAllAsync();
        Task<Response<List<CategoryDto>>> GetActiveCategoriesAsync();
    }
}