using System;
using System.Collections.Generic;
using Sample.Core.Interface;
using Sample.Core.Common;
using System.Linq.Expressions;
using Sample.Core.Enums;
using Sample.Core.Extension;


namespace Sample.Core.Service
{
    public abstract class EntityService<T> : IService<T> where T : class,IEntity, new()
    {
        IUnitOfWork _unitOfWork;
        IEntityRepository<T> _repository;
        ILoggingService _loggingService;

        public EntityService(IUnitOfWork unitOfWork, IEntityRepository<T> repository, ILoggingService logingService)
        {
            _unitOfWork = unitOfWork;
            _repository = repository;
            _loggingService = logingService;
        }

        public Result<T> Get(T entity)
        {
            Result<T> result = new Result<T>();
            return result;
        }

        public Result<T> Get(Expression<Func<T, bool>> filter = null)
        {
            Result<T> result = new Result<T>();

            try
            {
                _loggingService.Info("Get()");
                result.ResultObject = _repository.Get(filter);
                result.ResultCode = (int)ResultStatusCode.OK;
                result.ResultMessage = ResultStatusCode.OK.ToString();
                result.setTrue();

            }
            catch (Exception ex)
            {
                _loggingService.Error("Hata Oluştu => " + ex.ToString());
                result.ResultCode = (int)ResultStatusCode.InternalServerError;
                result.ResultMessage = "Hata Oluştur => " + ex.ToString();
                result.setFalse();
            }

            return result;
        }

        public Result<IEnumerable<T>> GetList(Expression<Func<T, bool>> filter = null)
        {
            Result<IEnumerable<T>> result = new Result<IEnumerable<T>>();
            try
            {
                _loggingService.Info("GetList()");
                result.ResultObject = _repository.GetList(filter);
                result.ResultCode = (int)ResultStatusCode.OK;
                result.ResultMessage = ResultStatusCode.OK.ToString();
                result.setTrue();

            }
            catch (Exception ex)
            {
                _loggingService.Error("Hata Oluştu => " + ex.ToString());
                result.ResultCode = (int)ResultStatusCode.InternalServerError;
                result.ResultMessage = "Hata Oluştur => " + ex.ToString();
                result.setFalse();
            }

            return result;
        }

        public Result<IEnumerable<T>> GetListPaging(Expression<Func<T, bool>> filter, out int total, int index = 0, int size = 15)
        {
            Result<IEnumerable<T>> result = new Result<IEnumerable<T>>();

            try
            {
                _loggingService.Info("GetListPaging()");
                result.ResultObject = _repository.GetListPaging(filter, out total, index, size);
                result.ResultCode = (int)ResultStatusCode.OK;
                result.ResultMessage = ResultStatusCode.OK.ToString();
                result.setTrue();
            }
            catch (Exception ex)
            {
                total = 0;
                _loggingService.Error("Hata Oluştu => " + ex.ToString());
                result.ResultCode = (int)ResultStatusCode.InternalServerError;
                result.ResultMessage = "Hata Oluştur => " + ex.ToString();
                result.setFalse();
            }

            return result;
        }

        public Result<T> Add(T entity)
        {
            Result<T> result = new Result<T>();
            try
            {
                _loggingService.Info("Add()");
                result.ResultObject = _repository.Add(entity);
                result.ResultCode = (int)ResultStatusCode.OK;
                result.ResultMessage = ResultStatusCode.OK.ToString();
                result.setTrue();


            }
            catch (Exception ex)
            {
                _loggingService.Error("Parameters => " + entity.ObjectToString() + "Hata Oluştu => " + ex.ToString());
                result.ResultCode = (int)ResultStatusCode.InternalServerError;
                result.ResultMessage = "Hata Oluştur => " + ex.ToString();
                result.setFalse();
            }

            return result;
        }

        public Result<T> Update(T entity)
        {
            Result<T> result = new Result<T>();
            try
            {
                _loggingService.Info("Update()");
                result.ResultObject = _repository.Update(entity);
                result.ResultCode = (int)ResultStatusCode.OK;
                result.ResultMessage = ResultStatusCode.OK.ToString();
                result.setTrue();

            }
            catch (Exception ex)
            {
                _loggingService.Error("Parameters => " + entity.ObjectToString() + "Hata Oluştu => " + ex.ToString());
                result.ResultCode = (int)ResultStatusCode.InternalServerError;
                result.ResultMessage = "Hata Oluştur => " + ex.ToString();
                result.setFalse();
            }

            return result;
        }

        public Result<bool> Delete(T entity)
        {
            Result<bool> result = new Result<bool>();
            try
            {
                _loggingService.Info("Delete()");
                _repository.Delete(entity);
                result.ResultCode = (int)ResultStatusCode.OK;
                result.ResultMessage = ResultStatusCode.OK.ToString();
                result.ResultObject = true;
                result.setTrue();

            }
            catch (Exception ex)
            {
                _loggingService.Error("Parameters => " + entity.ObjectToString() + "Hata Oluştu => " + ex.ToString());
                result.ResultCode = (int)ResultStatusCode.InternalServerError;
                result.ResultMessage = "Hata Oluştur => " + ex.ToString();
                result.ResultObject = true;
                result.setFalse();
            }

            return result;
        }
    }
}
