
using Microsoft.AspNetCore.Components.Forms;

namespace StationeryManager.Services.Impl
{
    public class MediaServices : IMediaServices
    {
        private readonly HttpClient _httpClient;

        public MediaServices(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public Task<bool> DeleteImage(string imageUrl)
        {
            throw new NotImplementedException();
        }

        public async Task<string> UploadImage(IBrowserFile file)
        {
            using var content = new MultipartFormDataContent();
            using var fileContent = new StreamContent(file.OpenReadStream());

            fileContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue(file.ContentType);

            content.Add(fileContent, "file", file.Name);

            var result = await _httpClient.PostAsync("https://localhost:7069/api/media/upload", content);

            if (result.IsSuccessStatusCode)
            {
                return await result.Content.ReadAsStringAsync();
            }

            throw new Exception($"Upload failed: {result.StatusCode} - {await result.Content.ReadAsStringAsync()}");
        }

        public Task<string> UploadImage(IBrowserFile file, string folderName)
        {
            throw new NotImplementedException();
        }

        public Task<string> UploadImage(IBrowserFile file, string folderName, string fileName)
        {
            throw new NotImplementedException();
        }
    }
}
