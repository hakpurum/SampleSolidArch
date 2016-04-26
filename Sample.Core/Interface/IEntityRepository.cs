using System;
using System.Collections.Generic;
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
        void AddRange(IEnumerable<T> listEntity);
        void Delete(T entity);
        void Delete(Expression<Func<T, bool>> filter);
        void DeleteAll(Expression<Func<T, bool>> filter = null);

        void Save();
    }
}
