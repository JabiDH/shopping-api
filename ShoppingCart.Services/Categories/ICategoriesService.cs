using ShoppingCart.Dtos.Categories;
using ShoppingCart.Dtos.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCart.Services.Categories
{
    public interface ICategoriesService
    {
        Task<GetAllCategoriesResponseDto> GetAllCategoriesAsync();
        Task<GetCategoryResponseDto> GetCategoryAsync(long id);
        Task<UpsertCategoryResponseDto> UpsertCategoryAsync(long id, UpsertCategoryRequestDto request);
        Task<DeleteCategoryResponseDto> DeleteCategoryAsync(long id);

    }
}
