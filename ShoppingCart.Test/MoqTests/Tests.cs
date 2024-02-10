using Microsoft.AspNetCore.Mvc;
using Moq;
using ShoppingCart.Api.Controllers;
using ShoppingCart.Dtos.Items;
using ShoppingCart.Services.Items;

namespace ShoppingCart.Test.MoqTests
{
    public class Tests
    {
        private Mock<IItemsService> itemsServiceMock;

        [SetUp]
        public void Setup()
        {
            itemsServiceMock = new Mock<IItemsService>();
        }

        [Test]
        public async Task TestGetAllItemsAsync_OkResponse()
        {
            itemsServiceMock.Setup(service => service.GetAllItemsAsync())
                            .ReturnsAsync(new GetAllItemsResponseDto()
                            {
                                Items = new List<ItemDto>() {
                                    new ItemDto() { Id = 1, Name = "Item_1", Description = "Item_1 Desc", CategoryId = 1, Price = 999.99M },
                                    new ItemDto() { Id = 2, Name = "Item_2", Description = "Item_2 Desc", CategoryId = 1, Price = 1099.99M }
                                }
                            });

            var controller = new ItemController(itemsServiceMock.Object, null, null);

            // Act
            var result = await controller.GetAllItems();

            // Assert
            Assert.NotNull(result, "Result should not be null.");

            var okResult = result as OkObjectResult;
            Assert.True(okResult.StatusCode == 200, "Status code should be 200.");

            var response = (GetAllItemsResponseDto)okResult.Value;
            Assert.That(response?.Items?.Count() == 2, "Items count should be 2.");

            Assert.NotNull(response?.Items?.SingleOrDefault(i => i.Name == "Item_1"), "Item_1 should not be null");
        }


    }
}