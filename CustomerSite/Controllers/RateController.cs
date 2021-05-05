using CustomerSite.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
namespace CustomerSite.Controllers
{
    public class RateController : Controller
    {
        private readonly IRateApiClient _ratingApiClient;
        public RateController(IRateApiClient ratingApiClient)
        {
            _ratingApiClient = ratingApiClient;
        }
        public async Task<IActionResult> Index(int productId)
        {
            var rate = await _ratingApiClient.GetRateByProduct(productId);
            return View(rate);
        }
        //[HttpPost]
        //public IActionResult CreateRate(int Id, int Star)
        //{
        //    RateVm x = new();
        //    x.UserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        //    x.ProductId = Id;
        //    x.Star = Star;
        //    _ratingApiClient.CreateRate(x);
        //    string referer = Request.Headers["Referer"].ToString();
        //    return Redirect(referer);

        //}

    }
}
