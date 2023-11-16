using PlatformService.Core.Interfaces;
using PlatformService.Core.Models;
using PlatformService.Infrastructure.Data;
using PlatformService.Infrastructure.Repository.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlatformService.Infrastructure.Repository
{
    public class PlatformRepository : Repository<Platform>, IPlatformRepository
    {
        public PlatformRepository(AppDbContext context) : base(context)
        {
            
        }
    }
}
