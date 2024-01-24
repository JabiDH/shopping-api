using AutoMapper;
using ShoppingCart.Dtos.Categories;
using ShoppingCart.Dtos.Items;
using ShoppingCart.Models.DataModels;

namespace ShoppingCart.Services.Mappings
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Item, ItemDto>().ReverseMap();
            CreateMap<Category, CategoryDto>().ReverseMap();
        }
    }
}
