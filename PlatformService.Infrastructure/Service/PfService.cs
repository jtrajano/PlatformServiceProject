using PlatformService.Core.Interfaces;
using PlatformService.Core.Models;
using PlatformService.Infrastructure.Service.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlatformService.Infrastructure.Service
{
    public class PfService : BaseService , IPlatformService
    {
        public PfService(IUnitOfWork uow) : base (uow)
        {
            
        }

        public void CreatePlatform(Platform platform)
        {
            if (platform == null)
                throw new ArgumentNullException(nameof(platform));

            _uow.Platform.Add(platform);
        }

        public async Task<IEnumerable<Platform>> GetAllPlatForms()
        {
            return await _uow.Platform.ListAllAsync();
        }

        public async Task<Platform> GetPlatformById(int id)
        {
            return await _uow.Platform.GetByIdAsync(id);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await _uow.SaveChangesAsync();
        }
    }
}
