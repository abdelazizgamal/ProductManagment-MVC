using CompanySystem.DAL;
using Microsoft.AspNetCore.Http;

namespace CompanySystem.BLL
{
    public static class ImageHelper
    {
        public static bool IsImage(String fileName)
        {
            // Allowed image extensions
            string[] permittedExtensions = { ".jpg", ".jpeg", ".png", ".gif", ".bmp", ".webp" };
            
            //Get file extension
            string extension = Path.GetExtension(fileName).ToLowerInvariant();
            // Validate extension
            if (!permittedExtensions.Contains(extension))
            {
                return false;
            }
            else return true;
            
        }
        public static string SaveImage(IFormFile image)
        {
            #region SaveImage
            // Create Unique Name For Image
            var uniqueFileName = Guid.NewGuid().ToString() + Path.GetExtension(image.FileName);

            // Define Path To Save Image
            string folderPath = Path.Combine(Directory.GetCurrentDirectory(),
                "wwwroot",
                "Images",
                "Products");

            // Create Folder If Not Exists
            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }
            string filePath = Path.Combine(folderPath, uniqueFileName);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                image.CopyTo(stream);
            }

            return uniqueFileName;

            #endregion
        }
    }
}
