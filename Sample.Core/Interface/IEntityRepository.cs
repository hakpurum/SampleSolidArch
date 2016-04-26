using System;
using System.Linq;
using System.Linq.Expressions;

namespace Sample.Core.Interface
{
    public interface IEntityRepository<T> where T : class,IEntity, new()
    {

        T Get(Expression<Func<T, bool>> filter = null);
        IQueryable<T> GetList(Expression<Func<T, bool>> filter = null);
        IQueryable<T> GetListPaging(Expression<Func<T, bool>> filter, out int total, int index, int size);
        T Add(T entity);
        T Update(T entity);
        void Delete(T entity);
        void Save();
    }
}
