using System;
using DatingApi.Data;
using DatingApi.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DatingApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UsersController(DataContext dbcontext) : ControllerBase
{

    [HttpGet]
    public async Task<ActionResult<IEnumerable<AppUser>>> GetUsers()
    {
        var users = await dbcontext.Users.ToListAsync();

        return users;
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<AppUser>> GetUser(int id)
    {
        var user = await dbcontext.Users.FindAsync(id);
        
        if(user==null) return NotFound();

        return user;
    }


}
