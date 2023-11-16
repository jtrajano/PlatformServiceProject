using Microsoft.EntityFrameworkCore;
using PlatformService.Core.Interfaces;
using PlatformService.Core.Models;
using PlatformService.Infrastructure.Data;
using System.Linq.Expressions;

namespace PlatformService.Infrastructure.Repository.Base
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly AppDbContext _context;
        protected readonly DbSet<T> _dbSet;

        public Repository(AppDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();

        }
        public void Add(T entity)
        {
            _dbSet.Add(entity);
            // throw new NotImplementedException();
        }

        public T GetById(int id)
        {
            return _dbSet.Find(id);

        }
        public async Task<T> GetByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }
        public IEnumerable<T> ListAll()
        {
            return _dbSet.ToList();
        }

        public async Task<IEnumerable<T>> ListAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<IEnumerable<T>> ListAllAsync(Expression<Func<T, bool>> expression)
        {
            return await _dbSet.Where(expression).ToListAsync();
        }

        public IEnumerable<T> ListAll(Expression<Func<T, bool>> expression)
        {
            return  _dbSet.Where(expression).ToList();
        }
        public void Remove(T entity)
        {
            _dbSet.Remove(entity);
        }

    }
}
