using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StationeryManagerApi.Service;

namespace StationeryManagerApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MediaController : ControllerBase
    {
        private readonly IMediaServices _mediaServices;

        public MediaController(IMediaServices mediaServices) {
            _mediaServices = mediaServices;
        }

        [HttpPost("upload")]
        //[Consumes("multipart/form-data")]
        public async Task<IActionResult> UploadImage(IFormFile file)
        {
            if (file == null || file.Length == 0)
            {
                return BadRequest("No file uploaded.");
            }
            var result = await _mediaServices.UploadImage(file);
            return Ok(result);
        }
    }
}
