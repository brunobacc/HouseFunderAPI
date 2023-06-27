using housefunder.Helper;
using housefunder.Models;
using Microsoft.AspNetCore.Mvc;

namespace housefunder.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectsAdminController : ControllerBase
    {// GET: Projects
        [HttpGet]
        public IActionResult GetValidateProjectsQuery()
        {
            using (var db = new DbHelper())
            {
                var query = (
                    from p in db.projects
                    where p.status_id == 4 || p.status_id == 5
                    select p
                );

                return Ok(query.ToList());
            }

        }
    }
}
