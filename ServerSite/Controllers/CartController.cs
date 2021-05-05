using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ServerSite.Data;
using ServerSite.Models;
using SharedVm;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServerSite.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize("Bearer")]
    public class CartController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public CartController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet("getCartByUser/{userId}")]
        [Authorize(Roles = "user")]
        public async Task<ActionResult<CartVm>> GetCartByUser(string userId)
        {

            var cart = await _context.Carts.Include(x => x.CartItems)
                .ThenInclude(x => x.Product).ThenInclude(x => x.Images).FirstOrDefaultAsync(x => x.UserId == userId);

            if (cart == null)
            {
                return NotFound();
            }

            var lstProduct = cart.CartItems.ToList();

            var cartItemVms = new List<CartItemVm>();

            var c = new ProductVm();

            foreach (var x in lstProduct.ToList())
            {
                var cartItemVm = new CartItemVm();
                var lstImage = new List<string>();
                c = new ProductVm
                {


                    CategoryId = x.Product.CategoryId,

                    Description = x.Product.Description,
                    Id = x.Product.Id,

                    Inventory = x.Product.Inventory,
                    Name = x.Product.Name,
                    Price = x.Product.Price,

                };
                foreach (var y in x.Product.Images.ToList())
                {
                    lstImage.Add(y.ImagePath.ToString());
                }

                c.ImageLocation = lstImage;
                cartItemVm.Quantity = x.Quantity;
                cartItemVm.productVm = c;
                cartItemVms.Add(cartItemVm);

            }

            var cartVm = new CartVm { Id = cart.Id, TotalPrice = cart.TotalPrice, UserId = cart.UserId, cartItemVms = cartItemVms };
            return cartVm;
        }

        [HttpPost()]
        [Authorize(Roles = "user")]
        public async Task<ActionResult<CartVm>> CreateCart(CartVm cartVm)
        {
            List<CartItem> lstProducts = new();
            foreach (var x in cartVm.cartItemVms.ToList())
            {
                var pVm = new CartItem();


                pVm.Product.CategoryId = x.productVm.CategoryId;

                pVm.Product.Description = x.productVm.Description;
                pVm.Product.Id = x.Id;

                pVm.Product.Inventory = x.productVm.Inventory;
                pVm.Product.Name = x.productVm.Name;
                pVm.Product.Price = x.productVm.Price;

                lstProducts.Add(pVm);
            }
            var cart = new Cart
            {
                CartItems = lstProducts,
                Id = cartVm.Id,
                TotalPrice = cartVm.TotalPrice,
                UserId = cartVm.UserId

            };

            _context.Carts.Add(cart);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Get", new { id = cart.Id }, new CartVm
            {
                Id = cart.Id,
                UserId = cart.UserId,
                TotalPrice = cart.TotalPrice,
                cartItemVms = cartVm.cartItemVms
            });


        }
        [HttpPut("addCartItem/{userId}/{productId}/{quantity}")]
        [Authorize(Roles = "user")]
        public async Task<ActionResult<CartVm>> AddCartItem(string userId, int productId, int quantity)
        {
            var product = await _context.Products.FirstOrDefaultAsync(x => x.Id == productId);

            var cart = await _context.Carts.Include(x => x.CartItems).ThenInclude(x => x.Product).FirstOrDefaultAsync(x => x.UserId == userId);
            var cartItem = new CartItem
            {
                Product = product,
                Quantity = quantity,

            };


            if (cart == null)
            {
                return NotFound();
            }
            cart.CartItems.Add(cartItem);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Get", new { id = cart.Id }, new CartVm
            {
                Id = cart.Id,
                UserId = cart.UserId,
                TotalPrice = cart.TotalPrice,

            });

        }
        [HttpPut("removeItem/{userId}/{productId}")]
        [Authorize(Roles = "user")]
        public async Task<IActionResult> RemoveItem(string userId, int productId)
        {
            var cart = await _context.Carts.Include(c => c.CartItems).ThenInclude(c => c.Product).FirstOrDefaultAsync(x => x.UserId == userId);
            foreach (CartItem p in cart.CartItems)
            {
                if (p.Product.Id == productId)
                {
                    cart.CartItems.Remove(p);
                    await _context.SaveChangesAsync();
                }
            }
            if (cart == null)
            {
                return NotFound();
            }
            await _context.SaveChangesAsync();

            return CreatedAtAction("Get", new { id = cart.Id }, new CartVm
            {
                Id = cart.Id,
                UserId = cart.UserId,
                TotalPrice = cart.TotalPrice,

            });
        }
        [HttpPut("clearCart/{userId}")]
        [Authorize(Roles = "user")
        public async Task<IActionResult> ClearCart(string userId)
        {
            var cart = await _context.Carts.Include(c => c.CartItems).FirstOrDefaultAsync(x => x.UserId == userId);
            cart.CartItems.Clear();
            if (cart == null)
            {
                return NotFound();
            }
            await _context.SaveChangesAsync();

            return CreatedAtAction("Get", new { id = cart.Id }, new CartVm
            {
                Id = cart.Id,
                UserId = cart.UserId,
                TotalPrice = cart.TotalPrice,

            });
        }
    }
}