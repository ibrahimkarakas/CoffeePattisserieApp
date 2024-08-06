using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CoffeePattisserie.Entity.Concrete;
using CoffeePattisserie.Shared.Dtos;

namespace CoffeePattisserie.Service.Mapping
{
    public class GenelarMappingProfile : Profile
    {
        public GenelarMappingProfile()
        {
            // Category Mappings
            CreateMap<Category, CategoryDto>().ReverseMap();
            CreateMap<Category, AddCategoryDto>().ReverseMap();
            CreateMap<Category, EditCategoryDto>().ReverseMap();

            // Coffee Mappings
            CreateMap<Coffee, AddCoffeeDto>()
                .ForMember(acdto => acdto.CategoryIds, options =>
                    options.MapFrom(c =>
                        c.CoffeeCategories.Select(cc => cc.CategoryId)))
                .ReverseMap();

            CreateMap<Coffee, EditCoffeeDto>().ReverseMap();

            CreateMap<Coffee, CoffeeDto>()
                .ForMember(cdto => cdto.Categories, options =>
                    options.MapFrom(c =>
                        c.CoffeeCategories.Select(cc => cc.Category)))
                .ReverseMap();

            // Pattisserie Mappings
            CreateMap<Pattisserie, PattisserieDto>()
                .ForMember(pdto => pdto.Categories, options =>
                    options.MapFrom(p =>
                        p.PattisserieCategories.Select(pc => pc.Category)))
                .ReverseMap();

            CreateMap<Pattisserie, AddPattisserieDto>()
                .ForMember(apdto => apdto.CategoryIds, options =>
                    options.MapFrom(p =>
                        p.PattisserieCategories.Select(pc => pc.CategoryId)))
                .ReverseMap();

            CreateMap<Pattisserie, EditPattisserieDto>().ReverseMap();

            // Moctail Mappings
            CreateMap<Moctail, MoctailDto>()
                .ForMember(mdto => mdto.Categories, options =>
                    options.MapFrom(m =>
                        m.MoctailCategories.Select(mc => mc.Category)))
                .ReverseMap();

            CreateMap<Moctail, AddMoctailDto>()
                .ForMember(amdto => amdto.CategoryIds, options =>
                    options.MapFrom(m =>
                        m.MoctailCategories.Select(mc => mc.CategoryId)))
                .ReverseMap();

            CreateMap<Moctail, EditMoctailDto>().ReverseMap();
        }
    }
}
