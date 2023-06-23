using housefunder.Helper;
using housefunder.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace housefunder.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectsFinancedQueryController : ControllerBase
    {
        // GET: api/FinancersQuery/2
        [HttpGet("{userId}")]
        public IActionResult GetProjectsFinancedQuery(int userId)
        {
            using (var db = new DbHelper())
            {
                /*SELECT project_Id, location, image, title, description, total_financed, final_value, SUM(Finance_Value)
                FROM Finances f
                JOIN Projects p ON (f.project_Id = p.project_Id)
                WHERE financer_Id = ??
                GROUP BY project_Id, location, image, title, description, total_financed, final_value;*/
                var query = (
                    from f in db.finances
                    join p in db.projects on f.project_id equals p.project_id
                    where f.financer_id == userId
                    group f.financed_value by new { p.project_id, p.location, p.image, p.title, p.description, p.total_financed, p.final_value} into g
                    select new ProjectsFinanced
                    {
                        project_id = g.Key.project_id,
                        location = g.Key.location,
                        image = g.Key.image,
                        title = g.Key.title,
                        description = g.Key.description,
                        total_financed = g.Key.total_financed,
                        final_value = g.Key.final_value,
                        total_financed_user = g.Sum()
                    }
                );
                return Ok(query.ToList());
            }
        }
    }
}
