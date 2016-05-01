
using System.Data.Entity;
using Sample.Core.DataAccess;
using Sample.DataLayer.Interfaces;
using Sample.Entities.Concrete;

namespace Sample.DataLayer.Concrete.EntityFramework
{
    public class EfSettingDal : EfRepository<Setting>, ISettingDal
    {
        public EfSettingDal(DbContext context) : base(context)
        {
        }
    }
}