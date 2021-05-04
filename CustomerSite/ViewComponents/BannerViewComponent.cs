using CustomerSite.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CustomerSite.ViewComponents
{
    public class BannerViewComponent : ViewComponent
    {
        private readonly IBannerApiClient _bannerApiClient;

        public BannerViewComponent(IBannerApiClient bannerApiClient)
        {
            _bannerApiClient = bannerApiClient;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var banners = await _bannerApiClient.GetAllBanner();

            return View(banners);
        }
    }
}
