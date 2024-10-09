using API.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API;
 
 public class UsersController(DataContext context) : BaseApiController
 {
    [AllowAnonymous]
    [HttpGet]
    public async Task<ActionResult<IEnumerable<AppUser>>> GetUsers()
    {
        var user = await context.Users.ToArrayAsync();
        return user;
    }

    [Authorize]
    [HttpGet("{id:int}")] // /api/users/id
    public async Task<ActionResult<AppUser>> GetUser(int id)
    {
        var user = await context.Users.FindAsync(id);

        if(user == null) 
            return NotFound();
        return user;
    }
 }