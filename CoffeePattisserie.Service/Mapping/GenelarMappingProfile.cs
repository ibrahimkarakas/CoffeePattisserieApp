using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CoffeePattisserie.Entity.Concrete;
using CoffeePattisserie.Shared.Dtos;


namespace CoffeePattisserie.Service.Mapping
{
    public class GenelarMappingProfile:Profile
    {  
        public GenelarMappingProfile()
        {
            CreateMap<Category, CategoryDto>().ReverseMap();
            CreateMap<Category, AddCategoryDto>().ReverseMap();
            CreateMap<Category, EditCategoryDto>().ReverseMap();

            CreateMap<Coffee, AddCoffeeDto>().ReverseMap();
            CreateMap<Coffee, EditCoffeeDto>().ReverseMap();
            CreateMap<Coffee, CoffeeDto>().ReverseMap();
        }
        
    }
}