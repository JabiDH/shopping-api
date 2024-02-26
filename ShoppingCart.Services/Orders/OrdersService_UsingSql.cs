using AutoMapper;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
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
    public class OrdersService_UsingSql : IOrdersService_UsingSql
    {
        private readonly ShoppingCartDbContext dbContext;
        private readonly IMapper mapper;
        public OrdersService_UsingSql(ShoppingCartDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;

        }
        public async Task<OrdersResponseDto> GetOrdersAsync(long? id)
        {
            var orders = await GetOrders(id);
            var response = new OrdersResponseDto();

            if (orders == null || orders.Count == 0) 
            {
                response.Error = "No orders found.";
            }
            else 
            {
                response.Orders = orders;
            }

            return response;
        }

        public async Task<OrderResponseDto> CreateOrderAsync(UpsertOrderRequestDto requestDto)
        {
            var orderItemsDataTable = ConvertOrderItemsToDataTable(requestDto.OrderItems);
            var orderIdParameter =
                new SqlParameter("@OrderId", SqlDbType.BigInt) { Direction = ParameterDirection.Output };

            await dbContext.Database
                .ExecuteSqlRawAsync($"EXEC dbo.create_order @OrderId OUTPUT, @Email, @Status, @SaleTax, @OrderItems",
                orderIdParameter,
                new SqlParameter("@Email", SqlDbType.NVarChar) { Value = requestDto.Email },
                new SqlParameter("@Status", SqlDbType.NVarChar) { Value = requestDto.Status },
                new SqlParameter("@TaxRate", SqlDbType.Decimal) { Value = requestDto.TaxRate },
                new SqlParameter("@OrderItems", SqlDbType.Structured) { TypeName = "dbo.OrderItemsType", Value = orderItemsDataTable });

            var id = (long)orderIdParameter.Value;

            var order = (await GetOrders(id)).SingleOrDefault();

            var response = id > 0 ?
                new OrderResponseDto()
                {
                    Order = order
                } :
                new OrderResponseDto()
                {
                    Error = "Failed to create order."
                };

            return response;
        }

        private async Task<List<OrderDto>> GetOrders(long? id = null)
        {
            var orders = await dbContext.Orders
                .Where(o => o.Id == id || id == 0 || id == null)
                .Include(o => o.OrderItems)
                .ThenInclude(oi => oi.Item)
                .ToListAsync();
            return mapper.Map<List<OrderDto>>(orders);
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
                dataTable.Rows.Add(orderItem.ItemId, orderItem.Price, orderItem.SalesTax, orderItem.Quantity);
            }

            return dataTable;
        }
    }
}
