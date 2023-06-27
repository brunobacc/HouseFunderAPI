using housefunder.Helper;
using housefunder.Models;
using Microsoft.AspNetCore.Mvc;

namespace housefunder.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectsController : ControllerBase
    {// GET: Projects
        [HttpGet]
        public Projects[] Get()
        {
            using (var db = new DbHelper())
            {
                return db.projects.ToArray();
            }
        }
        // GET api/<ProjectsController>/5
        [HttpGet("{project_id}")]
        public Projects Get(int project_id)
        {
            using (var db = new DbHelper())
            {
                if (db.projects.Find(project_id) != null)
                {
                    return db.projects.Find(project_id);
                }
                return null;
            }
        }

        // POST api/<ProjectsController>
        [HttpPost]
        public void Post([FromBody] Projects value)
        {
            using (var db = new DbHelper())
            {
                db.projects.Add(value);
                db.SaveChanges();
            }
        }

        // PUT api/<ProjectsController>/5
        [HttpPut("{project_id}")]
        public void Put(int project_id, [FromBody] Projects value)
        {
            Projects updateProjects;
            using (var db = new DbHelper())
            {
                if (db.projects.Find(project_id) != null)
                {
                    updateProjects = db.projects.Find(project_id);
                    updateProjects.category_id = value.category_id;
                    updateProjects.partnership_id = value.partnership_id;
                    updateProjects.location = value.location;
                    updateProjects.image = value.image;
                    updateProjects.title = value.title;
                    updateProjects.description = value.description;
                    updateProjects.final_value = value.final_value;
                    db.SaveChanges();
                }
            }
        }

        // PUT api/<ProjectsController>/5
        [HttpPut("status/{project_id}")]
        public void PutStatusId(int project_id, [FromBody] int value)
        {
            Projects updateProjects;
            using (var db = new DbHelper())
            {
                if (db.projects.Find(project_id) != null)
                {
                    updateProjects = db.projects.Find(project_id);
                    updateProjects.status_id = value;
                    db.SaveChanges();
                }
            }
        }

        // DELETE api/<ProjectsController>/5
        [HttpDelete("{project_id}")]
        public void Delete(int project_id)
        {
            using (var db = new DbHelper())
            {
                if (db.projects.Find(project_id) != null)
                {
                    db.projects.Remove(db.projects.Find(project_id));
                    db.SaveChanges();
                }
            }
        }
    }
}
