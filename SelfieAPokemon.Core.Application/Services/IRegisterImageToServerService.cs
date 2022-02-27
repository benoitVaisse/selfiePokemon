using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SelfieAPokemon.Core.Application.Services
{
    public interface IRegisterImageToServerService
    {
        Task<string> SaveImage(string path, IFormFile file);

        Task CreateFolder(string Path);
    }
}
