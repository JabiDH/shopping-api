using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ShoppingCart.Data.Contexts;
using ShoppingCart.Dtos.Enums;
using ShoppingCart.Dtos.Items;
using ShoppingCart.Models.DataModels;

namespace ShoppingCart.Services.Items
{
    public class ItemService : IItemService
    {
        private readonly ShoppingCartDbContext dbContext;
        private readonly IMapper mapper;

        public ItemService(ShoppingCartDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        public async Task<GetAllItemsResponseDto> GetAllItemsAsync()
        {
            return new GetAllItemsResponseDto 
            {
                Items = await GetItemsAsync()                
            };
        }

        public async Task<SeachItemsResponseDto> SearchItemsAsync(SearchItemsRequestDto? requestDto)
        {
            return new SeachItemsResponseDto()
            {
                Items = await GetItemsAsync(requestDto)
            };
        }

        private async Task<List<ItemDto>> GetItemsAsync(SearchItemsRequestDto? requestDto = null)
        {
            var itemsDtos = dbContext
                .Items
                .Include(i => i.Category)
                .AsQueryable();

            if (requestDto != null)
            {
                itemsDtos = GetFilteredItems(itemsDtos, requestDto.FilterOn, requestDto.FilterQuery);

                itemsDtos = GetSortedItems(itemsDtos, requestDto.SortBy, requestDto.IsAscending);

                itemsDtos = GetPagedItems(itemsDtos, requestDto.PageNo, requestDto.PageSize);                
            }

           return await itemsDtos
                .Select(m => mapper.Map<ItemDto>(m))
                .ToListAsync();
        }

        private IQueryable<Item> GetFilteredItems(IQueryable<Item> itemsDtos, string? filterOn, string? filterQuery)
        {
            // Filtering
            if (!string.IsNullOrWhiteSpace(filterOn) && !string.IsNullOrWhiteSpace(filterQuery))
            {
                FilterOn filterOnEnum = Enum.Parse<FilterOn>(filterOn, true);
                switch (filterOnEnum)
                {
                    case FilterOn.Name:
                        itemsDtos = itemsDtos
                            .Where(i => string.Equals(i.Name.ToLower(), filterQuery.ToLower()));
                        break;
                    case FilterOn.Category:
                        itemsDtos = itemsDtos
                            .Where(i => string.Equals(i.Category.Name.ToLower(), filterQuery.ToLower()));
                        break;
                    default:
                        break;
                }
            }
            return itemsDtos;
        }

        private IQueryable<Item> GetSortedItems(IQueryable<Item> itemsDtos, string? sortBy, bool? isAscending)
        {
            // Sorting
            if (sortBy != null && isAscending != null)
            {
                SortBy sortByEnum = Enum.Parse<SortBy>(sortBy, true);
                switch (sortByEnum)
                {
                    case SortBy.Name:
                        itemsDtos = (bool)isAscending ?
                            itemsDtos.OrderBy(i => i.Name) :
                            itemsDtos.OrderByDescending(i => i.Name);
                        break;
                    case SortBy.Category:
                        itemsDtos = (bool)isAscending ?
                            itemsDtos.OrderBy(i => i.Category.Name) :
                            itemsDtos.OrderByDescending(i => i.Category.Name);
                        break;
                    case SortBy.None:
                    default:
                        break;
                }
            }
            return itemsDtos;
        }
        
        private IQueryable<Item> GetPagedItems(IQueryable<Item> itemsDtos, int pageNumber, int pageSize)
        {

            var number = pageNumber <= 0 ? 1 : pageNumber;
            var size = pageSize <= 0 ? 10 : pageSize;

            var skipCount = (number - 1) * size;

            return itemsDtos.Skip(skipCount).Take(size);
        }

    }

}
