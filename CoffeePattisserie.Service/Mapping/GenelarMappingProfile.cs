using System.Linq;
using AutoMapper;
using CoffeePattisserie.Entity.Concrete;
using CoffeePattisserie.Shared.Dtos;

namespace CoffeePattisserie.Service.Mapping
{
    public class GeneralMappingProfile : Profile
    {
        public GeneralMappingProfile()
        {
            // Category Mappings
            CreateMap<Category, CategoryDto>().ReverseMap();
            CreateMap<Category, AddCategoryDto>().ReverseMap();
            CreateMap<Category, EditCategoryDto>().ReverseMap();

            // Coffee Mappings
            CreateMap<Coffee, AddCoffeeDto>().ReverseMap();
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

            CreateMap<Pattisserie, AddPattisserieDto>().ReverseMap();
            CreateMap<Pattisserie, EditPattisserieDto>().ReverseMap();

            // Moctail Mappings
            CreateMap<Moctail, MoctailDto>()
                .ForMember(mdto => mdto.Categories, options =>
                    options.MapFrom(m =>
                        m.MoctailCategories.Select(mc => mc.Category)))
                .ReverseMap();

            CreateMap<Moctail, AddMoctailDto>().ReverseMap();
            CreateMap<Moctail, EditMoctailDto>().ReverseMap();

            // Cart Mappings
            CreateMap<Cart, CartDto>().ReverseMap();
            CreateMap<CartItem, CartItemDto>().ReverseMap();

            // Order Mappings
            CreateMap<Order, OrderDto>().ReverseMap();
            CreateMap<OrderItem, OrderItemDto>().ReverseMap();
        }
    }
}
