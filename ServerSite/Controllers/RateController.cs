using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ServerSite.Data;
using ServerSite.Models;
using SharedVm;
using System.Linq;
using System.Threading.Tasks;

namespace ServerSite.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize("Bearer")]
    public class RateController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public RateController(ApplicationDbContext context)
        {
            _context = context;
        }
        [HttpGet("getRateByUserId/{userId}")]
        [AllowAnonymous]
        public async Task<ActionResult<RateVm>> GetRateByProduct(int productId)
        {
            var rate = await _context.Rates.FirstOrDefaultAsync(x => x.ProductId == productId);

            if (rate == null)
            {
                return NotFound();
            }

            var rateVm = new RateVm
            {
                UserId = rate.UserId,
                Star = rate.Star,
                ProductId = rate.ProductId,
                Id = rate.Id,

            };

            return rateVm;
        }
        [HttpPost]
        [Authorize(Roles = "user")]
        public async Task<ActionResult<Rate>> CreateRate(RateVm rateVm)
        {
            var x = await _context.Rates.Where(x => x.ProductId == rateVm.ProductId).FirstOrDefaultAsync();
            var nRating = new Rate
            {
                Star = rateVm.Star,

                UserId = rateVm.UserId,
                ProductId = rateVm.ProductId
            };

            _context.Rates.Add(nRating);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAllRate",
                new { id = nRating.Id },
                new RateVm
                {
                    Star = nRating.Star,

                });
        }
    }
}
