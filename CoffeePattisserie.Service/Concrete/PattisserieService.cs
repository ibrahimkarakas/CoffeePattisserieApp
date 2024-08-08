using System;
using System.Collections.Generic;
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
    public class PattisserieService : IPattisserieService
    {
        private readonly IPattisserieRepository _pattisserieRepository;
        private readonly IMapper _mapper;

        public PattisserieService(IPattisserieRepository pattisserieRepository, IMapper mapper)
        {
            _pattisserieRepository = pattisserieRepository;
            _mapper = mapper;
        }

        public async Task<Response<PattisserieDto>> AddAsync(AddPattisserieDto addPattisserieDto)
        {
            var pattisserie = _mapper.Map<Pattisserie>(addPattisserieDto);
            var createdPattisserie = await _pattisserieRepository.CreatePattisserieWithCategoriesAsync(pattisserie, addPattisserieDto.CategoryIds);
            if (createdPattisserie == null)
            {
                return Response<PattisserieDto>.Fail("Bir sorun oluştu", 404);
            }
            var pattisserieDto = _mapper.Map<PattisserieDto>(createdPattisserie);
            return Response<PattisserieDto>.Success(pattisserieDto, 201);
        }

        public async Task<Response<NoContent>> DeleteAsync(int id)
        {
            var pattisserie = await _pattisserieRepository.GetByIdAsync(id);
            if (pattisserie == null)
            {
                return Response<NoContent>.Fail("Böyle bir ürün bulunamadı.", 404);
            }
            await _pattisserieRepository.DeleteAsync(pattisserie);
            return Response<NoContent>.Success(200);
        }

        public async Task<Response<List<PattisserieDto>>> GetActivePattisserieAsync(bool isActive = true)
        {
            var pattisseries = await _pattisserieRepository.GetActivePattisserieAsync(isActive);
            if (pattisseries.Count == 0)
            {
                return Response<List<PattisserieDto>>.Fail("İstediğiniz kriterde ürün bulunamadı", 404);
            }
            var pattisserieDtos = _mapper.Map<List<PattisserieDto>>(pattisseries);
            return Response<List<PattisserieDto>>.Success(pattisserieDtos, 200);
        }

        public async Task<Response<List<PattisserieDto>>> GetAllAsync()
        {
            var pattisserie = await _pattisserieRepository.GetPattisserieWithCategoriesAsync();
            if (pattisserie.Count == 0)
            {
                return Response<List<PattisserieDto>>.Fail("Hiç ürün bulunamadı.", 404);
            }
            var pattisserieDto = _mapper.Map<List<PattisserieDto>>(pattisserie);
            return Response<List<PattisserieDto>>.Success(pattisserieDto, 200);
        }

        public async Task<Response<PattisserieDto>> GetByIdAsync(int id)
        {
            var pattisserie = await _pattisserieRepository.GetPattisserieWithCategoriesAsync(id);
            if (pattisserie == null)
            {
                return Response<PattisserieDto>.Fail("Böyle bir ürün bulunamadı.", 404);
            }
            var pattisserieDto = _mapper.Map<PattisserieDto>(pattisserie);
            return Response<PattisserieDto>.Success(pattisserieDto, 200);
        }

        public async Task<Response<List<PattisserieDto>>> GetPattisserieByCategoryIdAsync(int categoryId)
        {
            var pattisserie = await _pattisserieRepository.GetPattisserieByCategoryIdAsync(categoryId);
            if (pattisserie.Count == 0)
            {
                return Response<List<PattisserieDto>>.Fail("Bu kategoride ürün bulunamadı.", 404);
            }
            var pattisserieDto = _mapper.Map<List<PattisserieDto>>(pattisserie);
            return Response<List<PattisserieDto>>.Success(pattisserieDto, 200);
        }

        public async Task<Response<List<PattisserieDto>>> GetPattisserieWithCategoriesAsync()
        {
            var pattisserie = await _pattisserieRepository.GetPattisserieWithCategoriesAsync();
            if (pattisserie.Count == 0)
            {
                return Response<List<PattisserieDto>>.Fail("Hiç ürün bulunamadı", 404);
            }
            var pattisserieDto = _mapper.Map<List<PattisserieDto>>(pattisserie);
            return Response<List<PattisserieDto>>.Success(pattisserieDto, 200);
        }

        public async Task<Response<PattisserieDto>> UpdateAsync(EditPattisserieDto editPattisserieDto)
        {
            var pattisserie = _mapper.Map<Pattisserie>(editPattisserieDto);
            if (pattisserie == null)
            {
                return Response<PattisserieDto>.Fail("Bir hata oluştu.", 400);
            }
            pattisserie.ModifiedDate = DateTime.Now;
            var updatedPattisserie = await _pattisserieRepository.UpdateAsync(pattisserie);
            await _pattisserieRepository.ClearPattisserieCategoriesAsync(updatedPattisserie.Id);
            updatedPattisserie.PattisserieCategories = editPattisserieDto
                .CategoryIds
                .Select(categoryId => new PattisserieCategory
                {
                    PattisserieId = updatedPattisserie.Id,
                    CategoryId = categoryId
                }).ToList();
            await _pattisserieRepository.UpdateAsync(updatedPattisserie);
            var result = await _pattisserieRepository.GetPattisserieWithCategoriesAsync(updatedPattisserie.Id);
            var pattisserieDto = _mapper.Map<PattisserieDto>(result);
            return Response<PattisserieDto>.Success(pattisserieDto, 200);
        }

        public async Task<Response<List<PattisserieDto>>> GetHomePattisserieAsync()
        {
            var pattisserie = await _pattisserieRepository.GetHomePattisserieAsync();
            if (pattisserie.Count == 0)
            {
                return Response<List<PattisserieDto>>.Fail("İstediğiniz kriterde ürün bulunamadı", StatusCodes.Status404NotFound);
            }
            var pattisserieDto = _mapper.Map<List<PattisserieDto>>(pattisserie);
            return Response<List<PattisserieDto>>.Success(pattisserieDto, StatusCodes.Status200OK);
        }
    }
}
