using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoffeePattisserie.Shared;
using CoffeePattisserie.Shared.Dtos;
using CoffeePattisserie.Shared.ResponseDtos;

namespace CoffeePattisserie.Service.Abstract
{
    public interface ICoffeeService
    {
        Task<Response<CoffeeDto>> AddAsync(AddCoffeeDto addCoffeeDto);
        Task<Response<List<CoffeeDto>>> GetAllAsync();
        Task<Response<List<CoffeeDto>>> GetCoffeesWithCategoriesAsync();
        Task<Response<List<CoffeeDto>>> GetCoffeesByCategoryIdAsync(int categoryId);
        Task<Response<CoffeeDto>> UpdateAsync(EditCoffeeDto editCoffeeDto);
        Task<Response<CoffeeDto>> GetByIdAsync (int id);
        Task<Response<NoContent>> DeleteAsync (int id);

        


    }
}