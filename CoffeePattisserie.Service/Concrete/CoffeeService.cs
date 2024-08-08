using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoffeePattisserie.Data.Abstract;
using AutoMapper;
using CoffeePattisserie.Entity.Concrete;
using CoffeePattisserie.Service.Abstract;
using CoffeePattisserie.Shared.Dtos;
using CoffeePattisserie.Shared.ResponseDtos;
using Microsoft.AspNetCore.Http;

namespace CoffeePattisserie.Service.Concrete
{
    public class CoffeeService : ICoffeeService
    {
        private readonly ICoffeeRepository _coffeeRepository;
        private readonly IMapper _mapper;

        public CoffeeService(ICoffeeRepository coffeeRepository, IMapper mapper)
        {
            _coffeeRepository = coffeeRepository;
            _mapper = mapper;
        }

        public async Task<Response<CoffeeDto>> AddAsync(AddCoffeeDto addCoffeeDto)
        {
            var coffee = _mapper.Map<Coffee>(addCoffeeDto);
            var createdCoffee = await _coffeeRepository.CreateCoffeeWithCategoriesAsync(coffee, addCoffeeDto.CategoryIds);
            if (createdCoffee == null)
            {
                return Response<CoffeeDto>.Fail("Bir sorun oluştu.", 404);
            }
            var coffeeDto = _mapper.Map<CoffeeDto>(createdCoffee);
            return Response<CoffeeDto>.Success(coffeeDto, 201);
        }

        public async Task<Response<NoContent>> DeleteAsync(int id)
        {
            var coffee = await _coffeeRepository.GetByIdAsync(id);
            if (coffee == null)
            {
                return Response<NoContent>.Fail("Böyle bir ürün bulunamadı.", 404);
            }
            await _coffeeRepository.DeleteAsync(coffee);
            return Response<NoContent>.Success(200);
        }

        public async Task<Response<List<CoffeeDto>>> GetActiveCoffeesAsync(bool isActive = true)
        {
            var coffees = await _coffeeRepository.GetActiveCoffeesAsync(isActive);
            if (coffees.Count == 0)
            {
                return Response<List<CoffeeDto>>.Fail("İstediğiniz kriterde ürün bulunamadı", 404);
            }
            var coffeeDtos = _mapper.Map<List<CoffeeDto>>(coffees);
            return Response<List<CoffeeDto>>.Success(coffeeDtos, 200);
        }

        public async Task<Response<List<CoffeeDto>>> GetAllAsync()
        {
            var coffees = await _coffeeRepository.GetCoffeesWithCategoriesAsync();
            if (coffees.Count == 0)
            {
                return Response<List<CoffeeDto>>.Fail("Hiç ürün bulunamadı.", 404);
            }
            var coffeeDtos = _mapper.Map<List<CoffeeDto>>(coffees);
            return Response<List<CoffeeDto>>.Success(coffeeDtos, 200);
        }

        public async Task<Response<CoffeeDto>> GetByIdAsync(int id)
        {
            var coffee = await _coffeeRepository.GetCoffeeWithCategoriesAsync(id);
            if (coffee == null)
            {
                return Response<CoffeeDto>.Fail("Böyle bir ürün bulunamadı", 404);
            }
            var coffeeDto = _mapper.Map<CoffeeDto>(coffee);
            return Response<CoffeeDto>.Success(coffeeDto, 200);
        }

        public async Task<Response<List<CoffeeDto>>> GetCoffeesByCategoryIdAsync(int categoryId)
        {
            var coffees = await _coffeeRepository.GetCoffeesByCategoryIdAsync(categoryId);
            if (coffees.Count == 0)
            {
                return Response<List<CoffeeDto>>.Fail("Bu kategoride hiç ürün bulunamadı.", 404);
            }
            var coffeeDtos = _mapper.Map<List<CoffeeDto>>(coffees);
            return Response<List<CoffeeDto>>.Success(coffeeDtos, 200);
        }

        public async Task<Response<List<CoffeeDto>>> GetCoffeesWithCategoriesAsync()
        {
            var coffees = await _coffeeRepository.GetCoffeesWithCategoriesAsync();
            if (coffees.Count == 0)
            {
                return Response<List<CoffeeDto>>.Fail("Hiç ürün bulunamadı.", 404);
            }
            var coffeeDtos = _mapper.Map<List<CoffeeDto>>(coffees);
            return Response<List<CoffeeDto>>.Success(coffeeDtos, 200);
        }

        public async Task<Response<CoffeeDto>> UpdateAsync(EditCoffeeDto editCoffeeDto)
        {
            var coffee = _mapper.Map<Coffee>(editCoffeeDto);
            if (coffee == null)
            {
                return Response<CoffeeDto>.Fail("Bir hata oluştu.", 400);
            }
            coffee.ModifiedDate = DateTime.Now;
            var updatedCoffee = await _coffeeRepository.UpdateAsync(coffee);
            await _coffeeRepository.ClearCoffeeCategoriesAsync(updatedCoffee.Id);
            updatedCoffee.CoffeeCategories = editCoffeeDto
                .CategoryIds
                .Select(categoryId => new CoffeeCategory
                {
                    CoffeeId = updatedCoffee.Id,
                    CategoryId = categoryId
                }).ToList();
            await _coffeeRepository.UpdateAsync(updatedCoffee);
            var result = await _coffeeRepository.GetCoffeeWithCategoriesAsync(updatedCoffee.Id);
            var coffeeDto = _mapper.Map<CoffeeDto>(result);
            return Response<CoffeeDto>.Success(coffeeDto, 200);
        }

        public async Task<Response<List<CoffeeDto>>> GetHomeCoffeesAsync()
        {
            var coffees = await _coffeeRepository.GetHomeCoffeesAsync();
            if (coffees.Count == 0)
            {
                return Response<List<CoffeeDto>>.Fail("İstediğiniz kriterde ürün bulunamadı", StatusCodes.Status404NotFound);
            }
            var coffeeDtos = _mapper.Map<List<CoffeeDto>>(coffees);
            return Response<List<CoffeeDto>>.Success(coffeeDtos, StatusCodes.Status200OK);
        }
    }
}
