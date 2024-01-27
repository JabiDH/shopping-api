using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ShoppingCart.Data.Contexts;
using ShoppingCart.Dtos.Enums;
using ShoppingCart.Dtos.Items;
using ShoppingCart.Models.DataModels;

namespace ShoppingCart.Services.Items
{
    public class ItemsService : IItemsService
    {
        private readonly ShoppingCartDbContext dbContext;
        private readonly IMapper mapper;

        public ItemsService(ShoppingCartDbContext dbContext, IMapper mapper)
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

        public async Task<GetItemResponseDto> GetItemAsync(long id)
        {
            var responseDto = new GetItemResponseDto();
            var itemDto = await dbContext.Items
                .Include(i => i.Category)
                .Include(i => i.Images)
                .SingleOrDefaultAsync(x => x.Id == id);
            
            if (itemDto == null)
            {
                responseDto.Error = "No item found.";
                return responseDto;
            }

            responseDto.Item = mapper.Map<ItemDto>(itemDto);
            return responseDto;
        }

        public async Task<UpsertItemResponseDto> UpsertItemAsync(long id, UpsertItemRequestDto item)
        { 
            var response = new UpsertItemResponseDto();

            if (id < 0 || (id == 0 && item == null) || (id > 0 && item == null))
            {
                response.Error = "Bad data.";
            }

            // Create item
            if (id == 0)
            {
                Item itemToAdd = mapper.Map<Item>(item);
                await dbContext.AddAsync(itemToAdd);
                await dbContext.SaveChangesAsync();

                response.Item = mapper.Map<ItemDto>(itemToAdd);
            }
            // Update item
            else
            {                
                Item itemToUpdate = await dbContext.Items
                    .Include(x => x.Category)
                    .Include(x => x.Images)
                    .SingleOrDefaultAsync(x => x.Id == id);

                if (itemToUpdate != null)
                {
                    itemToUpdate.CategoryId = item.CategoryId;
                    itemToUpdate.Name = item.Name;
                    itemToUpdate.Description = item.Description;
                    itemToUpdate.ImagePath = item.ImagePath;
                    itemToUpdate.Price = item.Price;
                    
                    if (item.Images != null) 
                    {
                        var itemImages = await dbContext.ItemImages.Where(x => x.ItemId == item.Id).ToListAsync();
                        foreach (var itemImage in itemImages)
                        {
                            dbContext.ItemImages.Remove(itemImage);
                        }
                        var imagesToAdd = mapper.Map<List<ItemImage>>(item.Images);
                        await dbContext.ItemImages.AddRangeAsync(imagesToAdd);
                        itemToUpdate.Images = imagesToAdd;
                    }

                    await dbContext.SaveChangesAsync();
                    response.Item = mapper.Map<ItemDto>(itemToUpdate);
                }
                else 
                {
                    response.Error = "No item found.";
                }
            }

            return response;
        }

        public async Task<DeleteItemResponseDto> DeleteItemAsync(long id)
        {
            var response = new DeleteItemResponseDto();
            var itemToDelete = await dbContext.Items.SingleOrDefaultAsync(item => item.Id == id);
            
            if (itemToDelete == null)
            {
                response.Error = "No item found.";
                return response;                                
            }            

            response.Item = mapper.Map<ItemDto>(itemToDelete);
            dbContext.Items.Remove(itemToDelete);
            await dbContext.SaveChangesAsync();
            return response;
        }

        private async Task<List<ItemDto>> GetItemsAsync(SearchItemsRequestDto? requestDto = null)
        {
            var itemsDtos = dbContext
                .Items
                .Include(i => i.Category)
                .Include(i => i.Images)
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
