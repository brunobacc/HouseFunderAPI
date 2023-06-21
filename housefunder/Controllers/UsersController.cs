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
        public void Put(int user_id, [FromBody] EditUsers value)
        {
            Users updateUsers;
            using (var db = new DbHelper())
            {
                foreach (var u in db.users)
                {
                    if (u.user_id != user_id)
                    {
                        if (u.username == value.username || u.email == value.email)
                        {
                            return;
                        }
                    }   
                }
                if (db.users.Find(user_id) != null)
                {
                    updateUsers = db.users.Find(user_id);
                    updateUsers.username = value.username;
                    updateUsers.email = value.email;
                    if (value.password != null)
                    {
                        value.password = Sha256.ComputeSHA256(value.password);
                        updateUsers.password = value.password;
                    }
                    if (value.image != null)
                    {
                        updateUsers.image = value.image;
                    }
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
