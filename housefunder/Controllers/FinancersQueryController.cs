using housefunder.Helper;
using housefunder.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace housefunder.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FinancersQueryController : ControllerBase
    {
        // GET: api/FinancersQuery/2
        [HttpGet("project_id")]
        public IActionResult GetFinancersQuery(int project_id)
        {
            using (var db = new DbHelper())
            {
                var query = (
                    from u in db.users
                    join f in db.finances on u.user_id equals f.financer_id
                    where f.project_id == project_id
                    select new FinancersQuery
                    {
                        username = u.username,
                        image = u.image
                    }
                ).Distinct();
                return Ok(query.ToList());
            }
        }
    }
}
