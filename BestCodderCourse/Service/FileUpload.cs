using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Hosting;
using System;
using System.IO;
using System.Threading.Tasks;

namespace BestCodderCourse.Service
{
    public class FileUpload : IFileUpload
    {
        private readonly IWebHostEnvironment _webHostEnvironment;

        public FileUpload(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }

        public async Task<string> UploadFile(IBrowserFile file)
        {
            try
            {
                FileInfo fileInfo = new FileInfo(file.Name);
                var filename = Guid.NewGuid().ToString() + fileInfo.Extension;
                var folderDir = $"{_webHostEnvironment.WebRootPath}\\CourseImages";
                var path = Path.Combine(_webHostEnvironment.WebRootPath, "CourseImages", filename);

                var memoryStream = new MemoryStream();
                await file.OpenReadStream().CopyToAsync(memoryStream);

                if (!Directory.Exists(folderDir))
                    Directory.CreateDirectory(folderDir);
                await using (var fs = new FileStream(path,FileMode.Create,FileAccess.Write))
                {
                    memoryStream.WriteTo(fs);
                }
                var fullPath = $"CourseImages/{filename}";
                return fullPath;

            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
