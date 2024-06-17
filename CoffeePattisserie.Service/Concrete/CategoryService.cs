using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoffeePattisserie.Data.Abstract;
using CoffeePattisserie.Data.Concrete.EfCore.Repositories;
using CoffeePattisserie.Entity.Concrete;
using CoffeePattisserie.Service.Abstract;
using CoffeePattisserie.Shared.Dtos;
using CoffeePattisserie.Shared.ResponseDtos;

namespace CoffeePattisserie.Service.Concrete
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<Response<CategoryDto>> AddAsync(AddCategoryDto addCategoryDto)
        {
            Category category = new Category{
                Name=addCategoryDto.Name,
                Description=addCategoryDto.Description
            };
            Category createdCategory = await _categoryRepository.CreateAsync(category);
            if (createdCategory == null){
                return Response<CategoryDto>.Fail("Bu alan boş bırakılamaz." , 404);
            }
            CategoryDto categoryDto = new CategoryDto{
                Id=createdCategory.Id,
                Name=createdCategory.Name,
                CreatedDate=createdCategory.CreatedDate,
                ModifiedDate=createdCategory.ModifiedDate,
                IsActive=createdCategory.IsActive
            };
            return Response<CategoryDto>.Success(categoryDto,200);
        }

        public Task<Response<List<CategoryDto>>> GetActiveCategoriesAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Response<List<CategoryDto>>> GetAllAsync()
        {
            throw new NotImplementedException();
        }
    }
}