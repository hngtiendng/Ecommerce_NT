using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ServerSite.Data;
using SharedVm;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServerSite.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    [Authorize("Bearer")]
    public class BannerController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public BannerController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult<IEnumerable<BannerVm>>> GetAllBanner()
        {
            return await _context.Banners
                .Select(x => new BannerVm { Id = x.Id, ImagePath = x.ImagePath, ProductID = x.ProductID })
                .ToListAsync();
        }
        
    }
}
