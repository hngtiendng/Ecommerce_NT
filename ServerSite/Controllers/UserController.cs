using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ServerSite.Data;
using SharedVm;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ServerSite.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize("Bearer")]
    public class UserController : Controller
    {
        private readonly ApplicationDbContext _context;

        public UserController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Authorize(Roles = "admin")]
        public async Task<ActionResult<IEnumerable<UserVm>>> GetUsers()
        {
            var List = await _context.Users.ToListAsync();

            if (List == null)
            {
                return NotFound();
            }

            List<UserVm> UserVmList = new();

            foreach (var x in List)
            {
                UserVm get = new();
                get.UserID = x.Id;
                get.Email = x.Email;
                get.Fullname = x.FullName;

                UserVmList.Add(get);
            }
            return UserVmList;
        }

        [HttpGet]
        [Route("roles")]
        public ActionResult<bool> CheckRoles()
        {
            var claimsIdentity = User.Identity as ClaimsIdentity;
            List<string> roles = claimsIdentity.FindAll("role").Select(c => c.Value).ToList();
            if (roles.Contains("admin"))
                return Ok();
            return NoContent();
        }
    }
}

