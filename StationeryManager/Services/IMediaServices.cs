using Microsoft.AspNetCore.Components.Forms;

namespace StationeryManager.Services
{
    public interface IMediaServices
    {
        Task<string> UploadImage(IBrowserFile file);
        Task<string> UploadImage(IBrowserFile file, string folderName);
        Task<string> UploadImage(IBrowserFile file, string folderName, string fileName);
        Task<bool> DeleteImage(string imageUrl);
    }
}
