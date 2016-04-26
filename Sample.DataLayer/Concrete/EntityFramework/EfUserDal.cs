using Sample.Core.DataAccess;
using Sample.DataLayer.Interfaces;
using Sample.Entities.Concrete;
using System.Data.Entity;

namespace Sample.DataLayer.Concrete.EntityFramework
{
    public class EfUserDal : EfRepository<User>, IUserDal
    {
        public EfUserDal(DbContext context) : base(context)
        {
        }
    }
}
