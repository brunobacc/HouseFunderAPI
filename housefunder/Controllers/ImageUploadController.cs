using housefunder.Helper;
using housefunder.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting.Internal;
using System.IO.Compression;
using static Azure.Core.HttpHeader;
using static System.Net.Mime.MediaTypeNames;

namespace housefunder.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImageUploadController : ControllerBase
    {
        public Microsoft.AspNetCore.Hosting.IHostingEnvironment hostingEnvironment;
        public ImageUploadController(Microsoft.AspNetCore.Hosting.IHostingEnvironment hostingEnv)
        {
            hostingEnvironment = hostingEnv;
        }

        [HttpPost("{user_id}")]
        public ActionResult<string> UploadImages(int user_id)
        {
            Users user;
            try
            {
                var files = HttpContext.Request.Form.Files;
                if(files != null && files.Count>0)
                {
                    foreach(var file in files)
                    {
                        var path = Path.Combine("C:\\Dev\\flutter\\projeto_computacao_movel\\assets\\images\\avatars\\" + file.FileName);
                        using(var stream = new FileStream(path, FileMode.Create))
                        {
                            file.CopyTo(stream);
                        }

                        using (var db = new DbHelper())
                        {
                            user = db.users.Find(user_id);
                            user.image = file.FileName;
                            db.SaveChanges();
                        }
                        /*Images image = new Images();
                        image.imagepath = path;
                        image.insertedon = DateTime.Now;
                        using (var db = new DbHelper())
                        {
                            db.images.Add(image);
                            db.SaveChanges();
                        }*/
                    }
                    return "Saves Successfully";
                }
                else
                {
                    return "Select Files";
                }
            }
            catch (Exception e) 
            {
                // Log or handle the exception appropriately
                if (e.InnerException != null)
                {
                    // Handle the inner exception separately
                    var innerExceptionMessage = e.InnerException.Message;
                    // Additional error handling or logging for the inner exception
                }

                return "An error occurred while saving the entity changes.";
            }
        }
        [HttpGet]
        public ActionResult<List<Images>> GetImages()
        {
            using (var db = new DbHelper())
            {
                var result = db.images.ToList();
                return result;
            }
        }
        [HttpGet("{id}")]
        public ActionResult<Images> GetImages(int id)
        {
            using (var db = new DbHelper())
            {
                var result = db.images.Find(id);
                return result;
            }
        }
    }
}
