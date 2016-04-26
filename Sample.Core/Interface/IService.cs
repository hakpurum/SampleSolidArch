using Sample.Core.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Sample.Core.Interface
{
    public interface IService<T>
    {
        Result<T> Get(T entity);
        Result<T> Get(Expression<Func<T,bool>> filter = null);
        Result<IEnumerable<T>> GetList(Expression<Func<T,bool>> filter = null);
        Result<IEnumerable<T>> GetListPaging(Expression<Func<T, bool>> filter,out int total,int index = 0,int size = 15);
        Result<T> Add(T entity);
        Result<T> Update(T entity);
        Result<bool> Delete(T entity);
    }
}
