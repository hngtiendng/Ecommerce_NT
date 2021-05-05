using CustomerSite.Services.Interfaces;
using Microsoft.AspNetCore.Http;
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
    public class OrderApiClient : IOrderApiClient
    {

        private readonly IConfiguration _configuration;
        private readonly IRequest _request;
        public OrderApiClient(IConfiguration configuration, IRequest request)
        {

            _configuration = configuration;
            _request = request;
        }
        public async Task<IList<OrderVm>> GetOrderByUser(string userId)
        {
            var client = _request.SendAccessToken().Result;
            var response = await client.GetAsync(_configuration["BackendUrl:Default"] + "/api/Order/getOrderByUser/" + userId);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<IList<OrderVm>>();
        }
        public async Task<OrderVm> CreateOrder(string userId, List<OrderDetailVm> orderDetailVm1)
        {
            var client = _request.SendAccessToken().Result;
            HttpContent httpContent = new StringContent(JsonConvert.SerializeObject(orderDetailVm1),
               Encoding.UTF8, "application/json");
            var response = await client.PostAsync(_configuration["BackendUrl:Default"] + "/api/Order/" + userId, httpContent);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsAsync<OrderVm>();
        }
        public async Task<OrderVm> DeleteOrder(int Id)
        {
            var client = _request.SendAccessToken().Result;
            var response = await client.DeleteAsync(_configuration["BackendUrl:Default"] + "/api/Order/" + Id);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsAsync<OrderVm>();
        }
        public async Task<OrderVm> GetOrderDetail(int Id)
        {
            var client = _request.SendAccessToken().Result;
            var response = await client.GetAsync(_configuration["BackendUrl:Default"] + "/api/Order/" + Id);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsAsync<OrderVm>();
        }
    }
}
