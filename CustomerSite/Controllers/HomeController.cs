using CustomerSite.Models;
using CustomerSite.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Diagnostics;
using System.Threading.Tasks;

namespace CustomerSite.Controllers
{
    public class HomeController : Controller
    {

        private readonly IProductApiClient _productApiClient;
        private readonly IConfiguration _configuration;

        public HomeController(IProductApiClient productApiClient, IConfiguration configuration)
        {

            _productApiClient = productApiClient;
            _configuration = configuration;
        }

        public async Task<IActionResult> Index()
        {
            var product = await _productApiClient.GetAllProduct();
            foreach (var x in product)
            {
                for (int i = 0; i < x.ImageLocation.Count; i++)
                {
                    string setUrl = _configuration["BackendUrl:Default"] + x.ImageLocation[i];
                    x.ImageLocation[i] = setUrl;
                }
            }
            return View(product);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
