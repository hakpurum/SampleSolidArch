using Sample.Core.Interface;
using Sample.Entities.Concrete;

namespace Sample.DataLayer.Interfaces
{
    public interface IUserDal : IEntityRepository<User>
    {
    }
}
