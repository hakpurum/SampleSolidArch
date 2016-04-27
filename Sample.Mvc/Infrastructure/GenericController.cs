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
    public abstract class GenericController<TEntity, TEditViewModel> : BaseController
        where TEntity : class, new()
        where TEditViewModel : class, new()
    {
        private readonly IService<TEntity> _typeService;

        protected GenericController(IService<TEntity> typeService)
        {
            _typeService = typeService;
        }

        public virtual ActionResult Details(int id)
        {
            try
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
                if (result.ResultCode != (int)ResultStatusCode.OK) return RedirectToAction("Index");
                var tEditViewModel = result.ResultObject.ToCast<TEditViewModel>();
                SetAlertMessage(result);
                return View(tEditViewModel);
            }
            catch (Exception e)
            {
                SetAlertMessage(e.Message);
                return RedirectToAction("Index");
            }
        }

        public virtual ActionResult Edit(int id)
        {
            try
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
                if (result.ResultCode != (int)ResultStatusCode.OK) return RedirectToAction("Index");
                var tEditViewModel = result.ResultObject.ToCast<TEditViewModel>();
                SetAlertMessage(result);
                return View(tEditViewModel);
            }
            catch (Exception e)
            {
                SetAlertMessage(e.Message);
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public virtual ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                #region Builder Lamda Expression

                //where koşuluna gönderilecek lamdaexpression oluşturduk dinamik olarak
                var argParam = Expression.Parameter(typeof(TEntity), "f");
                Expression nameProperty = Expression.Property(argParam, new TEntity().GetPrimaryKeyName().Name);
                var val1 = Expression.Constant(id);
                Expression e1 = Expression.Equal(nameProperty, val1);
                var lambda = Expression.Lambda<Func<TEntity, bool>>(e1, argParam);

                #endregion

                var tEntity = collection.FormParse(_typeService.Get(lambda).ResultObject);
                tEntity.SetDefaultDateTime("UpdateDate");
                var edit = _typeService.Update(tEntity);
                SetAlertMessage(edit);
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                SetAlertMessage(e.Message);
                return RedirectToAction("Index");
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
                tEntity.SetDefaultDateTime("CreatedDate");
                var add = _typeService.Add(tEntity);
                SetAlertMessage(add);
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                SetAlertMessage(e.Message);
                return RedirectToAction("Create");
            }
        }

        public virtual ActionResult Delete(int id)
        {
            try
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
                if (result.ResultCode != (int)ResultStatusCode.OK) return RedirectToAction("Index");
                var tEditViewModel = result.ResultObject.ToCast<TEditViewModel>();
                return View(tEditViewModel);
            }
            catch (Exception e)
            {
                SetAlertMessage(e.Message);
                return RedirectToAction("Index");
            }
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public virtual ActionResult DeleteConfirmed(int id)
        {
            try
            {
                #region Builder Lamda Expression

                //where koşuluna gönderilecek lamdaexpression oluşturduk dinamik olarak
                var argParam = Expression.Parameter(typeof(TEntity), "f");
                Expression nameProperty = Expression.Property(argParam, new TEntity().GetPrimaryKeyName().Name);
                var val1 = Expression.Constant(id);
                Expression e1 = Expression.Equal(nameProperty, val1);
                var lambda = Expression.Lambda<Func<TEntity, bool>>(e1, argParam);

                #endregion
                var delete = _typeService.Delete(lambda);
                SetAlertMessage(delete);
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                SetAlertMessage(e.Message);
                return RedirectToAction("Index");
            }
        }
    }
}