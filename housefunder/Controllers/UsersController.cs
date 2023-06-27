﻿using housefunder.Helper;
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

        // GET api/<usersController>/5
        [HttpGet("/id/{userId}")]
        public String GetId(int userId)
        {
            Users user;
            using (var db = new DbHelper())
            {
               user = db.users.Find(userId);
                return Sha256.ComputeSHA256(user.password);
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
            Users updateUser;
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
                    updateUser = db.users.Find(user_id);
                    updateUser.username = value.username;
                    updateUser.email = value.email;
                    if (value.password != null)
                    {
                        value.password = Sha256.ComputeSHA256(value.password);
                        updateUser.password = value.password;
                    }
                    db.SaveChanges();
                }
            }
        }

        // PUT api/<usersController>/5
        [HttpPut("points/{user_id}")]
        public void PutPoints(int user_id, [FromBody] int points)
        {
            Users updateUser;
            using (var db = new DbHelper())
            {
                if (db.users.Find(user_id) != null)
                {
                    updateUser = db.users.Find(user_id);
                    updateUser.points -= points;
                    db.SaveChanges();
                }
            }
        }

        // PUT api/<usersController>/5
        [HttpPut("validEmail/{email}")]
        public bool PutValidEmail(string email)
        {
            using (var db = new DbHelper())
            {
                if (db.users.FirstOrDefault(u => u.email == email) != null)
                {
                    return true;
                }
                return false;
            }
        }

        // PUT api/<usersController>/5
        [HttpPut("resetPassword/{email}")]
        public void PutResetPassword(string email, [FromBody] string new_password)
        {
            Users updateUser;
            using (var db = new DbHelper())
            {
                updateUser = db.users.FirstOrDefault(u => u.email == email);
                if (updateUser != null)
                {
                    new_password = Sha256.ComputeSHA256(new_password);
                    updateUser.password = new_password;
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
