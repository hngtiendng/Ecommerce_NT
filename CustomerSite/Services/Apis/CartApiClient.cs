using CustomerSite.Services.Interfaces;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using SharedVm;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace CustomerSite.Services.Apis
{
    public class CartApiClient : ICartApiClient
    {
        private readonly IConfiguration _configuration;

        private readonly IRequest _request;

        public CartApiClient(IConfiguration configuration, IRequest request)
        {
            _request = request;
            _configuration = configuration;

        }
        public async Task<CartVm> CreateCart(CartVm cartVm)
        {
            var client = _request.SendAccessToken().Result;
            HttpContent httpContent = new StringContent(JsonConvert.SerializeObject(cartVm),
                Encoding.UTF8, "application/json");
            var response = await client.PostAsync(_configuration["BackendUrl:Default"] + "/api/Cart", httpContent);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<CartVm>();
        }

        public async Task<CartVm> GetCartByUser(string userId)
        {
            var client = _request.SendAccessToken().Result;
            var response1 = await client.GetAsync(_configuration["BackendUrl:Default"] + "/api/Cart/getCartByUser/" + userId);
            if (response1.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                CartVm cartVm = new()
                {
                    UserId = userId,
                    cartItemVms = new List<CartItemVm>(),
                    TotalPrice = 0
                };
                HttpContent httpContent = new StringContent(JsonConvert.SerializeObject(cartVm),
                    Encoding.UTF8, "application/json");
                await client.PostAsync(_configuration["BackendUrl:Default"] + "/api/Cart", httpContent);
            }
            var response = await client.GetAsync(_configuration["BackendUrl:Default"] + "/api/Cart/getCartByUser/" + userId);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<CartVm>();
        }
        public async Task<CartVm> AddCartItem(string userId, int productId, int quantity)
        {
            await GetCartByUser(userId);
            var client = _request.SendAccessToken().Result;
            var response1 = await client.GetAsync(_configuration["BackendUrl:Default"] + "/api/Product/" + productId);
            HttpContent httpContent = new StringContent(JsonConvert.SerializeObject(response1),
               Encoding.UTF8, "application/json");
            var response = await client.PutAsync(_configuration["BackendUrl:Default"] + "/api/Cart/addCartItem/" + userId + "/" + productId + "/" + quantity, httpContent);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<CartVm>();
        }
        public async Task<CartVm> RemoveItem(string userId, int productId)
        {
            await GetCartByUser(userId);
            var client = _request.SendAccessToken().Result;

            var response = await client.PutAsync(_configuration["BackendUrl:Default"] + "/api/Cart/removeItem/" + userId + "/" + productId, null);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<CartVm>();
        }
        public async Task<CartVm> ClearCart(string userId)
        {
            await GetCartByUser(userId);
            var client = _request.SendAccessToken().Result;
            var response = await client.PutAsync(_configuration["BackendUrl:Default"] + "/api/Cart/clearCart/" + userId, null);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<CartVm>();
        }
    }
}
