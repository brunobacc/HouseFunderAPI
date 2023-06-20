using housefunder.Helper;
using housefunder.Models;
using housefunder.Utils;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace housefunder.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegisterController : ControllerBase
    {
        [HttpPost]
        public async Task<ActionResult<Users>> Register(string username, string email, string password, int permission_level)
        {
            
            using (var db = new DbHelper())
            {
                foreach (Users u in db.users)
                {
                    if (email == u.email)
                    {
                        return Conflict("Email already exists");
                    }
                }
                password = Sha256.ComputeSHA256(password);
                var user = new Users(username, email, password, permission_level);
                db.users.Add(user);
                await db.SaveChangesAsync();
                return Ok(user);
            }
        }
    }
}
