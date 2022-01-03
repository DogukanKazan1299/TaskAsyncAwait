using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.DataAccess
{
    public interface IEntityRepository<T> where T:class,IEntity,new()
    {
        List<T> GetAll(Expression<Func<T,bool>> filter=null);
        Task<List<T>> GetAllAsync(Expression<Func<T, bool>> filter = null);
        T GetById(Expression<Func<T, bool>> filter);
        Task<T> GetByIdAsync(Expression<Func<T,bool>> expression);
        void Add(T entity);
        Task AddByAsync(T entity);
        void Delete(T entity);
        Task DeleteByAsync(T entity);
        void Update(T entity);
        Task UpdateByAsync(T entity);
    }
}
