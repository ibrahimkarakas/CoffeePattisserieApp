using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CoffeePattisserie.Data.Abstract;
using AutoMapper;
using CoffeePattisserie.Entity.Concrete;
using CoffeePattisserie.Service.Abstract;
using CoffeePattisserie.Shared.Dtos;
using CoffeePattisserie.Shared.ResponseDtos;

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
            var createdPattisserie = await _pattisserieRepository.CreateAsync(pattisserie);
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

        public async Task<Response<List<PattisserieDto>>> GetAllAsync()
        {
            var pattisserie = await _pattisserieRepository.GetAllAsync();
            if (pattisserie.Count == 0)
            {
                return Response<List<PattisserieDto>>.Fail("Hiç ürün bulunamadı.", 404);
            }
            var pattisserieDto = _mapper.Map<List<PattisserieDto>>(pattisserie);
            return Response<List<PattisserieDto>>.Success(pattisserieDto, 200);
        }

        public async Task<Response<PattisserieDto>> GetByIdAsync(int id)
        {
            var pattisserie = await _pattisserieRepository.GetByIdAsync(id);
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
            var pattisserieDto = _mapper.Map<PattisserieDto>(updatedPattisserie);
            return Response<PattisserieDto>.Success(pattisserieDto, 200);
        }
    }
}
