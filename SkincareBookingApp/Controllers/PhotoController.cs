﻿using Service.Services.UploadImage;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SkincareBookingApp.Controllers
{
    [Route("api/photo")]
    [ApiController]
    public class PhotoController : ControllerBase
    {
        private readonly IUploadImageService _uploadImageService;

        public PhotoController(IUploadImageService uploadImageService)
        {
            _uploadImageService = uploadImageService;
        }

        [HttpPost("upload-photo")]
        public async Task<ActionResult<string>> UploadPhoto(IFormFile file)
        {
            var result = await _uploadImageService.UploadImageAsync(file);

            if (result.Error != null)
            {
                return BadRequest(result.Error.Message);
            }
            var photoUrl = result.SecureUrl.AbsoluteUri;

            return photoUrl;
        }
    }
}
