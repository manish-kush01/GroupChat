using GroupChat.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GroupChat.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessagesController : ControllerBase
    {
        private readonly ApplicationDbContext _db;

        public MessagesController(ApplicationDbContext db)
        {
            _db = db;
        }
    }
}
