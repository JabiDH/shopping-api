using Newtonsoft.Json;
using ShoppingCart.Dtos.Auth;
using ShoppingCart.Dtos.Items;
using System.Net;
using System.Net.Http.Headers;
using System.Net.Http.Json;

namespace ShoppingCart.Test.IntegrationTests
{
    [TestFixture]
    public class Tests
    {
        private ApiTestFixture _fixture;
        private HttpClient _client;
        
        [SetUp]
        public async Task SetUp()
        {
            var loginRequestDto = new LoginRequestDto()
            {
                Email = "user@gmail.com",
                Password = "Pass@123"
            };
            _fixture = new ApiTestFixture();
            _client = _fixture.Client;
            await SetAuthorizeToken(loginRequestDto);
        }

        private async Task SetAuthorizeToken(LoginRequestDto loginRequestDto)
        {            
            var response = await _client.PostAsJsonAsync<LoginRequestDto>("/api/Auth/Login", loginRequestDto);

            var responseContent = await response.Content.ReadAsStringAsync();
            var loginResponseDto = JsonConvert.DeserializeObject<LoginResponseDto>(responseContent);

            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", loginResponseDto?.Token);           
        }

        [TearDown]
        public async Task TearDown()
        {
            _fixture.Dispose();
        }

        [Test]
        public async Task TesGetAllItemsAsync()
        {
            var response = await _client.GetAsync("/api/Item/GetAllItems");

            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));

            var responseContent = await response.Content.ReadAsStringAsync();
            var getAllItemsResponse = JsonConvert.DeserializeObject<GetAllItemsResponseDto>(responseContent);

            Assert.That(getAllItemsResponse?.Items, Is.Not.Empty);
        }

        [TestCase(1)]
        [TestCase(2)]
        [TestCase(3)]
        public async Task TesGetItemAsync(int itemId)
        {
            var response = await _client.GetAsync($"/api/Item/GetItem/{itemId}");

            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));

            var responseContent = await response.Content.ReadAsStringAsync();
            var getItemResponse = JsonConvert.DeserializeObject<GetItemResponseDto>(responseContent);

            Assert.That(getItemResponse, Is.Not.Null);
            Assert.That(getItemResponse.Succeeded, Is.True);
            Assert.That(getItemResponse.Item, Is.Not.Null);
            Assert.That(getItemResponse.Item.Id, Is.EqualTo(itemId));
        }

        [TestCase(0)]
        [TestCase(-1)]
        public async Task TestGetItemAsync_NotFound(int itemId)
        {
            var response = await _client.GetAsync($"/api/item/getitem/{itemId}");

            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.NotFound));            
        }
    }
}
