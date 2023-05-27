using GroupChat.Data;
using GroupChat.Models;
using GroupChat.Models.Dto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

[Route("api/users")]
[ApiController]
public class UsersController : ControllerBase
{
    private readonly ApplicationDbContext _db;

    public UsersController(ApplicationDbContext db)
    {
        _db = db;
    }

    // GET /api/users
    [HttpGet]
    public ActionResult<IEnumerable<UsersDto>> GetUsers()
    {
        var users = _db.Users.ToList();
         
        foreach (var user in users)
        {
            users[users.IndexOf(user)].Password= user.Password.GetHashCode().ToString();
        }
        return Ok(users);
    }

    // GET /api/users/{id}
    [HttpGet("{id}")]
    public ActionResult<UsersDto> GetUser(int id)
    {
        var user = _db.Users.Find(id);

        if (user == null)
        {
            return NotFound();
        }
        user.Password=user.Password.GetHashCode().ToString();
        return Ok(user);
    }

    // POST /api/users
    [HttpPost]
    public ActionResult<UsersDto> CreateUser([FromBody] UsersDto user)
    {
        if (ModelState.IsValid)
        {
            Users model = new()
            {
                
               UserName=user.UserName,
               Password=user.Password.GetHashCode().ToString(),
               AssociatedGroups=user.AssociatedGroups,
               CreatedDate = DateTime.Now

            };
            _db.Users.Add(model);
            _db.SaveChanges();
            return CreatedAtAction(nameof(GetUser), new { id = user.UserId }, user);
        }

        return BadRequest(ModelState);
    }

    // PUT /api/users/{id}
    [HttpPut("{id}")]
    public IActionResult UpdateUser(int id, [FromBody] UsersDto user)
    {
        if (id != user.UserId)
        {
            return BadRequest();
        }
        Users model = new()
        {
            UserId=user.UserId,
            UserName = user.UserName,
            Password = user.Password.GetHashCode().ToString(),
            AssociatedGroups = user.AssociatedGroups
        };
        _db.Users.Update(model);
        _db.SaveChanges();

        return NoContent();
    }

    // DELETE /api/users/{id}
    [HttpDelete("{id}")]
    public IActionResult DeleteUser(int id)
    {
        var user = _db.Users.Find(id);

        if (user == null)
        {
            return NotFound();
        }

        _db.Users.Remove(user);
        _db.SaveChanges();

        return NoContent();
    }
}
