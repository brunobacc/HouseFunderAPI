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
            Projects updatedProject;
            Users updateUser;
            using (var db = new DbHelper())
            {
                db.finances.Add(value);

                updatedProject = db.projects.Find(value.project_id);
                updatedProject.total_financed += value.financed_value;
                // verify if the financer already has been incremented to the total_investor
                if (db.finances.FirstOrDefault(f => f.financer_id == value.financer_id && f.project_id == value.project_id) == null)
                {
                    updatedProject.total_investor++;
                }
                    
                
                updateUser = db.users.Find(value.financer_id);
                updateUser.total_amount_financed += value.financed_value;
                updateUser.financing_done++;
                db.SaveChanges();
            }
        }
    }
}
