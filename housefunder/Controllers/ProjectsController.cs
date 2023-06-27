using housefunder.Helper;
using housefunder.Models;
using housefunder.Services;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;

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

        // GET: Projects
        [HttpGet("{user_id}")]
        public IActionResult GetFinishedProjectsQuery(int user_id)
        {
            using (var db = new DbHelper())
            {
                var query = (
                    from p in db.projects
                    where p.status_id == 3 && p.partnership_id == user_id
                    select p
                    );
                return Ok(query.ToList());
            }
        }

        private readonly IFileService _fileService;
        public ProjectsController(IFileService fileService)
        {
            _fileService = fileService;
        }

        // POST api/<ProjectsController>
        [HttpPost]
        public async Task<bool> Post([FromForm] Files file, [FromForm] ProjectsAdd project_add)
        {
            double finalValue = double.Parse(project_add.final_value);

            await _fileService.UploadProject(file);
            Projects project = new Projects(project_add.status_id, project_add.category_id, project_add.partnership_id, project_add.financer_id, project_add.location, file.image_file.FileName, project_add.title, project_add.description, finalValue);
            using (var db = new DbHelper())
            {
                db.projects.Add(project);
                db.SaveChanges();
            }
            return true;
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
