using housefunder.Helper;
using housefunder.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace housefunder.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FinanceProjectController : ControllerBase
    {// GET: Users
        [HttpPost]
        public void Post(Finances value)
        {
            using (var db = new DbHelper())
            {
                db.finances.Add(value);
                db.SaveChanges();
            }
        }
    }
}
