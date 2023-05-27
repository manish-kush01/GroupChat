using GroupChat.Data;
using GroupChat.Models;
using GroupChat.Models.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc; 

namespace GroupChat.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GroupsController : ControllerBase
    {
        private readonly ApplicationDbContext _db;

        public GroupsController(ApplicationDbContext db)
        {
            _db = db;
        }

        [HttpGet]
        public IActionResult GetGroups()
        {
            var groups = _db.Groups.ToList();
            if(groups.Any())
            {
                return Ok(groups);
            }
            ModelState.AddModelError("No Groups", "No Groups found");
            return BadRequest(ModelState);
        }

        [HttpGet("{Id}")]
        public IActionResult GetGroup(int id)
        {
            var group = _db.Groups.FirstOrDefault(n=> n.GroupId== id);
            if(group == null)
            {
                ModelState.AddModelError("id", "No Group with that id is found");
                return BadRequest(ModelState);  
            }
            return Ok(group);
        }

        [HttpPost]
        public IActionResult CreateGroup([FromBody] GroupsDto group)
        {
            var groups= _db.Groups.FirstOrDefault(n=> n.GroupId==group.GroupId||n.GroupName==group.GroupName);
            if(group.GroupId==0 || groups == null)
            {
                Groups model = new()
                {
                    GroupName = group.GroupName,
                    GroupType = group.GroupType
                };
                _db.Groups.Add(model);
                _db.SaveChanges();
                return Ok(model);
            }
            ModelState.AddModelError("","Alreassy exists");
            return BadRequest(ModelState);
        }
    }
}
