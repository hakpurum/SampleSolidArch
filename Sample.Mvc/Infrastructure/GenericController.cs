using Sample.Core.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;
using Sample.Core.Extension;
using Sample.Core.Enums;

namespace Sample.Mvc.Infrastructure
{
    public abstract class GenericController<TEntity, TEditViewModel> : Controller
        where TEntity : class, new()
        where TEditViewModel : class, new()
    {
        private readonly IService<TEntity> _typeService;

        protected GenericController(IService<TEntity> typeService)
        {
            _typeService = typeService;
        }

        public virtual ActionResult Edit(int id)
        {
            #region Builder Lamda Expression

            //where koşuluna gönderilecek lamdaexpression oluşturduk dinamik olarak
            var argParam = Expression.Parameter(typeof(TEntity), "f");
            Expression nameProperty = Expression.Property(argParam, new TEntity().GetPrimaryKeyName().Name);
            var val1 = Expression.Constant(id);
            Expression e1 = Expression.Equal(nameProperty, val1);
            var lambda = Expression.Lambda<Func<TEntity, bool>>(e1, argParam);

            #endregion

            var result = _typeService.Get(lambda);
            if (result.ResultCode == (int)ResultStatusCode.OK)
            {
                var tEditViewModel = result.ResultObject.ToCast<TEditViewModel>();
                return View(tEditViewModel);
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public virtual ActionResult Edit(int id, FormCollection collection)
        {
            #region Builder Lamda Expression

            //where koşuluna gönderilecek lamdaexpression oluşturduk dinamik olarak
            var argParam = Expression.Parameter(typeof(TEntity), "f");
            Expression nameProperty = Expression.Property(argParam, new TEntity().GetPrimaryKeyName().Name);
            var val1 = Expression.Constant(id);
            Expression e1 = Expression.Equal(nameProperty, val1);
            var lambda = Expression.Lambda<Func<TEntity, bool>>(e1, argParam);

            #endregion

            try
            {
                var tEntity = collection.FormParse
                    (_typeService.Get(lambda).ResultObject);
                tEntity.SetDefaultDateTime("UpdateDate");
                var edit = _typeService.Update(tEntity);
                return Content(((ResultStatusCode)edit.ResultCode).ToString());
            }
            catch
            {
                return Content(ResultStatusCode.InternalServerError.ToString());
            }
        }

        public virtual ActionResult Create()
        {
            return View(new TEditViewModel());
        }

        [HttpPost]
        public virtual ActionResult Create(FormCollection collection)
        {
            try
            {
                var tEntity = collection.FormParse<TEntity>();
                tEntity.SetDefaultDateTime("CreateDate");
                var add = _typeService.Add(tEntity);
                return Content(((ResultStatusCode)add.ResultCode).ToString());
            }
            catch
            {
                return Content(ResultStatusCode.InternalServerError.ToString());
            }
        }

        [HttpPost]
        public virtual JsonResult Delete(int id)
        {
            #region Builder Lamda Expression

            //where koşuluna gönderilecek lamdaexpression oluşturduk dinamik olarak
            var argParam = Expression.Parameter(typeof(TEntity), "f");
            Expression nameProperty = Expression.Property(argParam, new TEntity().GetPrimaryKeyName().Name);
            var val1 = Expression.Constant(id);
            Expression e1 = Expression.Equal(nameProperty, val1);
            var lambda = Expression.Lambda<Func<TEntity, bool>>(e1, argParam);

            #endregion

            var result = _typeService.Delete(lambda);
            return Json(result);
        }
    }
}