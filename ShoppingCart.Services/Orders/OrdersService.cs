using AutoMapper;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using ShoppingCart.Data.Contexts;
using ShoppingCart.Dtos.Enums;
using ShoppingCart.Dtos.Orders;
using ShoppingCart.Models.DataModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCart.Services.Orders
{
    public class OrdersService : IOrdersService
    {
        private readonly ShoppingCartDbContext dbContext;
        private readonly IMapper mapper;
        public OrdersService(ShoppingCartDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        public async Task<OrdersResponseDto> GetAllOrdersAsync(string? email)
        {
            var responseDto = new OrdersResponseDto();

            var orders = email != null ? 
                dbContext.Orders.Where(o => o.Email.ToLower() == email.ToLower()) : 
                dbContext.Orders;
                
            await orders
                .Include(o => o.OrderItems)
                .ThenInclude(oi => oi.Item)
                .ToListAsync();
            
            if (orders != null && orders.Count() == 0)
            {
                responseDto.Error = "No orders found.";
            }

            var orderDtos = mapper.Map<List<OrderDto>>(orders);
            responseDto.Orders = orderDtos;

            return responseDto;
        }

        public async Task<OrderResponseDto> GetOrderAsync(long id)
        {
            var responseDto = new OrderResponseDto();

            var order = await GetOrderByIdAsync(id);

            if (order == null)
            {
                responseDto.Error = "No order found.";
            }

            var orderDto = mapper.Map<OrderDto>(order);
            responseDto.Order = orderDto;

            return responseDto;
        }

        public async Task<OrderResponseDto> DeleteOrderAsync(long id)
        {           
            var order = await dbContext
                                .Orders
                                .SingleOrDefaultAsync(o => o.Id == id);
            if (order == null)
            {
                return new OrderResponseDto() { Error = "No order found." };
            }

            dbContext.Orders.Remove(order);
            return new OrderResponseDto() { Order = mapper.Map<OrderDto>(order) };
        }
        
        public async Task<OrderResponseDto> UpsertOrderAsync(long id, UpsertOrderRequestDto requestDto)
        {
            var response = new OrderResponseDto();
            if (id < 0 || requestDto == null || requestDto.OrderItems == null || requestDto.OrderItems.Count == 0)
            {
                response.Error = "Bad data.";
                return response;
            }
            
            var subtotal = requestDto.OrderItems.Sum(oi => oi.Quantity * oi.Price);
            var salesTax = subtotal * requestDto.TaxRate;
            var total = subtotal + salesTax;
            long orderId = id;

            if (orderId == 0) 
            {
                // Creating the order
                var orderToCreate = new Order()
                {
                    Email = requestDto.Email,
                    Status = OrderStatus.Created.ToString(),
                    CreatedOn = DateTime.UtcNow,
                    TaxRate = requestDto.TaxRate,
                    SalesTax = salesTax,
                    SubTotal = subtotal,
                    Total = total,
                    OrderItems = mapper.Map<List<OrderItem>>(requestDto.OrderItems)
                };
                await dbContext.Orders.AddAsync(orderToCreate);
                await dbContext.SaveChangesAsync();
                orderId = orderToCreate.Id;
            }
            else 
            {
                var orderToUpdate = await GetOrderByIdAsync(orderId);
                if (orderToUpdate == null)
                {
                    response.Error = "No order found.";
                    return response;
                }

                object status = null;
                if (!Enum.TryParse(typeof(OrderStatus), requestDto.Status, out status))
                {
                    response.Error = "Order status is not valid.";
                    return response;
                }

                orderToUpdate.Status = ((OrderStatus)status).ToString();
                orderToUpdate.SubTotal = subtotal;
                orderToUpdate.Total = total;
                orderToUpdate.TaxRate = requestDto.TaxRate;
                orderToUpdate.SalesTax = salesTax;
                orderToUpdate.ClosedOn = requestDto.CloseOn;
                orderToUpdate.OrderItems = mapper.Map<List<OrderItem>>(requestDto.OrderItems);

                dbContext.Orders.Update(orderToUpdate);
                await dbContext.SaveChangesAsync();
            }

            var order = await GetOrderByIdAsync(orderId);
            response.Order = mapper.Map<OrderDto>(order);
            return response;
        }

        private async Task<Order?> GetOrderByIdAsync(long id)
        {
            return await dbContext.Orders
                .Where(o => o.Id == id)
                .Include(o => o.OrderItems)
                .ThenInclude(oi => oi.Item)
                .FirstOrDefaultAsync();
        }
    }
}
