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
using Microsoft.AspNetCore.Http;

namespace CoffeePattisserie.Service.Concrete
{
    public class MoctailService : IMoctailService
    {
        private readonly IMoctailRepository _moctailRepository;
        private readonly IMapper _mapper;

        public MoctailService(IMoctailRepository moctailRepository, IMapper mapper)
        {
            _moctailRepository = moctailRepository;
            _mapper = mapper;
        }

        public async Task<Response<MoctailDto>> AddAsync(AddMoctailDto addMoctailDto)
        {
            var moctail = _mapper.Map<Moctail>(addMoctailDto);
            var createdMoctail = await _moctailRepository.CreateMoctailWithCategoriesAsync(moctail, addMoctailDto.CategoryIds);
            if (createdMoctail == null)
            {
                return Response<MoctailDto>.Fail("Bir sorun oluştu", 404);
            }
            var moctailDto = _mapper.Map<MoctailDto>(createdMoctail);
            return Response<MoctailDto>.Success(moctailDto, 201);
        }

        public async Task<Response<NoContent>> DeleteAsync(int id)
        {
            var moctail = await _moctailRepository.GetByIdAsync(id);
            if (moctail == null)
            {
                return Response<NoContent>.Fail("Böyle bir moctail bulunamadı", 404);
            }
            await _moctailRepository.DeleteAsync(moctail);
            return Response<NoContent>.Success(200);
        }

        public async Task<Response<List<MoctailDto>>> GetActiveMoctailsAsync(bool isActive = true)
        {
            List<Moctail> moctails = await _moctailRepository.GetActiveMoctailsAsync(isActive);
            if (moctails.Count == 0)
            {
                return Response<List<MoctailDto>>.Fail("İstediğiniz kriterde moctail bulunamadı", 404);
            }
            var moctailDtos = _mapper.Map<List<MoctailDto>>(moctails);
            return Response<List<MoctailDto>>.Success(moctailDtos, 200);
        }

        public async Task<Response<List<MoctailDto>>> GetAllAsync()
        {
            var moctails = await _moctailRepository.GetMoctailsWithCategoriesAsync();
            if (moctails.Count == 0)
            {
                return Response<List<MoctailDto>>.Fail("Hiç moctail bulunamadı", 404);
            }
            var moctailDtos = _mapper.Map<List<MoctailDto>>(moctails);
            return Response<List<MoctailDto>>.Success(moctailDtos, 200);
        }

        public async Task<Response<List<MoctailDto>>> GetMoctailsByCategoryIdAsync(int categoryId)
        {
            var moctails = await _moctailRepository.GetMoctailsByCategoryIdAsync(categoryId);
            if (moctails.Count == 0)
            {
                return Response<List<MoctailDto>>.Fail("Bu kategoride hiç moctail bulunamadı", 404);
            }
            var moctailDtos = _mapper.Map<List<MoctailDto>>(moctails);
            return Response<List<MoctailDto>>.Success(moctailDtos, 200);
        }

        public async Task<Response<List<MoctailDto>>> GetMoctailsWithCategoriesAsync()
        {
            var moctails = await _moctailRepository.GetMoctailsWithCategoriesAsync();
            if (moctails.Count == 0)
            {
                return Response<List<MoctailDto>>.Fail("Hiç moctail bulunamadı", 404);
            }
            var moctailDtos = _mapper.Map<List<MoctailDto>>(moctails);
            return Response<List<MoctailDto>>.Success(moctailDtos, 200);
        }

        public async Task<Response<MoctailDto>> GetByIdAsync(int id)
        {
            var moctail = await _moctailRepository.GetMoctailWithCategoriesAsync(id);
            if (moctail == null)
            {
                return Response<MoctailDto>.Fail("Böyle bir moctail bulunamadı", 404);
            }
            var moctailDto = _mapper.Map<MoctailDto>(moctail);
            return Response<MoctailDto>.Success(moctailDto, 200);
        }

        public async Task<Response<List<MoctailDto>>> GetHomeMoctailsAsync()
        {
            List<Moctail> moctails = await _moctailRepository.GetHomeMoctailsAsync();
            if (moctails.Count == 0)
            {
                return Response<List<MoctailDto>>.Fail("İstediğiniz kriterde moctail bulunamadı", StatusCodes.Status404NotFound);
            }
            var moctailDtos = _mapper.Map<List<MoctailDto>>(moctails);
            return Response<List<MoctailDto>>.Success(moctailDtos, StatusCodes.Status200OK);
        }

        public async Task<Response<MoctailDto>> UpdateAsync(EditMoctailDto editMoctailDto)
        {
            var moctail = _mapper.Map<Moctail>(editMoctailDto);
            if (moctail == null)
            {
                return Response<MoctailDto>.Fail("Bir hata oluştu", 400);
            }
            moctail.ModifiedDate = DateTime.Now;
            var updatedMoctail = await _moctailRepository.UpdateAsync(moctail);
            await _moctailRepository.ClearMoctailCategoriesAsync(updatedMoctail.Id);
            updatedMoctail.MoctailCategories = editMoctailDto
                .CategoryIds
                .Select(categoryId => new MoctailCategory
                {
                    MoctailId = updatedMoctail.Id,
                    CategoryId = categoryId
                }).ToList();
            await _moctailRepository.UpdateAsync(updatedMoctail);
            var result = await _moctailRepository.GetMoctailWithCategoriesAsync(updatedMoctail.Id);
            var moctailDto = _mapper.Map<MoctailDto>(result);
            return Response<MoctailDto>.Success(moctailDto, 200);
        }
    }
}
