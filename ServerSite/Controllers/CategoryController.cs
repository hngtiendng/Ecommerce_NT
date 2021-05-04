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
    public class CategoryController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public CategoryController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult<IEnumerable<CategoryVm>>> GetAllCategory()
        {
            return await _context.Categories
                .Select(x => new CategoryVm { Name = x.Name, Id = x.Id })
                .ToListAsync();
        }

        [HttpGet("{id}")]
        //[Authorize(Roles = "admin")]
        [AllowAnonymous]
        public async Task<ActionResult<CategoryVm>> GetCategoryById(int id)
        {
            var category = await _context.Categories.FindAsync(id);

            if (category == null)
            {
                return NotFound();
            }

            var categoryVm = new CategoryVm
            {
                Id = category.Id,
                Name = category.Name
            };

            return categoryVm;
        }

        [HttpPut]
        [Authorize(Roles = "admin")]
        [AllowAnonymous]
        public async Task<IActionResult> UpdateCategory(CategoryVm categoryVm)
        {
            var id = categoryVm.Id;
            var category = await _context.Categories.FindAsync(id);

            if (category == null)
            {
                return NotFound();
            }

            category.Name = categoryVm.Name;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpPost]
        [Authorize(Roles = "admin")]
        [AllowAnonymous]
        public async Task<ActionResult<CategoryVm>> CreateCategory(CategoryVm categoryVm)
        {
            var category = new Category
            {
                Name = categoryVm.Name,
            };

            _context.Categories.Add(category);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Get", new { id = category.Id },
                new CategoryVm { Id = category.Id, Name = category.Name });
        }

        //[HttpDelete("{id}")]
        ////[Authorize(Roles = "admin")]
        //[AllowAnonymous]
        //public async Task<IActionResult> DeleteCategory(int id)
        //{
        //    var category = await _context.Categories.FindAsync(id);
        //    if (category == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.Categories.Remove(category);
        //    await _context.SaveChangesAsync();

        //    return NoContent();
        //}

    }
}
