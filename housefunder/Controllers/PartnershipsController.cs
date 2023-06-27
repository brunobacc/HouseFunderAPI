using housefunder.Helper;
using housefunder.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace housefunder.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PartnershipsController : ControllerBase
    {
        // GET: api/Partnerships
        [HttpGet]
        public IActionResult GetPartnerships()
        {
            using (var db = new DbHelper())
            {
                var query = (
                        from u in db.users
                        where u.permission_level == 2
                        select new Partnerships
                        {
                            id = u.user_id,
                            image = u.image,
                            name = u.username,
                            validated_proposals = u.validated_proposals
                        }
                    );
                return Ok(query.ToList());
            }
        }
    }
}
