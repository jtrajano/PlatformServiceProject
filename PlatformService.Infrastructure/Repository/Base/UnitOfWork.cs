using PlatformService.Core.Interfaces;
using PlatformService.Core.Models;
using PlatformService.Infrastructure.Data;

namespace PlatformService.Infrastructure.Repository.Base
{
    public class UnitOfWork : IUnitOfWork
    {
        protected readonly AppDbContext _context;


        public IPlatformRepository Platform { get; set; }

        public UnitOfWork(AppDbContext context, IPlatformRepository platform)
        {
            _context = context;
            Platform = platform;
        }
        public async Task<bool> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }
        public bool SaveChanges()
        {
            return _context.SaveChanges() > 0;
        }

        public void Update<T>(T entity) where T: BaseEntity
        {
            _context.Update(entity);
        }
    }
}
