using CustomerSite.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using SharedVm;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace CustomerSite.Controllers
{
    public class CartController : Controller
    {
        private readonly ICartApiClient _cartApiClient;
        private readonly IOrderApiClient _orderApiClient;
        private readonly IRateApiClient _ratingApiClient;
        public CartController(ICartApiClient cartApiClient, IOrderApiClient orderApiClient,IRateApiClient rateApiClient)
        {
            _cartApiClient = cartApiClient;
            _orderApiClient = orderApiClient;
            _ratingApiClient = rateApiClient;
        }
        public async Task<IActionResult> Index()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("SignIn", "Account");
            }
            else
            {
                var cartVm = await _cartApiClient.GetCartByUser(userId);
                cartVm.UserId = userId;
                var lstCartItem = cartVm.cartItemVms.ToList();
                var lstProduct = new List<CartItemVm>();
                if (lstCartItem.Count > 0)
                {
                    foreach (var x in lstCartItem)
                    {
                        var pVm = new CartItemVm()
                        {
                            productVm = new ProductVm(),
                        };
                        pVm.productVm.CategoryId = x.productVm.CategoryId;
                        pVm.productVm.Description = x.productVm.Description;
                        pVm.productVm.Id = x.productVm.Id;
                        pVm.productVm.ImageLocation = x.productVm.ImageLocation;
                        pVm.productVm.Inventory = x.productVm.Inventory;
                        pVm.productVm.Name = x.productVm.Name;
                        pVm.productVm.Price = x.productVm.Price;
                        pVm.Quantity = x.Quantity;
                        pVm.productVm.AverageStar = x.productVm.AverageStar;
                        lstProduct.Add(pVm);
                    };
                }
                return View(lstProduct);
            }

        }

        public async Task<IActionResult> AddCartItem(string userId, int productId, int quantity,int Star)
        {
            RateVm x = new();
            x.UserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            x.ProductId = productId;
            x.Star = Star;
            await _ratingApiClient.CreateRate(x);
            await _cartApiClient.AddCartItem(userId, productId, quantity);
            return Redirect("Index");
        }
        public async Task<IActionResult> RemoveItem(int Id)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            await _cartApiClient.RemoveItem(userId, Id);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> ClearCart()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var cartVm = await _cartApiClient.GetCartByUser(userId);
            var orderVm = await _orderApiClient.GetOrderByUser(userId);
            var lstProduct = new List<OrderDetailVm>();

            int y = orderVm.Count;
            var lstCartItem = cartVm.cartItemVms.ToList();
            if (lstCartItem.Count > 0)
            {
                foreach (var x in lstCartItem)
                {
                    var pVm = new OrderDetailVm()
                    {
                    };
                    pVm.ProductId = x.productVm.Id;
                    pVm.Quantity = x.Quantity;
                    pVm.UnitPrice = x.productVm.Price;
                    pVm.OrderId = y + 1;
                    lstProduct.Add(pVm);
                };
            }
            await _cartApiClient.ClearCart(userId);
            await _orderApiClient.CreateOrder(userId, lstProduct);
            return RedirectToAction("Index", "Order");
        }
    }
}
