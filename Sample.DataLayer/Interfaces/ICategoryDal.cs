
using Sample.Core.Interface;
using Sample.Core.DataAccess;
using Sample.Entities.Concrete;

namespace Sample.DataLayer.Interfaces
{
    public interface ICategoryDal : IEntityRepository<Category>
    {
    }
}
