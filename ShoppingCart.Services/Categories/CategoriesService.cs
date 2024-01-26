using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ShoppingCart.Data.Contexts;
using ShoppingCart.Dtos.Categories;
using ShoppingCart.Dtos.Items;
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
    }
}
