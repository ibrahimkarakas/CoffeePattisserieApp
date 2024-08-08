using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CoffeePattisserie.Data.Abstract;
using CoffeePattisserie.Entity.Concrete;
using CoffeePattisserie.Service.Abstract;
using CoffeePattisserie.Shared.Dtos;
using CoffeePattisserie.Shared.ResponseDtos;

namespace CoffeePattisserie.Service.Concrete
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly ICoffeeRepository _coffeeRepository;
        private readonly IMapper _mapper;

        public CategoryService(ICategoryRepository categoryRepository, IMapper mapper, ICoffeeRepository coffeeRepository)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
            _coffeeRepository = coffeeRepository;
        }

        public async Task<Response<CategoryDto>> AddAsync(AddCategoryDto addCategoryDto)
        {
            Category category = _mapper.Map<Category>(addCategoryDto);
            Category createdCategory = await _categoryRepository.CreateAsync(category);
            if(createdCategory == null)
            {
                return Response<CategoryDto>.Fail("Veri tabanına kayıt işlemi sırasında bir sorun oluştu", 404);
            }  
            CategoryDto categoryDto = _mapper.Map<CategoryDto>(createdCategory);
            return Response<CategoryDto>.Success(categoryDto, 201);
        }

        public async Task<Response<NoContent>> DeleteAsync(int id)
        {
            Category deletedCategory = await _categoryRepository.GetByIdAsync(id);
            if (deletedCategory == null)
            {
                return Response<NoContent>.Fail("Böyle bir kategori bulunamadı", 404);
            }
            await _categoryRepository.DeleteAsync(deletedCategory);
            return Response<NoContent>.Success(200);
        }

        public async Task<Response<List<CategoryDto>>> GetActiveCategoriesAsync()
        {
            var categories = await _categoryRepository.GetActiveCategoriesAsync();
            if(categories.Count == 0)
            {
                return Response<List<CategoryDto>>.Fail("Hiç aktif kategori bulunamadı", 404);
            }
            var categoryDtoList = _mapper.Map<List<CategoryDto>>(categories);
            return Response<List<CategoryDto>>.Success(categoryDtoList, 200);
        }

        public async Task<Response<List<CategoryDto>>> GetAllAsync()
        {
            var categories = await _categoryRepository.GetAllAsync();
            if(categories.Count == 0)
            {
                return Response<List<CategoryDto>>.Fail("Hiç kategori bulunamadı", 404);
            }
            var categoryDtoList = _mapper.Map<List<CategoryDto>>(categories);
            return Response<List<CategoryDto>>.Success(categoryDtoList, 200);
        }

        public async Task<Response<CategoryDto>> GetByIdAsync(int id)
        {
            var category = await _categoryRepository.GetByIdAsync(id);
            if(category == null)
            {
                return Response<CategoryDto>.Fail("Bu id'li kategori bulunamadı", 404);
            }
            CategoryDto categoryDto = _mapper.Map<CategoryDto>(category);
            return Response<CategoryDto>.Success(categoryDto, 200);
        }

        public async Task<Response<List<CategoryDto>>> GetHomeCategoriesAsync()
        {
            var categories = await _categoryRepository.GetHomeCategoriesAsync();
            if(categories.Count == 0)
            {
                return Response<List<CategoryDto>>.Fail("Hiç ana sayfa kategori bulunamadı", 404);
            }
            var categoryDtoList = _mapper.Map<List<CategoryDto>>(categories);
            foreach (var categoryDto in categoryDtoList)
            {
                categoryDto.CountOfProducts = await _coffeeRepository.GetCount(categoryDto.Id); 
            }
            return Response<List<CategoryDto>>.Success(categoryDtoList, 200);
        }

        public async Task<Response<CategoryDto>> UpdateAsync(EditCategoryDto editCategoryDto)
        {
            var editedCategory = _mapper.Map<Category>(editCategoryDto);
            if(editedCategory == null)
            {
                return Response<CategoryDto>.Fail("Bir hata oluştu", 404);
            }
            editedCategory.ModifiedDate = DateTime.Now;
            await _categoryRepository.UpdateAsync(editedCategory);
            var categoryDto = _mapper.Map<CategoryDto>(editedCategory);
            return Response<CategoryDto>.Success(categoryDto, 200);
        }
    }
}
