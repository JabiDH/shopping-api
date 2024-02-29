using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ShoppingCart.Data.Contexts;
using ShoppingCart.Dtos.CartItems;
using ShoppingCart.Models.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCart.Services.CartItems
{
    public class CartItemsService : ICartItemsService
    {
        private readonly ShoppingCartDbContext dbContext;
        private readonly IMapper mapper;

        public CartItemsService(ShoppingCartDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        public async Task<CartItemsResponseDto> GetCartItemsAsync(string email)
        {
            if (string.IsNullOrEmpty(email))
            {
                throw new ApplicationException("Not a valid email address.");
            }
            
            return await GetCartItemsByEmail(email);
        }

        public async Task<CartItemsResponseDto> SaveCartItemsAsync(CartItemsRequestDto request)
        {
            if (request == null || request.CartItems == null)
            {
                throw new ArgumentNullException("CartItems");
            }

            List<CartItem> creates = new List<CartItem>();
            List<CartItem> updates = new List<CartItem>();

            foreach (var cartItem in request.CartItems)
            {
                var existingCartItem = await dbContext.CartItems
                    .SingleOrDefaultAsync(x => x.ItemId == cartItem.ItemId && x.Email.ToLower() == cartItem.Email);

                if (existingCartItem == null)
                {
                    var cartItemToCreate = new CartItem()
                    {
                        ItemId = cartItem.ItemId,
                        Email = cartItem.Email,
                        Quantity = cartItem.Quantity,
                        CreatedOn = DateTime.UtcNow
                    };
                    creates.Add(cartItemToCreate);
                }
                else
                { 
                    existingCartItem.Quantity = cartItem.Quantity;
                    existingCartItem.CreatedOn = DateTime.UtcNow;
                    updates.Add(existingCartItem);
                }
            }

            if (creates.Count > 0) 
            { 
                await dbContext.CartItems.AddRangeAsync(creates);
                await dbContext.SaveChangesAsync();
            }

            if (updates.Count > 0)
            { 
                dbContext.UpdateRange(updates);
                await dbContext.SaveChangesAsync();
            }

            return await GetCartItemsByEmail(request.Email);
        }

        public async Task<CartItemsResponseDto> RemoveCartItemsAsync(CartItemsRequestDto request)
        {
            if (request == null || request.CartItems == null)
            {
                throw new ArgumentNullException("CartItems");
            }

            List<CartItem> removes = new List<CartItem>();

            if (request.ClearAll == true)
            {
                removes = await dbContext.CartItems
                    .Where(x => x.Email.ToLower() == request.Email)
                    .ToListAsync();
            }
            else
            {
                foreach (var cartItem in request.CartItems)
                {
                    var existingCartItem = await dbContext.CartItems
                        .SingleOrDefaultAsync(x => x.ItemId == cartItem.ItemId && x.Email.ToLower() == cartItem.Email);

                    if (existingCartItem != null)
                    {
                        removes.Add(existingCartItem);
                    }
                }
            }

            if (removes.Count > 0)
            {
                dbContext.CartItems.RemoveRange(removes);
                await dbContext.SaveChangesAsync();
            }

            return await GetCartItemsByEmail(request.Email);
        }

        private async Task<CartItemsResponseDto> GetCartItemsByEmail(string email)
        {
            var cartItems = await dbContext.CartItems
                .Include(ci => ci.Item)
                .Where(ci => ci.Email.ToLower() == email.ToLower())
                .Select(cartItem => mapper.Map<CartItemResponseDto>(cartItem))
                .ToListAsync();

            var response = new CartItemsResponseDto()
            {
                CartItems = cartItems
            };

            return response;
        }
    }
}
