using Sample.Core.Interface;
using System;
using System.Data.Entity;

namespace Sample.Core.DataAccess
{
    public class UnitOfWork : IUnitOfWork
    {
        private DbContext _dbcontext;

        public UnitOfWork(DbContext context)
        {
            _dbcontext = context;
        }

        public int Commit()
        {
            return _dbcontext.SaveChanges();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (_dbcontext != null)
                {
                    _dbcontext.Dispose();
                    _dbcontext = null;
                }
            }
        }
    }
}
