using housefunder.Helper;
using housefunder.Models;
using housefunder.Utils;
using Microsoft.AspNetCore.Mvc;

namespace housefunder.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class usersController : ControllerBase
    {// GET: Users
        [HttpGet]
        public Users[] Get()
        {
            using (var db = new DbHelper())
            {
                return db.users.ToArray();
            }
        }
        // GET api/<usersController>/5
        [HttpGet("{token}")]
        public Users Get(string token)
        {
            String email = TokenManager.ValidateToken(token);
            using (var db = new DbHelper())
            {
                if (email != null)
                {
                    foreach (Users u in db.users)
                    {
                        if (u.email == email)
                        {
                            return u;
                        }
                    }
                    return null;
                }
                return null;
            }
        }

        // POST api/<usersController>
        [HttpPost]
        public void Post([FromBody] Users value)
        {
            using (var db = new DbHelper())
            {
                db.users.Add(value);
                db.SaveChanges();
            }
        }

        // PUT api/<usersController>/5
        [HttpPut("{user_id}")]
        public void Put(int user_id, [FromBody] Users value)
        {
            Users updateusers;
            using (var db = new DbHelper())
            {
                if (db.users.Find(user_id) != null)
                {
                    updateusers = db.users.Find(user_id);
                    updateusers.username = value.username;
                    updateusers.email = value.email;
                    updateusers.password = value.password;
                    updateusers.image = value.image;
                    db.SaveChanges();
                }
            }
        }

        // DELETE api/<usersController>/5
        [HttpDelete("{user_id}")]
        public void Delete(int user_id)
        {
            using (var db = new DbHelper())
            {
                if (db.users.Find(user_id) != null)
                {
                    db.users.Remove(db.users.Find(user_id));
                    db.SaveChanges();
                }
            }
        }
    }
}
