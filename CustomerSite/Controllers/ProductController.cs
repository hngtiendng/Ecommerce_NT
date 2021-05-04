using CustomerSite.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;
namespace CustomerSite.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductApiClient _productApiClient;
        private readonly IConfiguration _configuration;
        public ProductController(IProductApiClient productApiClient, IConfiguration configuration)
        {
            _productApiClient = productApiClient;
            _configuration = configuration;
        }
        public async Task<IActionResult> GetProductByCategory(int idCategory)
        {
            var products = await _productApiClient.GetProductByCategory(idCategory);
            foreach (var x in products)
            {
                for (int i = 0; i < x.ImageLocation.Count; i++)
                {
                    string setUrl = _configuration["BackendUrl:Default"] + x.ImageLocation[i];
                    x.ImageLocation[i] = setUrl;
                }
            }
            return View(products);
        }
        public async Task<IActionResult> Detail(int id)
        {
            var product = await _productApiClient.GetProductById(id);
            for (int i = 0; i < product.ImageLocation.Count; i++)
            {
                string setUrl = _configuration["BackendUrl:Default"] + product.ImageLocation[i];
                product.ImageLocation[i] = setUrl;
            }
            return View(product);
        }
    }
}
