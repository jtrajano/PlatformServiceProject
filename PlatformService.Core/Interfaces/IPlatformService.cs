using PlatformService.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlatformService.Core.Interfaces
{
    public interface IPlatformService 
    {
        Task<bool> SaveChangesAsync();
        Task<Platform> GetPlatformById(int id);
        Task<IEnumerable<Platform>> GetAllPlatForms();
        void CreatePlatform(Platform platform);


    }
}
