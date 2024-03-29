﻿using housefunder.Helper;
using housefunder.Models;
using housefunder.Services;
using Microsoft.AspNetCore.Mvc;

namespace housefunder.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileController : Controller
    {
        private readonly IFileService _fileService;
        public FileController(IFileService fileService)
        {
            _fileService = fileService;
        }

        [HttpPost("{user_id}")]
        public async Task<IActionResult> UploadUserImage([FromForm] Files file, int user_id)
        {
            Users user;
            await _fileService.UploadUser(file);
            using (var db = new DbHelper())
            {
                user = db.users.Find(user_id);
                if (user.image != "user_image.jpg")
                {
                    await _fileService.RemoveUser(user.image);
                }
                user.image = file.image_file.FileName;
                db.SaveChanges();
            }
            return Ok(file);
        }
    }
}
