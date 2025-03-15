using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services.UploadImage
{
    public class UploadImageService : IUploadImageService
    {
        private readonly Cloudinary cloudinary;

        public UploadImageService(IConfiguration configuration)
        {
            var account = new Account(
                configuration["CloudinarySettings:CloudName"] ?? Environment.GetEnvironmentVariable("CLOUDINARY_CLOUD_NAME"),
                configuration["CloudinarySettings:ApiKey"] ?? Environment.GetEnvironmentVariable("CLOUDINARY_API_KEY"),
                configuration["CloudinarySettings:ApiSecret"] ?? Environment.GetEnvironmentVariable("CLOUDINARY_API_SECRET")
            );

            cloudinary = new Cloudinary(account);
        }

        public async Task<ImageUploadResult> UploadImageAsync(IFormFile file)
        {
            var uploadResult = new ImageUploadResult();

            if (file.Length > 0)
            {
                using var stream = file.OpenReadStream();
                var uploadParams = new ImageUploadParams
                {
                    File = new FileDescription(file.Name, stream),
                    Transformation = new Transformation().Height(500).Width(500).Crop("fill").Gravity("face")
                };

                uploadResult = await cloudinary.UploadAsync(uploadParams);
            }

            return uploadResult;
        }

        public Task<DeletionResult> DeleteImageAsync(string publicId)
        {
            return null; // Implement deletion logic here
        }
    }
}
