using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShoppingCart.Dtos.Items;

namespace ShoppingCart.Services.Items
{
    public interface IItemsService
    {
        Task<GetAllItemsResponseDto> GetAllItemsAsync();
        Task<SeachItemsResponseDto> SearchItemsAsync(SearchItemsRequestDto? requestDto);
        Task<GetItemResponseDto> GetItemAsync(long id);
        Task<UpsertItemResponseDto> UpsertItemAsync(long id, UpsertItemRequestDto item);
    }
}
