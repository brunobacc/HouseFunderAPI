using housefunder.Helper;
using housefunder.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace housefunder.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FinancersQuery2Controller : ControllerBase
    {
        [HttpGet]
        public IActionResult GetFinancersQuery2()
        {
            using (var db = new DbHelper())
            {
                var query = (
                    from u in db.users
                    where u.permission_level == 1
                    select new FinancersQuery2
                    {
                        username = u.username,
                        image = u.image,
                        financingDone = u.financing_done,
                        totalAmountFinanced = u.total_amount_financed
                    }
                    ).Distinct();

                return Ok(query.ToList());
            }

        }
    }
}

