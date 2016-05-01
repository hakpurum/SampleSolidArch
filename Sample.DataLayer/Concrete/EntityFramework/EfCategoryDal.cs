
using System.Data.Entity;
using Sample.Core.DataAccess;
using Sample.DataLayer.Interfaces;
using Sample.Entities.Concrete;

namespace Sample.DataLayer.Concrete.EntityFramework
{
    public class EfCategoryDal : EfRepository<Category>, ICategoryDal
    {
        public EfCategoryDal(DbContext context) : base(context)
        {
        }
    }
}