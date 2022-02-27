using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SelfieAPokemon.Core.Application.Services
{
    public class RegisterImageToServerService : IRegisterImageToServerService
    {
        public RegisterImageToServerService()
        {

        }
        public async Task<string> SaveImage(string path, IFormFile file)
        {
            await this.CreateFolder(path);
            path = $"{path}\\{file.FileName}";
            using FileStream filestream = new FileStream(path, FileMode.OpenOrCreate);
            await file.CopyToAsync(filestream);
            return path;
        }

        public async Task CreateFolder(string path)
        {
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
        }
    }
}
