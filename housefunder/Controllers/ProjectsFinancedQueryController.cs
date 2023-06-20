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
                /*SELECT Image, title, SUM(Finance_Value)
                FROM Finances f
                JOIN Projects p ON (f.project_Id = p.project_Id)
                WHERE financer_Id = 3
                GROUP BY Image, title;*/
                var query = (
                    from f in db.finances
                    join p in db.projects on f.project_id equals p.project_id
                    where f.financer_id == userId
                    group f.financed_value by new { p.image, p.title } into g
                    select new ProjectsFinanced
                    {
                        image = g.Key.image,
                        title = g.Key.title,
                        total_financed = g.Sum()
                    }
                );
                return Ok(query.ToList());
            }
        }
    }
}
