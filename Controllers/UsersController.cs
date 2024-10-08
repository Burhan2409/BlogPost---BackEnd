using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MiniProject.DBModels;
using MiniProject.Models;

namespace MiniProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly InboxContext context;

        public UsersController(InboxContext _context)
        {
            context = _context;
        }

        //[HttpGet("users")]
        //public async Task<ActionResult<IEnumerable<Users>>> GetUsers()
        //{
        //    return await context.Burhan_Users.ToListAsync();
        //}

        //[HttpPost("users")]
        //public async Task<IActionResult> GetUsers([FromBody] UsersReturn loginDetails)
        //{

        //    if (string.IsNullOrEmpty(loginDetails.UserName) || string.IsNullOrEmpty(loginDetails.UserPassword))
        //    {
        //        return BadRequest("UserId and Password are required.");
        //    }


        //    var user = await Task.Run(() => context.Burhan_User
        //                    .FirstOrDefault(u => u.UserName == loginDetails.UserName && u.UserPassword == loginDetails.UserPassword));

        //    if (user == null)
        //    {
        //        return Unauthorized("Invalid UserId or Password.");
        //    }

        //    return Ok(user);
        //}

        [HttpPost("User")]

        public async Task<ActionResult<Users>> GetUser(Users user)
        {
            if (context.Burhan_User == null)
            {
                return NotFound();
            }

            var rand_var = await context.Burhan_User.FirstOrDefaultAsync(u => u.UserName == user.UserName && u.UserPassword == user.UserPassword);
            if (rand_var == null) { return NotFound(); }
            return rand_var;
        }
    }

}
