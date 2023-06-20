using housefunder.Helper;
using housefunder.Models;
using housefunder.Utils;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace housefunder.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        [HttpPost]
        public ActionResult<string> Post(string email, string password)
        {
            using (var db = new DbHelper())
            {
                password = Sha256.ComputeSHA256(password);
                Console.WriteLine(password);
                foreach (Users user in db.users)
                {
                    if (email == user.email && password == user.password)
                    {
                        return TokenManager.GenerateToken(email);
                    }
                }
                return string.Empty;
            }
        }
    }
}
