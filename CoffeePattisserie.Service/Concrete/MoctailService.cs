using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoffeePattisserie.Data.Abstract;
using AutoMapper;
using CoffeePattisserie.Data.Concrete.EfCore.Repositories;
using CoffeePattisserie.Entity.Concrete;
using CoffeePattisserie.Service.Abstract;
using CoffeePattisserie.Shared.Dtos;
using CoffeePattisserie.Shared.ResponseDtos;

namespace CoffeePattisserie.Service.Concrete
{
    public class MoctailService : IMoctailService
    {
        private readonly IMoctailRepository _moctailRepository;
        private readonly IMapper _mapper;

        public async Task<Response<MoctailDto>> AddAsync(AddMoctailDto addMoctailDto)
        {
           var moctail = _mapper.Map<Moctail>(addMoctailDto);
           var createdMoctail = await _moctailRepository.CreateAsync(moctail);
           if (createdMoctail == null)
           {
            return Response<MoctailDto>.Fail("Bir sorun oluştu.", 404);
           }
            var moctailDto = _mapper.Map<MoctailDto>(createdMoctail);
            return Response<MoctailDto>.Success(moctailDto, 201);

        }

        public async Task<Response<NoContent>> DeleteAsync(int id)
        {
            var moctail = await _moctailRepository.GetByIdAsync(id);
            if (moctail == null)
            {
                return Response<NoContent>.Fail("Böyle bir ürün bulunamadı.", 404);
            }
            await _moctailRepository.DeleteAsync(moctail);
            return Response<NoContent>.Success(200);
        }

        public async Task<Response<List<MoctailDto>>> GetAllAsync()
        {
         var moctails = await _moctailRepository.GetAllAsync();
         if (moctails.Count == 0)
         {
            return Response<List<MoctailDto>>.Fail("Hiç ürün bulunamadı.", 404);
         }
         var moctailDto = _mapper.Map<List<MoctailDto>>(moctails);
         return Response<List<MoctailDto>>.Success(moctailDto, 200);
        }

        public async Task<Response<MoctailDto>> GetByIdAsync(int id)
        {
            var moctail = await _moctailRepository.GetByIdAsync(id);
            if (moctail == null)
            {
                return Response<MoctailDto>.Fail("Böyle bir ürün bulunamadı.",404);
            }
            var moctailDto = _mapper.Map<MoctailDto>(moctail);
            return Response<MoctailDto>.Success(moctailDto, 200);
        }

        public async Task<Response<List<MoctailDto>>> GetMoctailsByCategoryIdAsync(int categoryId)
        {
            var moctails = await _moctailRepository.GetMoctailsByCategoryIdAsync(categoryId);
            if (moctails.Count == 0)
            {
                return Response<List<MoctailDto>>.Fail("Bu kategoride hiç ürün bulunamadı." , 404);
            }
            var moctailDtos = _mapper.Map<List<MoctailDto>>(moctails);
            return Response<List<MoctailDto>>.Success(moctailDtos, 200);
        }

        public async Task<Response<MoctailDto>> UpdateAsync(EditMoctailDto editMoctailDto)
        {
            var moctail = _mapper.Map<Moctail>(editMoctailDto);
            if (moctail == null)
            {
                return Response<MoctailDto>.Fail("Bir hata oluştu.", 400);
            }
            moctail.ModifiedDate=DateTime.Now;
            var updatedMoctail = await _moctailRepository.UpdateAsync(moctail);
            var moctailDto = _mapper.Map<MoctailDto>(updatedMoctail);
            return Response<MoctailDto>.Success(moctailDto,200);
        }

        public async Task<Response<List<MoctailDto>>> GetMoctailsWithCategoriesAsync()
        {
            var moctails = await _moctailRepository.GetMoctailsWithCategoriesAsync();
            if (moctails.Count == 0)
            {
                return Response<List<MoctailDto>>.Fail("Hiç ürün bulunamadı." , 404);
            }
            var moctailDtos = _mapper.Map<List<MoctailDto>>(moctails);
            return Response<List<MoctailDto>>.Success(moctailDtos,200);
        }
    }
}