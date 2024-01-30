using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ShoppingCart.Data.Contexts;
using ShoppingCart.Dtos.Categories;
using ShoppingCart.Dtos.Items;
using ShoppingCart.Models.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCart.Services.Categories
{
    public class CategoriesService : ICategoriesService
    {
        private readonly ShoppingCartDbContext dbContext;
        private readonly IMapper mapper;

        public CategoriesService(ShoppingCartDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }
        public async Task<GetAllCategoriesResponseDto> GetAllCategoriesAsync()
        {
            var cats = await dbContext
                .Categories
                .Select(cat => mapper.Map<CategoryDto>(cat))
                .ToListAsync();

            return new GetAllCategoriesResponseDto()
            {
                Categories = cats    
            };
        }

        public async Task<GetCategoryResponseDto> GetCategoryAsync(long id)
        {
            var category = await dbContext.Categories.SingleOrDefaultAsync(c => c.Id == id);
            var response = new GetCategoryResponseDto();

            if (category != null) 
            {           
                response.Category = mapper.Map<CategoryDto>(category);            
            } 
            else
            {
                response.Error = "No category found.";
            }

            return response;
        }

        public async Task<UpsertCategoryResponseDto> UpsertCategoryAsync(long id, UpsertCategoryRequestDto category)
        {
            var response = new UpsertCategoryResponseDto();

            if (id < 0 || (id == 0 && category == null) || (id > 0 && category == null))
            {
                response.Error = "Bad data.";
            }

            if (id == 0)
            {
                Category catToAdd = mapper.Map<Category>(category);
                await dbContext.Categories.AddAsync(catToAdd);
                await dbContext.SaveChangesAsync();
                response.Category = mapper.Map<CategoryDto>(catToAdd);
            }
            else 
            {
                var catToUpdate = await dbContext.Categories.SingleOrDefaultAsync(x => x.Id == id);

                if (catToUpdate != null)
                {
                    catToUpdate.Name = category.Name;
                    catToUpdate.Description = category.Description;
                    catToUpdate.ImagePath = category.ImagePath;
                    await dbContext.SaveChangesAsync();
                    response.Category = mapper.Map<CategoryDto>(catToUpdate);
                }
                else
                {
                    response.Error = "No category found.";
                }
            }

            return response;
        }

        public async Task<DeleteCategoryResponseDto> DeleteCategoryAsync(long id)
        {
            var response = new DeleteCategoryResponseDto();
            var catToDelete = await dbContext.Categories.SingleOrDefaultAsync(cat => cat.Id == id);

            if (catToDelete == null)
            {
                response.Error = "No item found.";
                return response;
            }

            response.Category = mapper.Map<CategoryDto>(catToDelete);
            dbContext.Categories.Remove(catToDelete);
            await dbContext.SaveChangesAsync();
            return response;
        }
    }
}
