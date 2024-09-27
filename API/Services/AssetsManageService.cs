using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace cms_api.Services
{
    public class AssetsManageService
    {
        public static async Task<string> Save(string path, string name, IFormFile formFile)
        {
            var fullPath = Path.Combine("wwwroot",path);

            if(!Directory.Exists(fullPath))
                Directory.CreateDirectory(fullPath);
            
            fullPath = Path.Combine(fullPath,name);

            using (var stream = File.Create(fullPath))
            {
                await formFile.CopyToAsync(stream);
            }
            return Path.Combine(path, name);
        }
    }
}