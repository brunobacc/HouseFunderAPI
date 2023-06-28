using housefunder.Helper;
using housefunder.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace housefunder.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdministratorsController : ControllerBase
    {
        // GET: api/Partnerships
        [HttpGet]
        public IActionResult GetAdmins()
        {
            using (var db = new DbHelper())
            {
                var query = (
                        from u in db.users
                        where u.permission_level == 3
                        select new { u.user_id, u.username, u.email, u.image, u.validated_proposals }
                    );
                return Ok(query.ToList());
            }
        }
    }
}
