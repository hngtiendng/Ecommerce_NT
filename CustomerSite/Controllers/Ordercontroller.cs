using CustomerSite.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Security.Claims;
using System.Threading.Tasks;
namespace CustomerSite.Controllers
{
    public class Ordercontroller : Controller
    {
        private readonly IOrderApiClient _orderApiClient;
        

        public Ordercontroller(IOrderApiClient orderApiClient)
        {
           
            _orderApiClient = orderApiClient;
        }

        public async Task<IActionResult> Index()
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("SignIn", "Account");
            }
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var orders = await _orderApiClient.GetOrderByUser(userId);
            return View(orders);
        }
        public async Task<IActionResult> Detail(int Id)
        {
            var orderDetail = await _orderApiClient.GetOrderDetail(Id);
            return View(orderDetail);
        }
        public async Task<IActionResult> DeleteOrder(int Id)
        {
            await _orderApiClient.DeleteOrder(Id);
            return RedirectToAction("Index");
        }
    }
}
