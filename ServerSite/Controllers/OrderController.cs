using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ServerSite.Data;
using ServerSite.Models;
using SharedVm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServerSite.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize("Bearer")]
    public class OrderController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public OrderController(ApplicationDbContext context)
        {
            _context = context;
        }

        //[HttpGet]
        //[AllowAnonymous]
        //public async Task<ActionResult<IEnumerable<OrderVm>>> GetAllOrder()
        //{
        //    return await _context.Orders.Include(o => o.OrderDetails)
        //        .Select(x => new OrderVm
        //        {
        //            UserId = x.UserId,
        //            CraeteDate = x.CraeteDate,
        //            Id = x.Id,
        //            Status = x.Status,
        //            TotalPrice = x.TotalPrice
        //        })
        //        .ToListAsync();
        //}

        [HttpGet("{id}")]
        [Authorize(Roles = "user")]
        //[AllowAnonymous]
        public async Task<ActionResult<OrderVm>> GetOrderById(int id)
        {
            var order = await _context.Orders.Include(x => x.OrderDetails).FirstOrDefaultAsync(x => x.Id == id);

            if (order == null)
            {
                return NotFound();
            }
            List<OrderDetailVm> listOrderDetail = new();
            foreach (var oddt in order.OrderDetails)
            {
                var oddtVm = new OrderDetailVm
                {
                    ProductId = oddt.ProductId,
                    Quantity = oddt.Quantity,
                    UnitPrice = oddt.UnitPrice,

                };
                listOrderDetail.Add(oddtVm);
            }
            var orderVm = new OrderVm
            {
                Status = order.Status,
                Id = order.Id,
                CraeteDate = order.CraeteDate,
                UserId = order.UserId,
                TotalPrice = order.TotalPrice,
                orderDetailVms = listOrderDetail
            };

            return orderVm;
        }
        [HttpGet("getOrderByUser/{userId}")]
        [Authorize(Roles = "user")]
        //[AllowAnonymous]
        public async Task<ActionResult<IEnumerable<OrderVm>>> GetOrderByUser(string userId)
        {
            //var order = await _context.Orders.Include(o => o.OrderDetails).Where(x => x.UserId == userId)
            //   .FirstOrDefaultAsync();
            var order1 = await _context.Orders.Include(o => o.OrderDetails).Where(x => x.UserId == userId)
               .ToListAsync();
            //List<OrderVm> orderVms = new();

            List<OrderDetailVm> orderDetailVms = new();
            List<OrderVm> lstOrder = new();
            foreach (var order in order1)
            {
                foreach (var od in order.OrderDetails.ToList())
                {
                    var orderDetailVm = new OrderDetailVm
                    {
                        Id = od.Id,
                        OrderId = od.OrderId,
                        ProductId = od.ProductId,
                        Quantity = od.Quantity,
                        UnitPrice = od.UnitPrice
                    };
                    orderDetailVms.Add(orderDetailVm);
                }
                var orderVm = new OrderVm
                {
                    Status = order.Status,
                    Id = order.Id,
                    CraeteDate = DateTime.Now,
                    UserId = order.UserId,
                    TotalPrice = order.TotalPrice,
                    orderDetailVms = orderDetailVms
                };
                lstOrder.Add(orderVm);
            }
            //    orderVms.Add(orderVm);


            return lstOrder;
        }
        //[HttpPut("{id}")]
        ////[Authorize(Roles = "admin")]
        //[AllowAnonymous]
        //public async Task<IActionResult> UpdateOrder(int id, OrderVm orderVm)
        //{
        //    var order = await _context.Orders.FindAsync(id);

        //    if (order == null)
        //    {
        //        return NotFound();
        //    }

        //    order.TotalPrice = orderVm.TotalPrice;
        //    order.Status = orderVm.Status;
        //    order.CraeteDate = orderVm.CraeteDate;

        //    await _context.SaveChangesAsync();

        //    return NoContent();
        //}

        [HttpPost("{userId}")]
        [Authorize(Roles = "user")]
        //[AllowAnonymous]
        public async Task<ActionResult<OrderVm>> CreateOrder(string userId, List<OrderDetailVm> orderDetailVm1)
        {

            var Orders = new Order
            {
                UserId = userId,
            };
            _context.Orders.Add(Orders);
            await _context.SaveChangesAsync();

            OrderDetail oddt = new();
            foreach (OrderDetailVm x in orderDetailVm1)
            {

                oddt.Id = x.Id;
                oddt.OrderId = Orders.Id;
                oddt.ProductId = x.ProductId;
                oddt.Quantity = x.Quantity;
                oddt.UnitPrice = x.UnitPrice;



                _context.OrderDetails.Add(oddt);
                await _context.SaveChangesAsync();
            }

            //await _context.Orders.FindAsync(Orders);
            return CreatedAtAction("Get", new { id = Orders.Id }, new OrderVm
            {
                UserId = userId
            });
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "user")]
        //[AllowAnonymous]
        public async Task<ActionResult> DeleteOrder(int id)
        {
            var order = await _context.Orders.FindAsync(id);
            if (order == null)
            {
                return NotFound();
            }

            _context.Orders.Remove(order);
            await _context.SaveChangesAsync();

            return NoContent();
        }


    }
}
