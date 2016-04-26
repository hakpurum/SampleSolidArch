using Sample.Core.DataAccess;
using Sample.DataLayer.Interfaces;
using Sample.Entities.Concrete;
using System.Data.Entity;


namespace Sample.DataLayer.Concrete.EntityFramework
{
    public class EfUserGroupDal : EfRepository<UserGroup>, IUserGroupDal
    {
        public EfUserGroupDal(DbContext context) : base(context)
        {
        }
    }
}
