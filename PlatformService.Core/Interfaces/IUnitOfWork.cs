using PlatformService.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlatformService.Core.Interfaces
{
    public interface IUnitOfWork
    {
        public IPlatformRepository Platform { get; set; }
        void Update<T>(T entity) where T : BaseEntity;
        Task<bool> SaveChangesAsync();
        bool SaveChanges();
    }
}
