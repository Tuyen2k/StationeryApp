namespace StationeryManagerApi.Service.Impl
{
    public class MediaServices : IMediaServices
    {
        private readonly IWebHostEnvironment _env;

        public MediaServices(IWebHostEnvironment env)
        {
            _env = env;
        }

        public async Task<string> UploadImage(IFormFile file)
        {
            return await UploadImage(file, "images", null);
        }

        public async Task<string> UploadImage(IFormFile file, string folderName)
        {
            return await UploadImage(file, folderName, null);
        }

        public async Task<string> UploadImage(IFormFile file, string folderName, string fileName)
        {
            if (file == null || file.Length == 0)
                throw new ArgumentException("File không hợp lệ");

            folderName = folderName ?? "images";

            var fileExtension = Path.GetExtension(file.FileName);
            if (string.IsNullOrWhiteSpace(fileName))
            {
                fileName = Path.GetFileNameWithoutExtension(file.FileName);
            }
            else
            {
                fileName = Path.GetFileNameWithoutExtension(fileName);
            }

            var uploadPath = Path.Combine(_env.WebRootPath, "upload", folderName);
            Directory.CreateDirectory(uploadPath);

            // Kiểm tra tên file trùng
            var existingFiles = Directory.GetFiles(uploadPath, $"{fileName}*{fileExtension}");
            if (existingFiles.Length > 0)
            {
                fileName = $"{fileName}-{existingFiles.Length + 1}";
            }

            var finalFileName = fileName + fileExtension;
            var filePath = Path.Combine(uploadPath, finalFileName);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            var urlPath = $"/upload/{folderName}/{finalFileName}";
            return urlPath;
        }

        public Task<bool> DeleteImage(string imageUrl)
        {
            if (string.IsNullOrWhiteSpace(imageUrl))
                return Task.FromResult(false);

            var relativePath = imageUrl.Replace("/", Path.DirectorySeparatorChar.ToString())
                                       .TrimStart(Path.DirectorySeparatorChar);

            var fullPath = Path.Combine(_env.WebRootPath, relativePath);

            if (File.Exists(fullPath))
            {
                File.Delete(fullPath);
                return Task.FromResult(true);
            }

            return Task.FromResult(false);
        }
    }
}
