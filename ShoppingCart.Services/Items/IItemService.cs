using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShoppingCart.Dtos.Items;

namespace ShoppingCart.Services.Items
{
    public interface IItemService
    {
        Task<GetAllItemsResponseDto> GetAllItemsAsync();
        Task<SeachItemsResponseDto> SearchItemsAsync(SearchItemsRequestDto? requestDto);
    }
}
