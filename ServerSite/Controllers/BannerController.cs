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
        //    [HttpGet("{id}")]
        //    //[Authorize(Roles = "admin")]
        //    [AllowAnonymous]
        //    public async Task<ActionResult<BannerVm>> GetBannerById(int id)
        //    {
        //        var banner = await _context.Banners.FindAsync(id);

        //        if (banner == null)
        //        {
        //            return NotFound();
        //        }

        //        var bannerVm = new BannerVm
        //        {
        //            Id = banner.Id,
        //            ImagePath = banner.ImagePath,
        //            ProductID = banner.ProductID
        //        };

        //        return bannerVm;
        //    }
        //    [HttpPost]
        //    //[Authorize(Roles = "admin")]
        //    [AllowAnonymous]
        //    public async Task<ActionResult<BannerVm>> CreateBanner(BannerVm bannerVm)
        //    {
        //        var banner = new Banner
        //        {
        //            ImagePath = bannerVm.ImagePath,
        //            ProductID=bannerVm.ProductID
        //        };

        //        _context.Banners.Add(banner);
        //        await _context.SaveChangesAsync();

        //        return CreatedAtAction("Get", new { id = banner.Id }, new BannerVm
        //        {
        //            Id = banner.Id,
        //            ImagePath = banner.ImagePath,
        //            ProductID = banner.ProductID
        //        });
        //    }
        //    [HttpPut("{id}")]
        //    //[Authorize(Roles = "admin")]
        //    [AllowAnonymous]
        //    public async Task<IActionResult> UpdateBanner(int id, BannerVm bannerVm)
        //    {
        //        var banner = await _context.Banners.FindAsync(id);

        //        if (banner == null)
        //        {
        //            return NotFound();
        //        }
        //        banner.ImagePath = bannerVm.ImagePath;
        //        banner.Id = bannerVm.Id;
        //        banner.ProductID = bannerVm.ProductID;

        //        await _context.SaveChangesAsync();
        //        return NoContent();
        //    }

        //    [HttpDelete("{id}")]
        //    //[Authorize(Roles = "admin")]
        //    [AllowAnonymous]
        //    public async Task<IActionResult> DeleteBanner(int id)
        //    {
        //        var banner = await _context.Banners.FindAsync(id);

        //        if (banner == null)
        //        {
        //            return NotFound();
        //        }

        //        _context.Banners.Remove(banner);
        //        await _context.SaveChangesAsync();
        //        return Ok(banner);
        //    }

    }
}
