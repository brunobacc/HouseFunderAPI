using housefunder.Helper;
using housefunder.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace housefunder.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilterProjectsController : ControllerBase
    {
        // GET: api/FilterProjects/2
        [HttpGet]
        public IActionResult GetFilterProjects(bool newest, bool oldest, bool low_high, bool high_low, double? min_value, double? max_value, string? region, string? partnership)
        {
            using (var db = new DbHelper())
            {
                var query = (
                    from p in db.projects
                    where p.status_id == 2 && (min_value == null || (p.final_value - p.total_financed) >= min_value) && (max_value == null || (p.final_value - p.total_financed) <= max_value) &&
                          ( region == null || p.location.Contains(region)) &&
                          db.users.Any(u => u.user_id == p.partnership_id && ((partnership == null || u.username.Contains(partnership))))
                    select p
                );

                if (newest)
                {
                    query = query.OrderByDescending(p => p.date_created);
                }
                else if (oldest)
                {
                    query = query.OrderBy(p => p.date_created);
                }
                else if (low_high)
                {
                    query = query.OrderBy((p) => p.final_value);
                }
                else if (high_low)
                {
                    query = query.OrderByDescending((p) => p.final_value);
                }

                return Ok(query.ToList());
            }
        }
    }
}

