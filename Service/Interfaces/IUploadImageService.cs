using CloudinaryDotNet.Actions;
using Microsoft.AspNetCore.Http;


namespace Service.Interfaces
{
    public interface IUploadImageService
    {
        Task<ImageUploadResult> UploadImageAsync(IFormFile file);

        Task<DeletionResult> DeleteImageAsync(string publicId);
    }
}