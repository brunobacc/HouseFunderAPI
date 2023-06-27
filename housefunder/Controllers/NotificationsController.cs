using housefunder.Helper;
using housefunder.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace housefunder.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificationsController : ControllerBase
    {
        // GET: api/Notifications/2
        [HttpGet("{financer_id}")]
        public IActionResult GetNotificationsQuery(int financer_id)
        {
            using (var db = new DbHelper())
            {
                var query = (
                    from n in db.notifications
                    where n.financer_id == financer_id
                    select new NotificationsQuery
                    {
                        id = n.notification_id,
                        title = n.title,
                        description = n.description
                    }
                );
                return Ok(query.ToList());
            }
        }

        // DELETE api/Notifications/5
        [HttpDelete("{notification_id}")]
        public bool Delete(int notification_id)
        {
            using (var db = new DbHelper())
            {
                if (db.notifications.Find(notification_id) != null)
                {
                    db.notifications.Remove(db.notifications.Find(notification_id));
                    db.SaveChanges();

                    return true;
                }
                return false;
            }
        }
    }
}
