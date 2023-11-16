using PlatformService.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PlatformService.Core.Interfaces
{
    public interface IRepository<T> where T : BaseEntity
    {
        IEnumerable<T> ListAll(Expression<Func<T, bool>> expression);
        Task<IEnumerable<T>> ListAllAsync(Expression<Func<T, bool>> expression);
        IEnumerable<T> ListAll();
        Task<IEnumerable<T>> ListAllAsync();


        T GetById(int id);
        Task<T> GetByIdAsync(int id);
       
        void Remove(T entity);
        void Add(T entity);

    }
}
