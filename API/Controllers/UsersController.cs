using API.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API;
 
 [ApiController]
 [Route("api/[controller]")] // /api/users
 public class UsersController(DataContext context) : Controller
 {
    [HttpGet]
    public async Task<ActionResult<IEnumerable<AppUser>>> GetUsers()
    {
        var user = await context.Users.ToArrayAsync();
        return user;
    }

    [HttpGet("{id:int}")] // /api/users/id
    public async Task<ActionResult<AppUser>> GetUser(int id)
    {
        var user = await context.Users.FindAsync(id);

        if(user == null)
            return NotFound();
        return user;
    }
 }