namespace StationeryManagerApi.Service
{
    public interface IMediaServices
    {
        Task<string> UploadImage(IFormFile file);
        Task<string> UploadImage(IFormFile file, string folderName);
        Task<string> UploadImage(IFormFile file, string folderName, string fileName);
        Task<bool> DeleteImage(string imageUrl);
    }
}
