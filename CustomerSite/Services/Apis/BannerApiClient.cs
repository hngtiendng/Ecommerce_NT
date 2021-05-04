using CustomerSite.Services.Interfaces;
using Microsoft.Extensions.Configuration;
using SharedVm;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
namespace CustomerSite.Services.Apis
{
    public class BannerApiClient : IBannerApiClient
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IConfiguration _configuration;
        public BannerApiClient(IHttpClientFactory httpClientFactory, IConfiguration configuration)
        {
            _httpClientFactory = httpClientFactory;
            _configuration = configuration;
        }
        public async Task<IList<BannerVm>> GetAllBanner()
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync(_configuration["BackendUrl:Default"] + "/api/Banner");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsAsync<IList<BannerVm>>();
        }
    }
}
