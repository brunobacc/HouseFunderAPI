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

        [HttpPost]
        public async Task<IActionResult> Upload([FromForm] Files file)
        {
            await _fileService.Upload(file);
            return Ok(file);
        }

        [HttpGet]
        public async Task<IActionResult> Get(string name)
        {
            var imageFileStream = await _fileService.Get(name);
            string fileType = "jpg";
            if(name.Contains("png"))
            {
                fileType = "png";
            }
            return File(imageFileStream, $"image/{fileType}");
        }
    }
}
