using AutoMapper;
using ShoppingCart.Dtos.CartItems;
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
            CreateMap<Item, UpsertItemRequestDto>().ReverseMap();
            CreateMap<ItemImage, ItemImageDto>().ReverseMap();
            CreateMap<Category, UpsertCategoryRequestDto>().ReverseMap();
            CreateMap<CartItem, CartItemResponseDto>().ReverseMap();
        }
    }
}
