using AutoMapper;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using ShoppingCart.Data.Contexts;
using ShoppingCart.Dtos.Orders;
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

        public async Task<GetAllOrdersResponseDto> GetAllOrdersAsync(string? email)
        {
            var responseDto = new GetAllOrdersResponseDto();

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

        public async Task<GetOrderResponseDto> GetOrderAsync(long id)
        {
            var responseDto = new GetOrderResponseDto();

            var order = await GetOrderByIdAsync(id);

            if (order == null)
            {
                responseDto.Error = "No order found.";
            }

            var orderDto = mapper.Map<OrderDto>(order);
            responseDto.Order = orderDto;

            return responseDto;
        }

        public async Task<CreateOrderResponseDto> CreateOrderAsync(CreateOrderRequestDto requestDto)
        {
            var orderItemsDataTable = ConvertOrderItemsToDataTable(requestDto.OrderItems);
            var orderIdParameter =
                new SqlParameter("@OrderId", SqlDbType.BigInt) { Direction = ParameterDirection.Output };

            await dbContext.Database
                .ExecuteSqlRawAsync($"EXEC dbo.create_order @OrderId OUTPUT, @Email, @Status, @SaleTax, @OrderItems",
                orderIdParameter,
                new SqlParameter("@Email", SqlDbType.NVarChar) { Value = requestDto.Email },
                new SqlParameter("@Status", SqlDbType.NVarChar) { Value = requestDto.Status },
                new SqlParameter("@SaleTax", SqlDbType.Decimal) { Value = requestDto.SaleTax },
                new SqlParameter("@OrderItems", SqlDbType.Structured) { TypeName = "dbo.OrderItemsType", Value = orderItemsDataTable });

            var id = (long)orderIdParameter.Value;

            var response = id > 0 ? 
                new CreateOrderResponseDto() 
                {
                    Order = await GetOrderByIdAsync(id)
                } : 
                new CreateOrderResponseDto() 
                { 
                    Error = "Failed to create order."
                };

            return response;
        }

        public async Task<DeleteOrderResponseDto> DeleteOrderAsync(long id)
        {           
            var order = await dbContext
                                .Orders
                                .SingleOrDefaultAsync(o => o.Id == id);
            if (order == null)
            {
                return new DeleteOrderResponseDto() { Error = "No order found." };
            }

            dbContext.Orders.Remove(order);
            return new DeleteOrderResponseDto() { Order = mapper.Map<OrderDto>(order) };
        }

        private async Task<OrderDto> GetOrderByIdAsync(long id)
        {
            var order = await dbContext.Orders
                .Where(o => o.Id == id)
                .Include(o => o.OrderItems)
                .ThenInclude(oi => oi.Item)
                .FirstOrDefaultAsync();

            return mapper.Map<OrderDto>(order);
        }

        private DataTable ConvertOrderItemsToDataTable(List<OrderItemDto> orderItems)
        {
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("ItemId");
            dataTable.Columns.Add("Price");
            dataTable.Columns.Add("SaleTax");
            dataTable.Columns.Add("Quantity");

            foreach (var orderItem in orderItems)
            {
                dataTable.Rows.Add(orderItem.ItemId, orderItem.Price, orderItem.SaleTax, orderItem.Quantity);
            }

            return dataTable;
        }
    }
}
