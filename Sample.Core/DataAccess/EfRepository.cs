using Sample.Core.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;
using System.Data.Entity;
using System.Data.Entity.Validation;

namespace Sample.Core.DataAccess
{
    public abstract class EfRepository<TEntity> : IEntityRepository<TEntity> where TEntity : class, IEntity, new()
    {
        protected DbContext context;
        protected readonly IDbSet<TEntity> _dbset;
        string errorMessage = string.Empty;

        public EfRepository(DbContext _context)
        {
            context = _context;
            _dbset = _context.Set<TEntity>();
        }

        public TEntity Get(Expression<Func<TEntity, bool>> filter = null)
        {
            return this._dbset.FirstOrDefault(filter);
        }

        public IQueryable<TEntity> GetList(Expression<Func<TEntity, bool>> filter = null)
        {
            return filter == null
                ? this._dbset
                : this._dbset.Where(filter);
        }

        public IQueryable<TEntity> GetListPaging(Expression<Func<TEntity, bool>> filter, out int total, int index, int size)
        {
            int skipCount = index * size;
            var resetSet = filter != null ? this._dbset.Where(filter).AsQueryable() : this._dbset.AsQueryable();

            resetSet = skipCount == 0 ? resetSet.Take(size) : resetSet.Skip(skipCount).Take(size);

            total = resetSet.Count();

            return resetSet;
        }

        public TEntity Add(TEntity entity)
        {
            if (entity == null)
                throw new ArgumentNullException("entity");

            return _dbset.Add(entity);
        }

        public TEntity Update(TEntity entity)
        {
            if (entity == null)
                throw new ArgumentNullException("entity");

            try
            {
                var updateEntity = context.Entry(entity);
                updateEntity.State = EntityState.Modified;
                return updateEntity.Entity;

            }
            catch (DbEntityValidationException ex)
            {
                foreach (var validationErrors in ex.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        errorMessage += Environment.NewLine + string.Format("Property : {0} Error : {1}", validationError.PropertyName, validationError.ErrorMessage);
                    }
                }

                throw new Exception(errorMessage, ex);

            }
        }

        public void Delete(TEntity entity)
        {
            if (entity == null)
                throw new ArgumentNullException("entity");

            try
            {
                var entry = context.Entry(entity);
                if (entry.State == EntityState.Detached)
                    _dbset.Attach(entity);
                _dbset.Remove(entity);

            }
            catch (DbEntityValidationException ex)
            {
                foreach (var validationErrors in ex.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        errorMessage += Environment.NewLine + string.Format("Property : {0} Error : {1}", validationError.PropertyName, validationError.ErrorMessage);
                    }
                }

                throw new Exception(errorMessage, ex);
            }
        }

        public void Save()
        {
            context.SaveChanges();
        }

        public void AddRange(IEnumerable<TEntity> listEntity)
        {
            if (listEntity == null)
                throw new ArgumentNullException("listEntity");
            foreach (var entity in listEntity)
            {
                _dbset.Add(entity);
            }
        }

        public void Delete(Expression<Func<TEntity, bool>> filter)
        {
            TEntity entity = Get(filter);
            if (entity != null)
            {
                try
                {
                    var entry = context.Entry(entity);
                    if (entry.State == EntityState.Detached)
                        _dbset.Attach(entity);
                    _dbset.Remove(entity);

                }
                catch (DbEntityValidationException dbEx)
                {
                    foreach (var validationError in dbEx.EntityValidationErrors.SelectMany(validationErrors => validationErrors.ValidationErrors))
                    {
                        errorMessage += Environment.NewLine + string.Format("Property: {0} Error: {1}", validationError.PropertyName, validationError.ErrorMessage);
                    }

                    throw new Exception(errorMessage, dbEx);
                }
            }
        }

        public void DeleteAll(Expression<Func<TEntity, bool>> filter = null)
        {

            if (filter != null)
            {
                IQueryable<TEntity> getDeleteList = GetList(filter);
                foreach (var item in getDeleteList)
                {
                    Delete(item);
                }
            }
        }
    }
}
