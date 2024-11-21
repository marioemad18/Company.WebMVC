using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.Service.Helper
{
    public class DocumentSettings
    {
        public static string UploadFile(IFormFile file, string folderName)
        {
            //var folderPath = @"C:\\Users\\mario emad\\source\\repos\\Company.WebMVC\\Company.Web\\wwwroot\\Images\\";
            // Get File Path
            var FolderPath = Path.Combine(Directory.GetCurrentDirectory(),"wwwroot\\Files", folderName);
            // Get File Name
            var fileName = $"{Guid.NewGuid()}-{file.FileName}";
            // Combine FolderPath With FileName
            var FilePath = Path.Combine(FolderPath, fileName);
            using var FileStream = new FileStream(FilePath, FileMode.Create);
            file.CopyTo(FileStream);
            return FilePath;
        }
    }
}
